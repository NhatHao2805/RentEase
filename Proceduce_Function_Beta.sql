delimiter //
DROP FUNCTION IF EXISTS createBillID//
DROP FUNCTION IF EXISTS createFigureID//
DROP FUNCTION IF EXISTS createPaymentID//
DROP FUNCTION IF EXISTS createParkingAreaID//

DROP PROCEDURE IF EXISTS auto_AddTenantHistory//
DROP PROCEDURE IF EXISTS load_outdateContract//
DROP PROCEDURE IF EXISTS update_tenantHistory//
DROP PROCEDURE IF EXISTS load_allTH//
DROP PROCEDURE IF EXISTS load_lstn//
DROP PROCEDURE IF EXISTS load_bill//
DROP PROCEDURE IF EXISTS load_billdetail//
DROP PROCEDURE IF EXISTS add_w_e//
DROP PROCEDURE IF EXISTS load_W_E//
DROP PROCEDURE IF EXISTS del_W_E//
DROP PROCEDURE IF EXISTS del_bill//
DROP PROCEDURE IF EXISTS load_payment//
DROP PROCEDURE IF EXISTS load_Area//
DROP PROCEDURE IF EXISTS load_Vehicle//
DROP PROCEDURE IF EXISTS proc_addVehicle//
DROP PROCEDURE IF EXISTS proc_updateVehicle//
DROP PROCEDURE IF EXISTS sp_DeleteVehicle//

DROP TRIGGER IF EXISTS before_del_Bill//
DROP TRIGGER IF EXISTS before_del_Billdetail//
DROP TRIGGER IF EXISTS after_add_W_E//


CREATE PROCEDURE add_w_e(
    IN p_buildingid VARCHAR(50),
    IN p_o_w VARCHAR(50),  -- Chỉ số nước cũ
    IN p_n_w VARCHAR(50),  -- Chỉ số nước mới
    IN p_o_e VARCHAR(50),  -- Chỉ số điện cũ
    IN p_n_e VARCHAR(50),  -- Chỉ số điện mới
    IN p_month VARCHAR(50) -- Tháng (1-12)
)
BEGIN
   DECLARE new_ID VARCHAR(50);
   DECLARE new_ID_0 VARCHAR(50);
   DECLARE p_tenantID VARCHAR(50);
   DECLARE v_start_date VARCHAR(50);
   DECLARE v_end_date VARCHAR(50);
	DECLARE v_now VARCHAR(50);
	DECLARE new_id_2 VARCHAR(20);
   DECLARE v_total FLOAT;  -- Thay đổi kiểu dữ liệu
   DECLARE v_startdate VARCHAR(50);       -- Sửa thành DATE
   DECLARE v_enddate VARCHAR(50);         -- Sửa thành DATE
   
		SET p_tenantID = (
			SELECT t.TENANTID FROM tenant t
			JOIN contract c ON c.TENANTID = t.TENANTID
			JOIN room r ON r.ROOMID = c.ROOMID
			JOIN building b ON b.BUILDINGID = r.BUILDINGID
			WHERE b.BUILDINGID = p_buildingid
			LIMIT 1);
    SET v_start_date = STR_TO_DATE(CONCAT('1/', p_month, '/', YEAR(CURDATE())), '%d/%m/%Y');
    SET v_end_date = LAST_DAY(v_start_date);
    SET v_now = Date(NOW());
    SET new_ID = createFigureID();
    
    INSERT INTO WATER_ELECTRICITY (FIGUREID, UNITPRICEID, TENANTID, OLDFIGURE, NEWFIGURE, START_DATE, END_DATE,RECORD_DATE,TYPE,UNIT)
    VALUES (new_ID, 'UP001',p_tenantID,p_o_e,  p_n_e, v_start_date,v_end_date,v_now,'ELECTRICITY','kWh');
    
    -- Thêm dữ liệu nước
    SET new_ID_0 = createFigureID();
    INSERT INTO WATER_ELECTRICITY (FIGUREID, UNITPRICEID, TENANTID, OLDFIGURE, NEWFIGURE, START_DATE, END_DATE,RECORD_DATE,TYPE,UNIT)
    VALUES (new_ID_0, 'UP002',  p_tenantID,  p_o_w, p_n_w, v_start_date, v_end_date,v_now,'WATER','m3');

   SET new_id_2 = createBillID();

   -- Sửa @new_id thành new_id
   INSERT INTO billdetail (BILLID, ID, AMOUNT)
   SELECT new_id_2, us.SERVICEID, s.UNITPRICE 
   FROM use_service us
   JOIN service s ON s.SERVICEID = us.SERVICEID
   WHERE us.TENANTID = p_tenantID;
   
   INSERT INTO billdetail (BILLID, ID, AMOUNT)
   SELECT new_id_2, we.FIGUREID,weu.UNITPRICE
   FROM water_electricity we
   JOIN water_elec_unitprice weu ON weu.UNITPRICEID = we.UNITPRICEID
   WHERE we.TENANTID = p_tenantID
	AND (we.FIGUREID = new_ID_0 OR we.FIGUREID = new_ID);
   
   SELECT SUM(AMOUNT) INTO v_total
   FROM billdetail
   WHERE BILLID = new_id_2;

   SET v_startdate = CURDATE();    -- Bỏ hàm Date() thừa
   SET v_enddate = DATE_ADD(CURDATE(), INTERVAL 30 DAY);
    
   INSERT INTO bill (BILLID, TENANTID, TOTAL, START_DATE, END_DATE)
   VALUES (new_id_2, p_tenantID, v_total, v_startdate, v_enddate);	
