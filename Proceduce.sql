DELIMITER //

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
        a.USE_DATE
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

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_addAsset`(
    IN p_roomid VARCHAR(10),
    IN p_assetname VARCHAR(50),
    IN p_price FLOAT,
    IN p_status VARCHAR(50),
    IN p_usedate DATE
)
BEGIN
    DECLARE new_asset_id VARCHAR(10);
    
    -- Tạo ID tài sản mới (giả sử có hàm createAssetID tương tự như createRoomID)
    SET new_asset_id = createAssetID();
    
    -- Thêm tài sản vào bảng ASSETS
    INSERT INTO ASSETS (ASSETID, ROOMID, ASSETNAME, PRICE, STATUS, USE_DATE)
    VALUES (new_asset_id, p_roomid, p_assetname, p_price, p_status, p_usedate);
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `proc_updateAsset`(
    IN p_assetid VARCHAR(10),
    IN p_roomid VARCHAR(10),
    IN p_assetname VARCHAR(50),
    IN p_price FLOAT,
    IN p_status VARCHAR(50),
    IN p_usedate DATE
)
BEGIN
    UPDATE ASSETS 
    SET 
        ROOMID = p_roomid,
        ASSETNAME = p_assetname,
        PRICE = p_price,
        STATUS = p_status,
        USE_DATE = p_usedate
    WHERE 
        ASSETID = p_assetid;
END//


CREATE PROCEDURE `sp_DeleteAssets`(
    IN p_assetid VARCHAR(10),
    OUT p_result INT,
    OUT p_message VARCHAR(255))
BEGIN
    DECLARE asset_exists INT;
    
    -- Kiểm tra xem tài sản có tồn tại không
    SELECT COUNT(*) INTO asset_exists FROM ASSETS WHERE ASSETID = p_assetid;
    
    IF asset_exists = 0 THEN
        SET p_result = 0;
        SET p_message = 'Tài sản không tồn tại';
    ELSE
        -- Xóa tài sản (các bản ghi liên quan trong MAINTENANCE và REPAIR_REQUEST sẽ tự động xóa nhờ ON DELETE CASCADE)
        DELETE FROM ASSETS WHERE ASSETID = p_assetid;
        
        SET p_result = 1;
        SET p_message = CONCAT('Đã xóa tài sản ', p_assetid, ' thành công');
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

DELIMITER //

CREATE PROCEDURE `load_RentalHistory`(
    IN p_username VARCHAR(50))
BEGIN
    SELECT 
        rh.CONTRACTID,
        rh.ROOMID,
        t.TENANTID,
        t.FIRSTNAME,
        t.LASTNAME,
        t.GENDER,
        t.PHONENUMBER,
        r.TYPE,
        r.CONVENIENT,
        r.AREA,
        r.PRICE,
        r.STATUS,
        rh.STARTDATE,
        rh.ENDDATE,
        rh.REASON_FOR_LEAVING,
        r.BUILDINGID
    FROM 
        RENTAL_HISTORY rh
    JOIN 
        TENANT t ON rh.TENANTID = t.TENANTID
    JOIN 
        ROOM r ON rh.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE 
        b.USERNAME = p_username
    ORDER BY 
        rh.ENDDATE DESC;
END//


CREATE PROCEDURE `sp_AssetDetails`(
    IN p_assetid VARCHAR(10))
BEGIN
    -- Thông tin cơ bản của tài sản
    SELECT 
        a.ASSETID,
        a.ASSETNAME,
        a.PRICE,
        a.STATUS,
        a.USE_DATE,
        -- Thông tin phòng chứa tài sản
        r.ROOMID,
        r.TYPE AS ROOM_TYPE,
        r.FLOOR,
        r.PRICE AS ROOM_PRICE,
        r.STATUS AS ROOM_STATUS,
        b.BUILDINGID,
        b.ADDRESS AS BUILDING_ADDRESS
    FROM 
        ASSETS a
    JOIN 
        ROOM r ON a.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE 
        a.ASSETID = p_assetid;
    
    -- Lịch sử bảo trì
    SELECT 
        m.MAINTENANCEID,
        m.MAINTENANCE_DATE,
        m.DESCRIPTION,
        m.STATUS
    FROM 
        MAINTENANCE m
    WHERE 
        m.ASSETID = p_assetid
    ORDER BY 
        m.MAINTENANCE_DATE DESC;
    
    -- Yêu cầu sửa chữa
    SELECT 
        rr.REQUESTID,
        rr.REQUEST_DATE,
        rr.DESCRIPTION,
        rr.STATUS,
        t.TENANTID,
        CONCAT(t.FIRSTNAME, ' ', t.LASTNAME) AS TENANT_NAME,
        t.PHONENUMBER
    FROM 
        REPAIR_REQUEST rr
    JOIN 
        TENANT t ON rr.TENANTID = t.TENANTID
    WHERE 
        rr.ASSETID = p_assetid
    ORDER BY 
        rr.REQUEST_DATE DESC;
END//
