DELIMITER //

    DELIMITER //
    CREATE PROCEDURE GetServiceUsage(IN p_sortOption VARCHAR(10))
    BEGIN
        SET @row_num = 0;
        
        -- Xác định điều kiện sắp xếp dựa trên tham số
        SET @orderClause = CASE 
            WHEN p_sortOption = 'TenTang' THEN 'TENANTNAME ASC'  -- Sắp xếp theo tên A-Z
            WHEN p_sortOption = 'GiaTang' THEN 'UNITPRICE ASC'   -- Sắp xếp theo giá tăng dần
            WHEN p_sortOption = 'GiaGiam' THEN 'UNITPRICE DESC'  -- Sắp xếp theo giá giảm dần
            WHEN p_sortOption = 'NgayMoi' THEN 'START_DATE DESC'  -- Sắp xếp theo ngày mới nhất
            WHEN p_sortOption = 'NgayCu' THEN 'START_DATE ASC'  -- Sắp xếp theo ngày cũ nhất
            ELSE 'ROOMID ASC'                        -- Mặc định
        END;
        
        SET @sql = CONCAT('
            SELECT 
                (@row_num := @row_num + 1) AS STT,
                R.ROOMID, 
                CONCAT(T.FIRSTNAME, '' '', T.LASTNAME) AS TENANTNAME,
                S.SERVICENAME, 
                S.UNITPRICE,
                US.START_DATE,
                US.END_DATE
            FROM USE_SERVICE US
            JOIN TENANT T ON US.TENANTID = T.TENANTID
            JOIN SERVICE S ON US.SERVICEID = S.SERVICEID
            JOIN CONTRACT C ON C.TENANTID = T.TENANTID
            JOIN ROOM R ON C.ROOMID = R.ROOMID
            ORDER BY ', @orderClause);
        
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END //
    DELIMITER ;


CREATE PROCEDURE INSERT_SERVICE_USAGE(
    IN P_TENANTID VARCHAR(10),
    IN P_SERVICEID VARCHAR(10),
    IN P_STARTDATE DATE,
    IN P_ENDDATE DATE
)
BEGIN
    INSERT INTO use_service (TENANTID, SERVICEID, START_DATE, END_DATE)
    VALUES (P_TENANTID, P_SERVICEID, P_STARTDATE, P_ENDDATE);
END //

CREATE PROCEDURE InsertService(
    IN p_ServiceName VARCHAR(255),
    IN p_UnitPrice DECIMAL(10,2)
)
BEGIN
    DECLARE newID INT;
    DECLARE formattedID VARCHAR(10);

    -- Lấy số lượng bản ghi hiện tại
    SELECT COUNT(*) + 1 INTO newID FROM Service;

    -- Định dạng ID theo mẫu DVXXX
    SET formattedID = CONCAT('DV', LPAD(newID, 3, '0'));

    -- Thêm dữ liệu vào bảng
    INSERT INTO Service (SERVICEID, SERVICENAME, UNITPRICE)
    VALUES (formattedID, p_ServiceName, p_UnitPrice);
END//


CREATE PROCEDURE DeleteTenantService(
    IN p_TenantID VARCHAR(10),
    IN p_ServiceID VARCHAR(10)
)
BEGIN
    DELETE FROM use_service
    WHERE TENANTID = p_TenantID AND SERVICEID = p_ServiceID;
END //



CREATE PROCEDURE DeleteDichVu(IN p_serviceID VARCHAR(10))
BEGIN
    DELETE FROM service WHERE service.SERVICEID = p_serviceID;
END//


CREATE PROCEDURE UpdateServicePrice(
    IN p_ServiceID VARCHAR(255),
    IN p_NewPrice DECIMAL(10,2)
)
BEGIN
    UPDATE service 
    SET UNITPRICE = p_NewPrice
    WHERE SERVICEID = p_ServiceID;
END //

-- Thủ tục để lấy tất cả bãi đậu xe
CREATE PROCEDURE sp_GetAllParkingAreas()
BEGIN
    SELECT * FROM PARKINGAREA ORDER BY AREAID;
END //

-- Thủ tục để lấy danh sách ID tòa nhà
CREATE PROCEDURE sp_GetAllBuildings()
BEGIN
    SELECT BUILDINGID, ADDRESS FROM BUILDING ORDER BY BUILDINGID;
END //

-- Hàm để tạo ID tòa nhà mới tự động tăng
CREATE FUNCTION fn_GenerateNewBuildingId() 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(10);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(10);
    
    -- Lấy ID lớn nhất hiện tại, nếu không có thì mặc định là 'BD000'
    SELECT IFNULL(MAX(BUILDINGID), 'BD000') INTO max_id FROM BUILDING;
    
    -- Tách phần số và tăng lên 1
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    
    -- Tạo ID mới với format 'BDxxx' 
    SET new_id = CONCAT('BD', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END //
-- Thêm trigger để tự động cập nhật khi có tòa nhà mới
CREATE TRIGGER after_building_insert
AFTER INSERT ON BUILDING
FOR EACH ROW
BEGIN
    -- Tự động tạo một bản ghi trong bảng PARKINGAREA với thông tin mặc định
    DECLARE new_area_id VARCHAR(10);
    SET new_area_id = fn_GenerateNewParkingAreaId();
    
    -- Thêm bãi đậu xe mặc định cho tòa nhà mới
    INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
    VALUES (new_area_id, NEW.BUILDINGID, CONCAT('Khu vực trước tòa nhà ', NEW.BUILDINGID), 'Xe máy', 10);
END //

-- Thủ tục để thêm tòa nhà mới với ID tự động tăng
CREATE PROCEDURE sp_AddBuilding(
    IN p_username VARCHAR(20),
    IN p_address VARCHAR(100),
    IN p_numOfFloors INT,
    IN p_numOfRooms INT,
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE new_building_id VARCHAR(10);
    
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Thêm tòa nhà thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_username IS NULL OR p_username = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Tên người dùng không được để trống!';
    ELSEIF p_address IS NULL OR p_address = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Địa chỉ không được để trống!';
    ELSEIF p_numOfFloors <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Số tầng phải lớn hơn 0!';
    ELSEIF p_numOfRooms <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Số phòng phải lớn hơn 0!';
    ELSE
        -- Kiểm tra username có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM USER WHERE USERNAME = p_username) THEN
            SET p_success = FALSE;
            SET p_message = 'Tên người dùng không tồn tại!';
        ELSE
            -- Tạo ID mới
            SET new_building_id = fn_GenerateNewBuildingId();
            
            -- Thực hiện thêm dữ liệu
            INSERT INTO BUILDING (BUILDINGID, USERNAME, ADDRESS, NUMOFFLOORS, NUMOFROOMS)
            VALUES (new_building_id, p_username, p_address, p_numOfFloors, p_numOfRooms);
            
            -- Trả về ID mới tạo trong thông báo
            SET p_message = CONCAT('Thêm tòa nhà thành công! ID mới: ', new_building_id);
        END IF;
    END IF;
END //

-- Thủ tục để lấy danh sách địa chỉ đã có trong bảng PARKINGAREA
CREATE PROCEDURE sp_GetParkingAddresses()
BEGIN
    SELECT DISTINCT ADDRESS FROM PARKINGAREA ORDER BY ADDRESS;
END //

-- Hàm để tạo ID bãi đậu xe mới tự động tăng
CREATE FUNCTION fn_GenerateNewParkingAreaId() 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(10);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(10);
    
    SELECT IFNULL(MAX(AREAID), 'PA000') INTO max_id FROM PARKINGAREA;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('PA', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END //

-- Thủ tục để kiểm tra dữ liệu và thêm bãi đậu xe mới
CREATE PROCEDURE sp_AddParkingArea(
    IN p_buildingId VARCHAR(10),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT,
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE new_area_id VARCHAR(10);
    
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Thêm bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_buildingId IS NULL OR p_buildingId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID tòa nhà không được để trống!';
    ELSEIF p_address IS NULL OR p_address = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Địa chỉ không được để trống!';
    ELSEIF p_type IS NULL OR p_type = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không được để trống!';
    ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
    ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Sức chứa phải là số nguyên dương!';
    ELSE
        -- Kiểm tra tòa nhà có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID tòa nhà không tồn tại!';
        ELSE
            -- Tạo ID mới
            SET new_area_id = fn_GenerateNewParkingAreaId();
            
            -- Thực hiện thêm dữ liệu
            INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
            VALUES (new_area_id, p_buildingId, p_address, p_type, p_capacity);
            
            -- Trả về ID mới tạo trong thông báo
            SET p_message = CONCAT('Thêm bãi đậu xe thành công! ID mới: ', new_area_id);
        END IF;
    END IF;
END //

-- Thủ tục để khởi tạo dữ liệu form
CREATE PROCEDURE sp_InitParkingAreaForm(
    OUT p_new_area_id VARCHAR(10)
)
BEGIN
    -- Tạo ID mới
    SET p_new_area_id = fn_GenerateNewParkingAreaId();
END //

-- Thủ tục để cập nhật bãi đậu xe
CREATE PROCEDURE sp_UpdateParkingArea(
    IN p_areaId VARCHAR(10),
    IN p_buildingId VARCHAR(10),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT,
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Cập nhật bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_areaId IS NULL OR p_areaId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID bãi đậu xe không được để trống!';
    ELSEIF p_buildingId IS NULL OR p_buildingId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID tòa nhà không được để trống!';
    ELSEIF p_address IS NULL OR p_address = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Địa chỉ không được để trống!';
    ELSEIF p_type IS NULL OR p_type = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không được để trống!';
    ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
    ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Sức chứa phải là số nguyên dương!';
    ELSE
        -- Kiểm tra bãi đậu xe có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID bãi đậu xe không tồn tại!';
        ELSE
            -- Kiểm tra tòa nhà có tồn tại không
            IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
                SET p_success = FALSE;
                SET p_message = 'ID tòa nhà không tồn tại!';
            ELSE
                -- Thực hiện cập nhật dữ liệu
                UPDATE PARKINGAREA
                SET BUILDINGID = p_buildingId, 
                    ADDRESS = p_address, 
                    TYPE = p_type, 
                    CAPACITY = p_capacity
                WHERE AREAID = p_areaId;
            END IF;
        END IF;
    END IF;
END //

-- Thủ tục để xóa bãi đậu xe
CREATE PROCEDURE sp_DeleteParkingArea(
    IN p_areaId VARCHAR(10),
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Xóa bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_areaId IS NULL OR p_areaId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID bãi đậu xe không được để trống!';
    ELSE
        -- Kiểm tra bãi đậu xe có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID bãi đậu xe không tồn tại!';
        ELSE
            -- Kiểm tra có xe đang đậu không
            IF EXISTS (SELECT 1 FROM PARKING WHERE AREAID = p_areaId) THEN
                SET p_success = FALSE;
                SET p_message = 'Không thể xóa bãi đậu xe đang có xe!';
            ELSE
                -- Thực hiện xóa dữ liệu
                DELETE FROM PARKINGAREA WHERE AREAID = p_areaId;
            END IF;
        END IF;
    END IF;
END //

-- Thủ tục để lấy thông tin sức chứa của bãi đậu xe
CREATE PROCEDURE sp_GetParkingAreaCapacity(
    IN p_areaId VARCHAR(10),
    OUT p_totalCapacity INT,
    OUT p_usedCapacity INT,
    OUT p_availableCapacity INT
)
BEGIN
    -- Lấy tổng sức chứa
    SELECT CAPACITY INTO p_totalCapacity
    FROM PARKINGAREA
    WHERE AREAID = p_areaId;
    
    -- Đếm số lượng xe đang đậu
    SELECT COUNT(*) INTO p_usedCapacity
    FROM PARKING
    WHERE AREAID = p_areaId;
    
    -- Tính số chỗ còn trống
    SET p_availableCapacity = p_totalCapacity - p_usedCapacity;
END //

-- Thủ tục để lấy tất cả bãi đậu xe theo loại
CREATE PROCEDURE sp_GetParkingAreasByType(
    IN p_type VARCHAR(50)
)
BEGIN
    SELECT * FROM PARKINGAREA WHERE TYPE = p_type ORDER BY AREAID;
END //

-- Thủ tục để lấy tất cả bãi đậu xe theo tòa nhà
CREATE PROCEDURE sp_GetParkingAreasByBuilding(
    IN p_buildingId VARCHAR(10)
)
BEGIN
    SELECT * FROM PARKINGAREA WHERE BUILDINGID = p_buildingId ORDER BY AREAID;
END //


CREATE PROCEDURE update_Contract(
	IN p_contractId VARCHAR(20),
    IN p_endDate DATETIME,
    IN p_paymentSchedule VARCHAR(50),
    IN p_deposit FLOAT,
    IN p_notes VARCHAR(200)
    
)
BEGIN
    UPDATE contract
    SET 
        ENDDATE = p_endDate,
        PAYMENTSCHEDULE = p_paymentSchedule,
        DEPOSIT = p_deposit,
        NOTES = p_notes
    WHERE 
        CONTRACTID = p_contractId;
END//

CREATE PROCEDURE alter_Contract(IN contract_id VARCHAR(50))
BEGIN
   SELECT 
      c.CONTRACTID,
		c.ROOMID,
		CONCAT(t.FIRSTNAME, ' ', t.LASTNAME) AS FullName,
		c.CREATEDATE,
		c.STARTDATE,
		c.ENDDATE,
		c.MONTHLYRENT , 
		c.PAYMENTSCHEDULE,
		c.DEPOSIT,
		c.NOTES
   FROM contract c
   JOIN tenant t ON t.TENANTID = c.TENANTID
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building b ON r.BUILDINGID = b.BUILDINGID
   JOIN user u ON u.USERNAME = b.USERNAME
   WHERE c.CONTRACTID = contract_id;
END//

CREATE PROCEDURE add_Contract(
    IN p_address_room VARCHAR(50),
    IN p_id_room VARCHAR(50),
    IN p_fullname_user VARCHAR(50),
    IN p_createddate DATETIME,
    IN p_startdate DATETIME,
    IN p_enddate DATETIME,
    IN p_paymentschedule VARCHAR(50),
    IN p_deposit FLOAT,
    IN p_note VARCHAR(200)
)
BEGIN
    DECLARE v_contractid VARCHAR(50);

    DECLARE v_tenantid VARCHAR(50);
    DECLARE v_first_name VARCHAR(50);
    DECLARE v_last_name VARCHAR(50);
    DECLARE v_monthrent FLOAT;
    

    SET v_contractid = createContractID();

    SELECT r.PRICE INTO v_monthrent
    FROM room r 
    JOIN building b ON b.BUILDINGID = r.BUILDINGID 
    WHERE b.ADDRESS = p_address_room
    LIMIT 1;
  
	SET v_first_name = Trim(REGEXP_REPLACE(p_fullname_user, '[^ ]+$', ''));
   SET v_last_name = REVERSE(SUBSTRING(REVERSE(p_fullname_user), 1, LOCATE(' ', REVERSE(p_fullname_user)) - 1));
	
	
	SELECT TENANTID INTO v_tenantid
	FROM tenant 
	WHERE FIRSTNAME = v_first_name
	AND LASTNAME = v_last_name
	LIMIT 1;

    INSERT INTO contract (
        CONTRACTID, 
        ROOMID, 
        TENANTID, 
        CREATEDATE, 
        STARTDATE, 
        ENDDATE, 
        MONTHLYRENT, 
        PAYMENTSCHEDULE, 
        DEPOSIT, 
        NOTES
    ) VALUES (
        v_contractid,
        p_id_room,
        v_tenantid,
        p_createddate,
        p_startdate,
        p_enddate,
        v_monthrent,
        p_paymentschedule,
        p_deposit,
        p_note
    );

    SELECT CONCAT('Contract ', v_contractid, ' created successfully') AS result;
END//


CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `check_account`(
    `usern` VARCHAR(50)
) RETURNS INT
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE account_exists INT;
    SELECT COUNT(*) INTO account_exists FROM user WHERE USERNAME = usern;
    IF account_exists = 0 THEN
        RETURN 1;  -- Tài khoản không tồn tại
    ELSE
        RETURN 0;  -- Tài khoản đã tồn tại
    END IF;
END//

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createBuildingID`() 
RETURNS VARCHAR(20) CHARSET utf8mb4 COLLATE utf8mb4_unicode_ci
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(BuildingID), 'B000') INTO max_id FROM Building;
    SET number_part = CAST(SUBSTRING(max_id, 2) AS UNSIGNED) + 1;
    SET new_id = CONCAT('B', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createContractID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(ContractID), 'c000') INTO max_id FROM Contract;
    SET number_part = CAST(SUBSTRING(max_id, 2) AS UNSIGNED) + 1;
    SET new_id = CONCAT('c', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

 CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `checkFloorCapacity`(
    p_buildingid VARCHAR(10),
    p_floor INT
) 
RETURNS INT
DETERMINISTIC
BEGIN
     DECLARE max_rooms_on_floor INT;
    DECLARE current_rooms_on_floor INT;
    
    -- Kiểm tra số phòng hiện có trên tầng này
    SELECT COUNT(*) INTO current_rooms_on_floor
    FROM ROOM 
    WHERE BUILDINGID = p_buildingid AND FLOOR = p_floor;
    
    SELECT COUNT(*) INTO max_rooms_on_floor
    FROM BUILDING 
    WHERE BUILDINGID = p_buildingid;
    
    -- Trả về TRUE nếu còn chỗ (current_rooms_on_floor < max_rooms_per_floor)
    IF current_rooms_on_floor <= max_rooms_on_floor THEN
        RETURN 1;
    END IF;
    
    RETURN 0;
END//

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createRoomID`(
    building_id VARCHAR(10), 
    floor_num INT
) 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE next_room_num INT;
    DECLARE new_room_id VARCHAR(10);
    
    -- Tìm số phòng lớn nhất hiện có trên tầng này của tòa nhà
    SELECT IFNULL(MAX(CAST(SUBSTRING(ROOMID, 5) AS UNSIGNED)), 0) + 1 INTO next_room_num
    FROM ROOM 
    WHERE BUILDINGID = building_id AND FLOOR = floor_num
    AND ROOMID LIKE CONCAT('R', floor_num, '%');
    
    -- Tạo mã phòng mới (ví dụ: R101, R102,...)
    SET new_room_id = CONCAT('R', floor_num, LPAD(next_room_num, 2, '0'));
    
    RETURN new_room_id;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Contract`(IN p_username VARCHAR(50))
BEGIN
   SELECT 
      c.CONTRACTID,
      c.ROOMID,
      c.TENANTID,
      c.CREATEDATE,
      c.STARTDATE,
      c.ENDDATE,
      c.MONTHLYRENT, 
      c.PAYMENTSCHEDULE,
      c.DEPOSIT,
      c.STATUS,
      c.NOTES,
      c.AUTO_RENEW,
      c.TERMINATION_REASON,
      c.CONTRACT_FILE_PATH
   FROM contract c
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building b ON r.BUILDINGID = b.BUILDINGID
   JOIN user u ON u.USERNAME = b.USERNAME
   WHERE u.USERNAME = p_username;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Room`(IN p_username VARCHAR(50))
BEGIN
    SELECT 
        r.ROOMID, 
        r.BUILDINGID, 
        r.FLOOR,
        r.TYPE, 
        r.CONVENIENT, 
        r.AREA, 
        r.PRICE, 
        r.STATUS
    FROM room r
    JOIN building b ON r.BUILDINGID = b.BUILDINGID
    JOIN user u ON u.USERNAME = b.USERNAME
    WHERE u.USERNAME = p_username;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Assets`(
    IN p_username VARCHAR(50))
BEGIN
    SELECT 
        a.ASSETID,
        a.ROOMID,
        a.ASSETNAME,
        a.PRICE,
        a.STATUS,
        a.USE_DATE,
        r.BUILDINGID,
        r.TYPE AS ROOM_TYPE,
        r.FLOOR
    FROM ASSETS a
    JOIN ROOM r ON a.ROOMID = r.ROOMID
    JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE b.USERNAME = p_username
    ORDER BY a.USE_DATE DESC;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_addAccount`(
    IN `usern` VARCHAR(50),
    IN `passw` VARCHAR(50),
    IN `fulln` VARCHAR(100),
    IN `emai` VARCHAR(150),
    IN `birthd` DATE,
    IN `gender` VARCHAR(50),
    IN `phonen` VARCHAR(11),
    IN `addre` VARCHAR(200)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
   INSERT INTO user (USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS) 
   VALUES (usern, fulln, passw, emai, birthd, gender, phonen, addre);
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_login`(
    IN `usern` VARCHAR(20),
    IN `passw` VARCHAR(20)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
    SELECT * FROM user WHERE USERNAME = usern AND PASSWORD = passw;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Room_Extended`(IN p_username VARCHAR(50))
BEGIN
    SELECT 
        r.ROOMID, 
        r.BUILDINGID, 
        r.TYPE, 
        r.CONVENIENT, 
        r.AREA, 
        r.PRICE, 
        r.STATUS
    FROM room r
    JOIN building b ON r.BUILDINGID = b.BUILDINGID
    JOIN user u ON u.USERNAME = b.USERNAME
    WHERE u.USERNAME = p_username;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_floor`(IN p_buildingid VARCHAR(20))
BEGIN
    SELECT NUMOFFLOORS 
    FROM BUILDING 
    WHERE BUILDINGID = p_buildingid;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_roomid`(IN p_buildingid VARCHAR(20))
BEGIN
    SELECT ROOMID 
    FROM ROOM 
    WHERE BUILDINGID = p_buildingid;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_buildingid`(IN p_username VARCHAR(20))
BEGIN
    SELECT BUILDINGID 
    FROM BUILDING 
    WHERE USERNAME = p_username;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_addRoom`(
    IN p_buildingid VARCHAR(10),
    IN p_floor INT,
    IN p_type VARCHAR(50),
    IN p_convenient VARCHAR(200),
    IN p_area FLOAT,
    IN p_price FLOAT,
    IN p_status VARCHAR(50)
)
BEGIN
    DECLARE new_room_id VARCHAR(10);
	SET new_room_id = createRoomID(p_buildingid, p_floor);

    INSERT INTO ROOM (ROOMID, BUILDINGID, TYPE, FLOOR, CONVENIENT, AREA, PRICE, STATUS)
    VALUES (new_room_id, p_buildingid, p_type, p_floor, p_convenient, p_area, p_price, p_status);
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_updateRoom`(
	IN p_roomid VARCHAR(10),
    IN p_buildingid VARCHAR(10),
    IN p_floor INT,
    IN p_type VARCHAR(50),
    IN p_convenient VARCHAR(200),
    IN p_area FLOAT,
    IN p_price FLOAT,
    IN p_status VARCHAR(100)
)
BEGIN
    UPDATE ROOM 
SET BUILDINGID = p_buildingid,
    TYPE = p_type,
    FLOOR = p_floor,
    CONVENIENT = p_convenient,
    AREA = p_area,
    PRICE = p_price,
    STATUS = p_status
WHERE ROOMID = p_roomid;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `sp_DeleteRoom`(
    IN p_roomid VARCHAR(10),
    OUT p_result INT,
    OUT p_message VARCHAR(255))
BEGIN
    DECLARE room_exists INT;
    
    -- Kiểm tra xem phòng có tồn tại không
    SELECT COUNT(*) INTO room_exists FROM Room WHERE RoomID = p_roomid;
    
    IF room_exists = 0 THEN
        SET p_result = 0;
        SET p_message = 'Phòng không tồn tại';
    ELSE
        -- Xóa phòng (với ON DELETE CASCADE, các bản ghi liên quan sẽ tự động xóa)
        DELETE FROM Room WHERE RoomID = p_roomid;
        
        SET p_result = 1;
        SET p_message = CONCAT('Đã xóa phòng ', p_roomid, ' thành công');
    END IF;
END//

CREATE PROCEDURE `sp_DeleteAssets`(
    IN p_assetid VARCHAR(10),
    OUT p_result INT
)
BEGIN
    -- Xóa tài sản (các bản ghi liên quan trong MAINTENANCE và REPAIR_REQUEST sẽ tự động xóa nhờ ON DELETE CASCADE)
    DELETE FROM ASSETS WHERE ASSETID = p_assetid;
    
    -- Kiểm tra số dòng bị ảnh hưởng
    IF ROW_COUNT() > 0 THEN
        SET p_result = 1; -- Thành công
    ELSE
        SET p_result = 0; -- Không có tài sản nào bị xóa
    END IF;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `filter_room`(
    IN p_username VARCHAR(50),
    IN p_status_list VARCHAR(1000)
)
BEGIN
        -- Tạo bảng tạm lưu trạng thái
        CREATE TEMPORARY TABLE IF NOT EXISTS temp_statuses (
            status_value VARCHAR(100)
        );
        TRUNCATE TABLE temp_statuses;
        
        -- Chèn các trạng thái vào bảng tạm
        SET @sql = CONCAT('INSERT INTO temp_statuses VALUES ("', 
                         REPLACE(p_status_list, '; ', '"),("'), '")');
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
        
        -- Đếm tổng số trạng thái cần kiểm tra
        SET @total_statuses = (SELECT COUNT(*) FROM temp_statuses);
        
        -- Lọc phòng phải chứa TẤT CẢ trạng thái được chọn
        SELECT r.*
        FROM ROOM r
        JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
        WHERE b.USERNAME = p_username
        AND (
            SELECT COUNT(*) 
            FROM temp_statuses ts 
            WHERE r.STATUS LIKE CONCAT('%', ts.status_value, '%')
        ) = @total_statuses;
        
        DROP TEMPORARY TABLE IF EXISTS temp_statuses;
END//

CREATE PROCEDURE `load_RentalHistory`(
    IN p_username VARCHAR(50))
BEGIN
    SELECT 
        rh.ROOMID,
        rh.OLDTENANTID,
        rh.ADDRESS,
        rh.TYPE,
        rh.CONVENIENT,
        rh.AREA,
        rh.PRICE,
        rh.STATUS,
        rh.FIRSTNAME,
        rh.LASTNAME,
        rh.GENDER,
        rh.PHONENUMBER,
        rh.STARTDATE,
        rh.ENDDATE,
        rh.REASON_FOR_LEAVING,
        b.BUILDINGID
    FROM RENTALHISTORY rh
    JOIN ROOM r ON rh.ROOMID = r.ROOMID
    JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE b.USERNAME = p_username
    ORDER BY rh.ENDDATE DESC;
END//