END //

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createPaymentID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(p.PAYMENTID), 'TT000') INTO max_id FROM Payment p;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('TT', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE load_payment(
	IN p_buildingID VARCHAR(20),
	IN p_tenantid VARCHAR(20),
	IN p_lastname VARCHAR(50)
)
BEGIN
   SELECT p.PAYMENTID,t.TENANTID,t.FIRSTNAME,t.LASTNAME,p.BILLID,p.METHOD,p.TOTAL, Date(p.PAYMENTTIME) AS 'PAYMENT_TIME'  FROM payment p 
   JOIN bill bi ON bi.BILLID = p.BILLID
	JOIN tenant t ON t.TENANTID = bi.TENANTID
   JOIN contract c ON c.TENANTID = t.TENANTID
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building b ON b.BUILDINGID = r.BUILDINGID

   WHERE b.BUILDINGID = p_buildingID
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND (p_tenantid IS NULL OR t.TENANTID = p_tenantid);
END//


CREATE TRIGGER before_del_Bill
BEFORE DELETE ON bill
 FOR EACH ROW
BEGIN
    DELETE FROM payment  
   WHERE BILLID = OLD.BILLID;    
 DELETE FROM billdetail  
	 WHERE BILLID = OLD.BILLID;   
END//

CREATE TRIGGER before_del_Billdetail
BEFORE DELETE ON billdetail
FOR EACH ROW
BEGIN
   DELETE FROM water_electricity  
    WHERE water_electricity.FIGUREID = OLD.ID;       
END//

CREATE PROCEDURE del_bill(
    IN p_BillID VARCHAR(50)
)
BEGIN 	
    DELETE FROM bill  
    WHERE bill.BILLID = p_BillID;     
END//

CREATE PROCEDURE del_W_E(
    IN p_tenantID VARCHAR(50),
    IN p_startdate DATE ,
    IN p_enddate DATE
)
BEGIN 
    DECLARE v_deleted_rows INT;
    
    DELETE FROM water_electricity 
    WHERE TENANTID = p_tenantID
    AND START_DATE = STR_TO_DATE(p_startdate, '%Y-%m-%d')
    AND END_DATE = STR_TO_DATE(p_enddate, '%Y-%m-%d');
    
    SET v_deleted_rows = ROW_COUNT();
    
    SELECT CONCAT(v_deleted_rows, ' bản ghi đã được xóa') AS result;
END//

CREATE PROCEDURE load_W_E(
	IN p_user VARCHAR(20),
	IN p_buildingid VARCHAR(50)
)
BEGIN
   SELECT we.* FROM water_electricity we
	JOIN tenant t ON t.TENANTID = we.TENANTID
	JOIN contract c ON c.TENANTID = t.TENANTID
	JOIN room r ON r.ROOMID = c.ROOMID
	JOIN building b ON b.BUILDINGID = r.BUILDINGID
	WHERE b.BUILDINGID = p_buildingid
	AND t.USERNAME =  p_user;
END //



CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createFigureID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(we.FIGUREID), 'CS000') INTO max_id FROM water_electricity we;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('CS', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//



CREATE PROCEDURE load_billdetail(
	IN p_billID VARCHAR(20)
)
BEGIN
   SELECT bd.BILLID,bd.ID,s.SERVICENAME,bd.AMOUNT FROM billdetail bd 
   JOIN service s ON s.SERVICEID = bd.ID
   WHERE bd.BILLID = p_billID
	union
	SELECT bd.BILLID,bd.ID,
	CASE 
        WHEN w.`TYPE` = 'WATER' THEN 'Nước'
        WHEN w.`TYPE` = 'ELECTRICITY' THEN 'Điện'
        ELSE w.`TYPE`
   END,bd.AMOUNT FROM billdetail bd 
   JOIN water_electricity w ON w.FIGUREID = bd.ID
	WHERE bd.BILLID = p_billID;
END//

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createBillID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(b.BILLID), 'HD000') INTO max_id FROM bill b;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('HD', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE load_bill(
	IN p_user VARCHAR(20),
	IN p_lastname VARCHAR(20),
	IN p_buildingid VARCHAR(20)
)
BEGIN
   SELECT b.BILLID,b.TENANTID,t.FIRSTNAME,t.LASTNAME,b.TOTAL,b.START_DATE,b.END_DATE,COALESCE(p.TOTAL,0) AS 'TOTALS' FROM bill b
   JOIN tenant t ON t.TENANTID = b.TENANTID
   LEFT JOIN payment p ON p.BILLID = b.BILLID
   JOIN contract c ON c.TENANTID = t.TENANTID
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building bu ON bu.BUILDINGID = r.BUILDINGID
   WHERE t.USERNAME = p_user
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND bu.BUILDINGID = p_buildingid;
	
END //


CREATE PROCEDURE load_allTH(
	IN p_lastname VARCHAR(20)
)
BEGIN
   SELECT th.ROOMID, th.TENANTID,t.FIRSTNAME,t.LASTNAME,th.NOTES FROM tenant_history th
	JOIN tenant t ON t.TENANTID = th.TENANTID
	WHERE (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	LIMIT 100;
END //


CREATE PROCEDURE update_tenantHistory(
	IN p_tenantHistoruid VARCHAR(20),
	IN p_note VARCHAR(20)
)
BEGIN
   UPDATE tenant_history t set
   t.NOTES = p_note
   WHERE t.HISTORYID = p_tenantHistoruid;
   
END //


CREATE PROCEDURE load_outdateContract(
	IN p_buildingid VARCHAR(20)
)
BEGIN
   SELECT c.* 
	FROM contract c
	JOIN room r ON r.ROOMID = c.ROOMID
	JOIN building b ON b.BUILDINGID = r.BUILDINGID
	WHERE c.ENDDATE < CURRENT_DATE()
	AND NOT EXISTS (
   SELECT 1 
   FROM tenant_history th 
   WHERE th.CONTRACTID = c.CONTRACTID)
	AND b.BUILDINGID = p_buildingid;
END //

CREATE PROCEDURE auto_AddTenantHistory(
    IN p_CONTRACTID VARCHAR(50),
    IN p_TENANTID VARCHAR(50),
    IN p_ROOMID VARCHAR(50),
    IN p_STARTDATE DATETIME,
    IN p_ENDDATE DATETIME
)
BEGIN
    DECLARE new_HISTORYID VARCHAR(50);
    SET new_HISTORYID = createTenantHistorytID();

    INSERT INTO tenant_history (
        HISTORYID,
        CONTRACTID,
        TENANTID,
        ROOMID,
        STARTDATE,
        ENDDATE
    )
    VALUES (
        new_HISTORYID,
        p_CONTRACTID,
        p_TENANTID,
        p_ROOMID,
        p_STARTDATE,
        p_ENDDATE
    );
    
END //

-- sửa hàm
CREATE PROCEDURE load_lstn(
	IN p_buildingID VARCHAR(50),
	IN p_lastname VARCHAR(20)
)
BEGIN 
	SELECT th.HISTORYID,th.CONTRACTID,th.TENANTID,t.FIRSTNAME,t.LASTNAME,th.STARTDATE,th.ENDDATE,th.NOTES FROM tenant_history th
	JOIN room r ON r.ROOMID = th.ROOMID
	JOIN building b ON b.BUILDINGID = r.BUILDINGID
	JOIN tenant t ON t.TENANTID = th.TENANTID
	WHERE b.BUILDINGID = p_buildingID
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'));
END//

-- New 8/4/2025
CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createParkingAreaID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE new_key VARCHAR(10);
	DECLARE max_key INT;
    
   -- Lấy giá trị lớn nhất hiện có trong bảng (giả sử bảng có tên là 'your_table' và cột khóa chính là 'id')
    SELECT COALESCE(MAX(CAST(SUBSTRING(AREAID, 3) AS UNSIGNED)), 0) INTO max_key FROM PARKINGAREA;

    -- Tăng giá trị lên 1
    SET max_key = max_key + 1;

    -- Tạo khóa mới với định dạng PA + 4 số
    SET new_key = CONCAT('PA', LPAD(max_key, 4, '0'));

    RETURN new_key;
END//

CREATE PROCEDURE proc_addParkingArea(
    IN p_buildingid VARCHAR(20),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT
)
BEGIN
    DECLARE new_area_id VARCHAR(20);
    
    -- Tạo ID mới cho bãi đậu xe
    SET new_area_id = createParkingAreaID();
    
    -- Thêm bãi đậu xe mới
    INSERT INTO PARKINGAREA (
        AREAID,
        BUILDINGID,
        ADDRESS,
        TYPE,
        CAPACITY
    ) VALUES (
        new_area_id,
        p_buildingid,
        p_address,
        p_type,
        p_capacity
    );
    
END//

CREATE PROCEDURE proc_updateParkingArea(
	IN p_areaid VARCHAR(20),
    IN p_buildingid VARCHAR(20),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT
)
BEGIN
    UPDATE PARKINGAREA
    SET 
        BUILDINGID = p_buildingid,
        ADDRESS = p_address,
        TYPE = p_type,
        CAPACITY = p_capacity
    WHERE AREAID = p_areaid;
    
END//

CREATE PROCEDURE sp_DeleteParkingArea(
    IN p_areaid VARCHAR(20),
    OUT p_result INT,
    OUT p_message VARCHAR(255))
BEGIN
    DECLARE v_count INT;
    
    -- Kiểm tra xem bãi đậu xe có tồn tại không
    SELECT COUNT(*) INTO v_count
    FROM PARKINGAREA
    WHERE AREAID = p_areaid;
    
    IF v_count > 0 THEN
        -- Xóa bãi đậu xe
        DELETE FROM PARKINGAREA
        WHERE AREAID = p_areaid;
        
        SET p_result = 1;
        SET p_message = 'Bãi đậu xe đã được xóa thành công';
    ELSE
        SET p_result = 0;
        SET p_message = 'Không tìm thấy bãi đậu xe';
    END IF;
END//

CREATE PROCEDURE proc_addAsset(
    IN p_buildingid VARCHAR(20),
    IN p_roomid VARCHAR(20),
    IN p_assetname VARCHAR(50),
    IN p_price FLOAT,
    IN p_status VARCHAR(50),
    IN p_usedate DATE
)
BEGIN
    DECLARE new_asset_id VARCHAR(20);
    
    -- Kiểm tra xem phòng có thuộc tòa nhà không
    IF EXISTS (
        SELECT 1 FROM ROOM r
        WHERE r.ROOMID = p_roomid
        AND r.BUILDINGID = p_buildingid
    ) THEN
        -- Tạo ID mới cho tài sản
        SET new_asset_id = createAssetID();
        
        -- Thêm tài sản mới
        INSERT INTO ASSETS (
            ASSETID,
            ROOMID,
            ASSETNAME,
            PRICE,
            STATUS,
            USE_DATE
        ) VALUES (
            new_asset_id,
            p_roomid,
            p_assetname,
            p_price,
            p_status,
            p_usedate
        );
    ELSE
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Phòng không thuộc tòa nhà được chỉ định';
    END IF;
END//

CREATE PROCEDURE sp_FilterVehicle(
    IN p_buildingid VARCHAR(20),
    IN p_vehicle_type VARCHAR(50)
)
BEGIN
    -- Truy vấn chính với các JOIN cần thiết
    SELECT 
        v.VEHICLEID,
        v.TENANTID,
        t.FIRSTNAME,
        t.LASTNAME,
        v.VEHICLE_UNITPRICE_ID,
        vup.UNITPRICE,
        v.TYPE,
        v.LICENSEPLATE,
        p.PARKINGID,
        p.STATUS
    FROM VEHICLE v
    INNER JOIN TENANT t ON v.TENANTID = t.TENANTID
    INNER JOIN VEHICLE_UNITPRICE vup ON v.VEHICLE_UNITPRICE_ID = vup.VEHICLE_UNITPRICE_ID
    INNER JOIN PARKING p ON v.VEHICLEID = p.VEHICLEID
    INNER JOIN PARKINGAREA pa ON p.AREAID = pa.AREAID
    WHERE (p_buildingid IS NULL OR pa.BUILDINGID = p_buildingid)  -- Lọc theo mã tòa nhà
    AND (p_vehicle_type IS NULL OR v.TYPE = p_vehicle_type);  -- Lọc theo loại phương tiện
END //

CREATE DEFINER=`root`@`localhost` FUNCTION `createVehicleID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE new_key VARCHAR(10);
	DECLARE max_key INT;
    
   -- Lấy giá trị lớn nhất hiện có trong bảng (giả sử bảng có tên là 'your_table' và cột khóa chính là 'id')
    SELECT COALESCE(MAX(CAST(SUBSTRING(VEHICLEID, 2) AS UNSIGNED)), 0) INTO max_key FROM VEHICLE;

    -- Tăng giá trị lên 1
    SET max_key = max_key + 1;

    -- Tạo khóa mới với định dạng PA + 4 số
    SET new_key = CONCAT('V', LPAD(max_key, 4, '0'));

    RETURN new_key;
END//

CREATE PROCEDURE proc_addVehicle(
    IN p_tenantid VARCHAR(20),
    IN p_vehicle_unitprice_id VARCHAR(20),
    IN p_type VARCHAR(50),
    IN p_licenseplate VARCHAR(20),
    IN p_areaid VARCHAR(10)  -- Thay đổi tham số thành AREAID
)
BEGIN
    DECLARE p_new_vehicle_id VARCHAR(20);
    
    -- Tạo ID mới cho phương tiện
    SET p_new_vehicle_id = createVehicleID();
    
    -- Kiểm tra xem bãi xe có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaid) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No parking area found for the specified area ID';
    END IF;

    -- Thêm phương tiện mới vào bảng VEHICLE
    INSERT INTO VEHICLE (
        VEHICLEID,
        TENANTID,
        VEHICLE_UNITPRICE_ID,
        TYPE,
        LICENSEPLATE
    ) VALUES (
        p_new_vehicle_id,
        p_tenantid,
        p_vehicle_unitprice_id,
        p_type,
        p_licenseplate
    );

    -- Cập nhật bảng PARKING để thêm ID phương tiện vào chỗ đậu xe có giá trị NULL
    UPDATE PARKING
    SET VEHICLEID = p_new_vehicle_id
    WHERE AREAID = p_areaid AND VEHICLEID IS NULL
    LIMIT 1;  -- Chỉ cập nhật một bản ghi đầu tiên có giá trị NULL
END //
-- New 12/4
CREATE PROCEDURE proc_updateVehicle(
    IN p_vehicleid VARCHAR(20),
    IN p_tenantid VARCHAR(20),
    IN p_vehicle_unitprice_id VARCHAR(20),
    IN p_type VARCHAR(50),
    IN p_licenseplate VARCHAR(20),
    IN p_areaid VARCHAR(20)
)
BEGIN
    UPDATE VEHICLE
    SET 
        TENANTID = p_tenantid,
        VEHICLE_UNITPRICE_ID = p_vehicle_unitprice_id,
        TYPE = p_type,
        LICENSEPLATE = p_licenseplate
    WHERE VEHICLEID = p_vehicleid;
    
    IF NOT EXISTS (SELECT 1 FROM PARKING WHERE AREAID = p_areaid AND VEHICLEID = p_vehicleid) THEN
		UPDATE PARKING
        SET
			AREAID = p_areaid
		WHERE VEHICLEID = p_vehicleid;
	END IF;
END//

CREATE PROCEDURE sp_DeleteVehicle(
    IN p_vehicleid VARCHAR(20),
    OUT p_result INT,
    OUT p_message VARCHAR(255)
)
BEGIN
    DECLARE v_count INT;
    
    -- Kiểm tra xem phương tiện có tồn tại không
    SELECT COUNT(*) INTO v_count
    FROM VEHICLE
    WHERE VEHICLEID = p_vehicleid;
    
    IF v_count > 0 THEN
        -- Xóa phương tiện
        DELETE FROM VEHICLE
        WHERE VEHICLEID = p_vehicleid;
        
        SET p_result = 1;
        SET p_message = 'Phương tiện đã được xóa thành công';
    ELSE
        SET p_result = 0;
        SET p_message = 'Không tìm thấy phương tiện';
    END IF;
END//

CREATE PROCEDURE sp_GetVehicleUnitPriceByType(
    IN p_type VARCHAR(50)
)  
BEGIN
    SELECT 
        vup.VEHICLE_UNITPRICE_ID,
        vup.UNITPRICE
    FROM VEHICLE_UNITPRICE vup
    WHERE vup.TYPE = p_type;
END//

CREATE PROCEDURE sp_FilterParkingArea(
    IN p_buildingid VARCHAR(20),
    IN p_type VARCHAR(50),
    IN p_status VARCHAR(50)
)
BEGIN
    SELECT * FROM (
        SELECT 
            pa.AREAID,
            pa.BUILDINGID,
            pa.ADDRESS,
            pa.TYPE,
            pa.CAPACITY,
            COUNT(p.VEHICLEID) as CURRENT_VEHICLES,
            CASE 
                WHEN COUNT(p.VEHICLEID) >= pa.CAPACITY THEN 'FULL'
                ELSE 'EMPTY'
            END as STATUS
        FROM PARKINGAREA pa
        LEFT JOIN PARKING p ON pa.AREAID = p.AREAID
        GROUP BY pa.AREAID, pa.BUILDINGID, pa.ADDRESS, pa.TYPE, pa.CAPACITY
    ) AS temp
    WHERE 
        (p_buildingid IS NULL OR BUILDINGID = p_buildingid)
        AND (p_type IS NULL OR TYPE = p_type)
        AND (
            (p_status = 'EMPTY' AND CURRENT_VEHICLES < CAPACITY) OR
            (p_status = 'FULL' AND CURRENT_VEHICLES >= CAPACITY) OR
            p_status IS NULL
        );
END//

CREATE FUNCTION generate_parking_id()
RETURNS VARCHAR(10)
BEGIN
    DECLARE new_id VARCHAR(10);
    DECLARE max_id INT;

    -- Lấy giá trị lớn nhất hiện có trong bảng PARKING
    SELECT COALESCE(MAX(CAST(SUBSTRING(PARKINGID, 2) AS UNSIGNED)), 0) INTO max_id FROM PARKING;

    -- Tăng giá trị lên 1
    SET max_id = max_id + 1;

    -- Tạo mã mới với định dạng P + 4 số
    SET new_id = CONCAT('P', LPAD(max_id, 4, '0'));

    RETURN new_id;
END //

CREATE TRIGGER after_insert_parkingarea
AFTER INSERT ON PARKINGAREA
FOR EACH ROW
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE new_parking_id VARCHAR(10);

    WHILE i < NEW.CAPACITY DO
        SET new_parking_id = generate_parking_id();

        INSERT INTO PARKING (PARKINGID, AREAID, VEHICLEID, STATUS)
        VALUES (new_parking_id, NEW.AREAID, NULL, 'Đang sử dụng');

        SET i = i + 1;
    END WHILE;
END //

DELIMITER ;