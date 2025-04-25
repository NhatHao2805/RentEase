DELIMITER //

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
    IN p_tenantid VARCHAR(50),
    IN p_o_w VARCHAR(50),  -- Chỉ số nước cũ
    IN p_n_w VARCHAR(50),  -- Chỉ số nước mới
    IN p_o_e VARCHAR(50),  -- Chỉ số điện cũ
    IN p_n_e VARCHAR(50),  -- Chỉ số điện mới
    IN p_month VARCHAR(50) -- Tháng (1-12)
)
BEGIN
   DECLARE new_ID VARCHAR(50);-- Id điện 
   DECLARE new_ID_0 VARCHAR(50);-- Id nước 
   
   DECLARE v_start_date VARCHAR(50);-- ngày bắt đầu thanh toán
   DECLARE v_end_date VARCHAR(50);-- ngày kết thúc thanh toán
	DECLARE v_now VARCHAR(50);-- Ngày tạo hóa đơn
	DECLARE new_id_2 VARCHAR(20);-- Id bill
    
   DECLARE v_total VARCHAR(20);  -- Tổng tiền add vào bill     
   
   DECLARE billdt_id_1 VARCHAR(20);
   DECLARE billdt_id_2 VARCHAR(20);
    
    SET v_start_date = STR_TO_DATE(CONCAT('1/', p_month, '/', YEAR(CURDATE())), '%d/%m/%Y');
    SET v_end_date = LAST_DAY(v_start_date);
    SET v_now = Date(NOW());
    
    SET new_ID = createFigureID();
    INSERT INTO WATER_ELECTRICITY (FIGUREID, UNITPRICEID, TENANTID, OLDFIGURE, NEWFIGURE, START_DATE, END_DATE,RECORD_DATE,TYPE,UNIT)
    VALUES (new_ID, 'UP001',p_tenantID,p_o_e,  p_n_e, v_start_date,v_end_date,v_now,'ELECTRICITY','kWh');
    
    SET new_ID_0 = createFigureID();
    INSERT INTO WATER_ELECTRICITY (FIGUREID, UNITPRICEID, TENANTID, OLDFIGURE, NEWFIGURE, START_DATE, END_DATE,RECORD_DATE,TYPE,UNIT)
    VALUES (new_ID_0, 'UP002',  p_tenantID,  p_o_w, p_n_w, v_start_date, v_end_date,v_now,'WATER','m3');

   SET new_id_2 = createBillID();

	set billdt_id_1 = createBillDetailID();
   INSERT INTO billdetail (BILLDETAIL_ID,BILLID, ID, AMOUNT)
   SELECT billdt_id_1,new_id_2, us.SERVICEID, s.UNITPRICE 
   FROM use_service us
   JOIN service s ON s.SERVICEID = us.SERVICEID
   WHERE us.TENANTID = p_tenantid
   AND s.ISDELETED = 0
   AND us.ISDELETED = 0;
   
   set billdt_id_2 = createBillDetailID();
   INSERT INTO billdetail (BILLDETAIL_ID, BILLID, ID, AMOUNT)
   SELECT billdt_id_2,new_id_2, we.FIGUREID,weu.UNITPRICE
   FROM water_electricity we
   JOIN WATER_ELECT_UNITPRICE weu ON weu.UNITPRICEID = we.UNITPRICEID
   WHERE we.TENANTID = p_tenantid
	AND (we.FIGUREID = new_ID_0 OR we.FIGUREID = new_ID)
    AND we.ISDELETED = 0;
   
   SELECT SUM(AMOUNT) INTO v_total
   FROM billdetail
   WHERE BILLID = new_id_2;
    
   INSERT INTO bill (BILLID, TENANTID, TOTAL, START_DATE, END_DATE)
   VALUES (new_id_2, p_tenantID, v_total, v_start_date, v_end_date);	
END //
CREATE PROCEDURE add_key(
    p_usern VARCHAR(20),
    p_key VARCHAR(20)
)
BEGIN
    INSERT INTO keyManager (usern, keybuilding)
    VALUES (p_usern, p_key);
END//

CREATE PROCEDURE reload_key()
BEGIN
    DELETE km FROM keyManager km
    LEFT JOIN building b ON km.keybuilding = b.BUILDING_KEY
    WHERE b.BUILDING_KEY IS NULL;
END//

CREATE PROCEDURE load_building_by_key(
	p_usern varchar(20)
)
BEGIN
    SELECT BUILDINGID, BUILDING_KEY  FROM building
    WHERE BUILDING_KEY IN (
        SELECT keybuilding FROM keyManager
        where usern = p_usern
    );
END//


CREATE PROCEDURE GetExpiringEmails(IN p_buildingID VARCHAR(10))
BEGIN
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;
    
    SELECT 
        t.EMAIL
    FROM contract c
    JOIN tenant t ON c.TENANTID = t.TENANTID
    JOIN room r ON c.ROOMID = r.ROOMID
    WHERE 
        DATEDIFF(c.ENDDATE, CURDATE()) BETWEEN 0 AND 4
        AND r.BUILDINGID = p_buildingID
        AND t.ISDELETED = 0
        AND r.ISDELETED = 0;
END//


-- TENANT HISTORY
CREATE FUNCTION createTenantHistorytID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(tenant_history.HISTORYID), 'LS000') INTO max_id FROM tenant_history;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('LS', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE load_allTH(
	IN p_lastname VARCHAR(20)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM tenant_history 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT th.ROOMID, th.TENANTID,t.FIRSTNAME,t.LASTNAME,th.NOTES FROM tenant_history th
	JOIN tenant t ON t.TENANTID = th.TENANTID
	WHERE (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND t.ISDELETED = 0
	AND th.ISDELETED = 0
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

CREATE PROCEDURE auto_AddTenantHistory(
    IN p_CONTRACTID VARCHAR(50),
    IN p_TENANTID VARCHAR(50),
    IN p_ROOMID VARCHAR(50),
    IN p_STARTDATE DATETIME,
    IN p_ENDDATE DATETIME,
    IN p_buildingid VARCHAR(10)
)
BEGIN
    DECLARE new_HISTORYID VARCHAR(50);
    DECLARE room_id VARCHAR(10);
    SET new_HISTORYID = createTenantHistorytID();

	SELECT ROOMID INTO room_id FROM ROOM WHERE BUILDINGID = p_buildingid AND ROOMNAME = p_ROOMID;

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
        room_id,
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
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

	SELECT th.HISTORYID,th.CONTRACTID,th.TENANTID,t.FIRSTNAME,t.LASTNAME,th.STARTDATE,th.ENDDATE,th.NOTES FROM tenant_history th
	JOIN room r ON r.ROOMID = th.ROOMID
	JOIN building b ON b.BUILDINGID = r.BUILDINGID
	JOIN tenant t ON t.TENANTID = th.TENANTID
	WHERE b.BUILDINGID = p_buildingID
	AND t.ISDELETED = 0
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'));
END//



CREATE FUNCTION createBillDetailID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(BILLDETAIL_ID), 'BD000') INTO max_id FROM billdetail;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('BD', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

-- PAYMENT-BILL-W-E
-- CREATE PROCEDURE load_billdetail(
-- 	IN p_billID VARCHAR(20)
-- )
-- BEGIN
--    SELECT bd.BILLDETAIL_ID,bd.BILLID,bd.ID,s.SERVICENAME,bd.AMOUNT FROM billdetail bd 
--    JOIN service s ON s.SERVICEID = bd.ID
--    WHERE bd.BILLID = p_billID AND bd.ISDELETED = 0 AND s.ISDELETED = 0
-- 	union
-- 	SELECT bd.BILLDETAIL_ID,bd.BILLID,bd.ID,
-- 	CASE 
--         WHEN w.`TYPE` = 'WATER' THEN 'Nước'
--         WHEN w.`TYPE` = 'ELECTRICITY' THEN 'Điện'
--         ELSE w.`TYPE`
--    END,bd.AMOUNT FROM billdetail bd 
--    JOIN water_electricity w ON w.FIGUREID = bd.ID
-- 	WHERE bd.BILLID = p_billID AND bd.ISDELETED = 0 AND w.ISDELETED = 0;
-- END//

CREATE PROCEDURE calculate_bill()
BEGIN
	DECLARE bill_id VARCHAR(20);
	
	SELECT b.BILLID INTO bill_id FROM bill b
	WHERE b.TOTAL IS NULL AND ISDELETED = 0
	LIMIT 1;
	
   UPDATE bill 
	SET bill.TOTAL = (
		SELECT SUM(AMOUNT) FROM billdetail
		WHERE billdetail.BILLID = bill_id AND ISDELETED = 0
	),
	bill.START_DATE = DATE_FORMAT(CURDATE(), '%Y-%m-01'),
	bill.END_DATE = LAST_DAY(CURDATE())
	WHERE bill.BILLID = bill_id;
   
END //

CREATE PROCEDURE add_detailBill(
    IN p_BILLID VARCHAR(50),
    IN p_ID VARCHAR(50),
   IN p_AMOUNT VARCHAR(50)
)
BEGIN
    DECLARE v_billdetailid VARCHAR(50);
    SET v_billdetailid = createBillDetailID();

    INSERT INTO billdetail (
       BILLDETAIL_ID,
       BILLID,
       ID,
       AMOUNT
    ) VALUES (
      v_billdetailid,
      p_BILLID,
      p_ID,
      p_AMOUNT
    );

END//

CREATE PROCEDURE add_all_registration_Ser_into_billdetail(
	IN p_billid VARCHAR(50),
   IN p_ID VARCHAR(50),
   IN p_AMOUNT VARCHAR(50)
)
BEGIN
	DECLARE new_ID VARCHAR(50);
	SET new_ID = createBillDetailID();
	INSERT INTO billdetail (BILLDETAIL_ID,BILLID,ID,AMOUNT)
	VALUES (new_ID,p_billid,p_ID,p_AMOUNT);
END//

CREATE PROCEDURE take_billid()
BEGIN
   SELECT b.BILLID FROM bill b
	WHERE b.TOTAL IS NULL
	LIMIT 1;
END //

CREATE FUNCTION createPaymentID()
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
	IN p_lastname VARCHAR(20)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM payment 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT p.PAYMENTID,t.TENANTID,t.FIRSTNAME,t.LASTNAME,p.BILLID,p.METHOD,p.TOTAL, Date(p.PAYMENTTIME) AS 'PAYMENT_TIME' FROM payment p
	JOIN bill b ON p.BILLID = b.BILLID
	JOIN tenant t ON b.TENANTID = t.TENANTID
	WHERE (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND p.ISDELETED = 0
	AND b.ISDELETED = 0
	AND t.ISDELETED = 0
	LIMIT 100;
END //

-- CREATE PROCEDURE load_payment(
-- 	IN p_buildingID VARCHAR(20),
-- 	IN p_tenantid VARCHAR(20),
-- 	IN p_lastname VARCHAR(50)
-- )
-- BEGIN
-- 	DELETE FROM payment 
--     WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

--    SELECT p.PAYMENTID,t.TENANTID,t.FIRSTNAME,t.LASTNAME,p.BILLID,p.METHOD,p.TOTAL,Date(p.PAYMENTTIME)  FROM payment p 
--    JOIN bill bi ON bi.BILLID = p.BILLID
-- 	JOIN tenant t ON t.TENANTID = bi.TENANTID
--    JOIN contract c ON c.TENANTID = t.TENANTID
--    JOIN room r ON r.ROOMID = c.ROOMID
--    JOIN building b ON b.BUILDINGID = r.BUILDINGID

--    WHERE b.BUILDINGID = p_buildingID
--     AND p.ISDELETED = 0
--     AND bi.ISDELETED = 0
--     AND t.ISDELETED = 0
--     AND c.ISDELETED = 0
--     AND r.ISDELETED = 0
--     AND b.ISDELETED = 0
-- 	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
-- 	AND (p_tenantid IS NULL OR t.TENANTID = p_tenantid);
-- END//

CREATE TRIGGER before_del_Bill
BEFORE DELETE ON bill
 FOR EACH ROW
BEGIN
    UPDATE payment SET ISDELETED = 1, DELETED_DATE = CURDATE() WHERE BILLID = OLD.BILLID;    
    UPDATE billdetail SET ISDELETED = 1, DELETED_DATE = CURDATE() WHERE BILLID = OLD.BILLID;   
END//

CREATE TRIGGER before_del_Billdetail
BEFORE DELETE ON billdetail
FOR EACH ROW
BEGIN
   UPDATE water_electricity SET ISDELETED = 1, DELETED_DATE = CURDATE() WHERE water_electricity.FIGUREID = OLD.ID;       
END//

CREATE PROCEDURE del_bill(
    IN p_BillID VARCHAR(50)
)
BEGIN     
    DECLARE var_id1 VARCHAR(50) DEFAULT NULL;
    DECLARE var_id2 VARCHAR(50) DEFAULT NULL;
    DECLARE record_count INT DEFAULT 0;
    
    -- Đếm số bản ghi trong billdetail
    SELECT COUNT(*) INTO record_count 
    FROM billdetail 
    WHERE BILLID = p_BillID AND ISDELETED = 0;
    
    -- Chỉ thực hiện nếu có ít nhất 1 bản ghi
    IF record_count > 0 THEN
        -- Đánh dấu xóa trong billdetail
        UPDATE billdetail
        SET ISDELETED = 1,
            DELETED_DATE = CURDATE()
        WHERE BILLID = p_BillID AND ISDELETED = 0;  
        
        -- Đánh dấu xóa trong bill
        UPDATE bill
        SET ISDELETED = 1,
            DELETED_DATE = CURDATE()
        WHERE BILLID = p_BillID AND ISDELETED = 0;  
        
        -- Lấy 2 ID đầu tiên (nếu có)
       
        
        -- Đánh dấu xóa trong water_electricity nếu có ID hợp lệ

		UPDATE water_electricity 
		SET ISDELETED = 1,
			DELETED_DATE = CURDATE()
		WHERE FIGUREID in (select ID from billdetail where BILLID = p_BillID)
		AND ISDELETED = 0;
    END IF;
END//


CREATE PROCEDURE del_W_E(
    IN p_tenantID VARCHAR(50),
    IN p_startdate DATE ,
    IN p_enddate DATE
)
BEGIN 
    DECLARE v_deleted_rows INT;
    
    UPDATE water_electricity 
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
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
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM water_electricity 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

SELECT 
    we.FIGUREID,
    we.UNITPRICEID,
    we.TENANTID,
    we.OLDFIGURE,
    we.NEWFIGURE,
    we.UNIT,
    we.START_DATE,
    we.END_DATE,
    we.RECORD_DATE,
    we.TYPE
FROM water_electricity we
	JOIN tenant t ON t.TENANTID = we.TENANTID
	JOIN contract c ON c.TENANTID = t.TENANTID
    JOIN room r ON r.ROOMID = c.ROOMID 
    JOIN building b ON b.BUILDINGID = r.BUILDINGID
WHERE b.BUILDINGID = p_buildingid
        AND t.ISDELETED = 0
        AND we.ISDELETED = 0
        AND c.ISDELETED = 0
        AND r.ISDELETED = 0
        AND t.USERNAME = p_user;
END //

CREATE FUNCTION createFigureID()
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
	DELETE FROM billdetail 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

   SELECT bd.BILLID,bd.ID,s.SERVICENAME,bd.AMOUNT FROM billdetail bd 
   JOIN service s ON s.SERVICEID = bd.ID
   WHERE bd.BILLID = p_billID
	union
	SELECT bd.BILLID,bd.ID,w.`TYPE`
   ,bd.AMOUNT FROM billdetail bd 
   JOIN water_electricity w ON w.FIGUREID = bd.ID
	WHERE bd.BILLID = p_billID;
END//

CREATE FUNCTION createBillID()
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

CREATE PROCEDURE load_tenant_by_roomid(
	IN p_room_id VARCHAR(20)
)
BEGIN
   SELECT t.TENANTID,t.FIRSTNAME,t.LASTNAME FROM tenant t
	JOIN contract c ON c.TENANTID = t.TENANTID
	Join room r on r.ROOMID = c.ROOMID
	WHERE r.ROOMNAME = p_room_id
    AND t.ISDELETED = 0
    AND c.ISDELETED = 0
    AND r.ISDELETED = 0;
END //

CREATE PROCEDURE load_bill(
	IN p_user VARCHAR(20),
	IN p_lastname VARCHAR(20),
	IN p_buildingid VARCHAR(20),
    IN p_control varchar(2)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM bill 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT b.BILLID,b.TENANTID,t.FIRSTNAME,t.LASTNAME,b.TOTAL,b.START_DATE,b.END_DATE,COALESCE(p.TOTAL,0) AS 'TOTALS' FROM bill b
    JOIN tenant t ON t.TENANTID = b.TENANTID
    LEFT JOIN payment p ON p.BILLID = b.BILLID
    JOIN contract c ON c.TENANTID = t.TENANTID
    JOIN room r ON r.ROOMID = c.ROOMID
    JOIN building bu ON bu.BUILDINGID = r.BUILDINGID
    WHERE t.USERNAME = p_user
	AND t.ISDELETED = 0
    AND b.ISDELETED = 0
    AND (
		(p_control = 0)   
     or (p_control = 1 AND b.TOTAL - COALESCE(p.TOTAL,0) <= 0)
     or (p_control = 2 AND b.TOTAL - COALESCE(p.TOTAL,0) > 0)
     )
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND bu.BUILDINGID = p_buildingid;
END //





-- PARKING AREA
-- Thủ tục để lấy tất cả bãi đậu xe
CREATE PROCEDURE sp_GetAllParkingAreas()
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT * FROM PARKINGAREA 
    WHERE ISDELETED = 0
    ORDER BY AREAID;
END //

-- Thủ tục để lấy danh sách địa chỉ đã có trong bảng PARKINGAREA
CREATE PROCEDURE sp_GetParkingAddresses()
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT DISTINCT ADDRESS FROM PARKINGAREA 
    WHERE ISDELETED = 0
    ORDER BY ADDRESS;
END //

-- Hàm để tạo ID bãi đậu xe mới tự động tăng
CREATE FUNCTION fn_GenerateNewParkingAreaId() 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(10);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(10);
    
    SELECT IFNULL(MAX(AREAID), 'PA000') INTO max_id FROM PARKINGAREA
    WHERE ISDELETED = 0;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('PA', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END //

CREATE PROCEDURE sp_FilterParkingArea(
    IN p_buildingid VARCHAR(20),
    IN p_type VARCHAR(50),
    IN p_status VARCHAR(50)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

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
        WHERE pa.ISDELETED = 0
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
READS SQL DATA
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

-- select createParkingAreaID();
-- New 8/4/2025
CREATE FUNCTION createParkingAreaID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE new_key VARCHAR(10);
	DECLARE max_key INT;
    
    SELECT COALESCE(MAX(CAST(SUBSTRING(AREAID, 3) AS UNSIGNED)), 0) INTO max_key FROM PARKINGAREA;

    SET max_key = max_key + 1;
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
        -- Cập nhật trạng thái xóa
        UPDATE PARKINGAREA
        SET ISDELETED = 1,
            DELETED_DATE = CURDATE()
        WHERE AREAID = p_areaid;
        
        SET p_result = 1;
        SET p_message = 'Bãi đậu xe đã được xóa thành công';
    ELSE
        SET p_result = 0;
        SET p_message = 'Không tìm thấy bãi đậu xe';
    END IF;
END//

-- Thủ tục để lấy thông tin sức chứa của bãi đậu xe
CREATE PROCEDURE sp_GetParkingAreaCapacity(
    IN p_areaId VARCHAR(10),
    OUT p_totalCapacity INT,
    OUT p_usedCapacity INT,
    OUT p_availableCapacity INT
)
BEGIN
	DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    -- Lấy tổng sức chứa
    SELECT CAPACITY INTO p_totalCapacity
    FROM PARKINGAREA
    WHERE AREAID = p_areaId
    AND ISDELETED = 0;
    
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
	DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY FROM PARKINGAREA 
    WHERE TYPE = p_type 
    AND ISDELETED = 0
    ORDER BY AREAID;
END //

-- Thủ tục để lấy tất cả bãi đậu xe theo tòa nhà
CREATE PROCEDURE sp_GetParkingAreasByBuilding(
    IN p_buildingId VARCHAR(10)
)
BEGIN
	DELETE FROM PARKINGAREA 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY FROM PARKINGAREA 
    WHERE BUILDINGID = p_buildingId 
    AND ISDELETED = 0
    ORDER BY AREAID;
END //

CREATE PROCEDURE GetAccessAreas(IN p_buildingid VARCHAR(10))
BEGIN
    SELECT AREAID, TYPE AS AreaName, 'Khu vực đỗ xe' AS Description
    FROM PARKINGAREA
    WHERE BUILDINGID = p_buildingid
    AND ISDELETED = 0
    UNION
    SELECT CONCAT('FLOOR_', FLOOR) AS AreaID, CONCAT('Tầng ', FLOOR) AS AreaName, 'Khu vực tầng' AS Description
    FROM ROOM
    WHERE BUILDINGID = p_buildingid
    AND ISDELETED = 0
    GROUP BY FLOOR
    UNION
    SELECT 'COMMON' AS AreaID, 'Khu vực chung' AS AreaName, 'Khu vực sinh hoạt chung' AS Description;
END //





-- VEHICLE
CREATE PROCEDURE sp_FilterVehicle(
    IN p_buildingid VARCHAR(20),
    IN p_vehicle_type VARCHAR(50)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM VEHICLE 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

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
    AND (p_vehicle_type IS NULL OR v.TYPE = p_vehicle_type)  -- Lọc theo loại phương tiện
    AND v.ISDELETED = 0
    AND pa.ISDELETED = 0;
END //

CREATE FUNCTION createVehicleID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE new_key VARCHAR(10);
	DECLARE max_key INT;
    
    SELECT COALESCE(MAX(CAST(SUBSTRING(VEHICLEID, 2) AS UNSIGNED)), 0) INTO max_key FROM VEHICLE;

    SET max_key = max_key + 1;
    SET new_key = CONCAT('V', LPAD(max_key, 4, '0'));
    RETURN new_key;
END//
-- New 14/4
CREATE PROCEDURE proc_addVehicle(
    IN p_tenantid VARCHAR(20),
    IN p_vehicle_unitprice_id VARCHAR(20),
    IN p_type VARCHAR(50),
    IN p_licenseplate VARCHAR(20),
    IN p_areaid VARCHAR(10)  -- Thay đổi tham số thành AREAID
)
BEGIN
    DECLARE p_new_vehicle_id VARCHAR(20);
    DECLARE new_parking_id VARCHAR(10);
    DECLARE i INT DEFAULT 0;

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
    
	SET new_parking_id = generate_parking_id();
	INSERT INTO PARKING (PARKINGID, AREAID, VEHICLEID, STATUS)
	VALUES (new_parking_id, p_areaid, p_new_vehicle_id, 'dangsudung');
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
        -- Cập nhật trạng thái xóa
        UPDATE VEHICLE
        SET ISDELETED = 1,
            DELETED_DATE = CURDATE()
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
    WHERE vup.TYPE = p_type
    AND vup.ISDELETED = 0;
END//





-- FINGER PRINT
-- Cập nhật quyền truy cập
CREATE PROCEDURE UpdateAreaPermission(
    IN p_fingerid VARCHAR(10), 
    IN p_areapermission VARCHAR(200)
)
BEGIN
    UPDATE FINGERPRINTS 
    SET AREAPERMISSION = p_areapermission
    WHERE FINGERID = p_fingerid;
END //

-- Cập nhật ảnh vân tay
CREATE PROCEDURE UpdateFingerprintImage(
    IN p_fingerid VARCHAR(10),
    IN p_fingerprint_image LONGBLOB,
    IN p_image_name VARCHAR(100)
)
BEGIN
    UPDATE FINGERPRINTS 
    SET FINGERPRINT_IMAGE = p_fingerprint_image,
        IMAGE_NAME = p_image_name
    WHERE FINGERID = p_fingerid;
END //

CREATE PROCEDURE GetFingerprintImage(IN p_fingerid VARCHAR(10))
BEGIN
	DELETE FROM FINGERPRINTS 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT FINGERPRINT_IMAGE 
    FROM FINGERPRINTS 
    WHERE FINGERID = p_fingerid;
END //

CREATE PROCEDURE GetFingerprints(IN p_username VARCHAR(20))
BEGIN
	DELETE FROM FINGERPRINTS 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT f.FINGERID, f.USERNAME, f.TENANTID, t.FIRSTNAME, t.LASTNAME, 
           f.AREAPERMISSION, f.ENROLLMENT_DATE, f.IMAGE_NAME
    FROM FINGERPRINTS f 
    JOIN TENANT t ON f.TENANTID = t.TENANTID 
    WHERE f.USERNAME = p_username
    AND t.ISDELETED = 0;
END //

CREATE PROCEDURE AddFingerprint(
    IN p_fingerid VARCHAR(10),
    IN p_username VARCHAR(20),
    IN p_tenantid VARCHAR(10),
    IN p_areapermission VARCHAR(200),
    IN p_fingerprint_image LONGBLOB,
    IN p_image_name VARCHAR(100)
)
BEGIN
    INSERT INTO FINGERPRINTS (
        FINGERID, 
        USERNAME, 
        TENANTID, 
        AREAPERMISSION, 
        ENROLLMENT_DATE, 
        FINGERPRINT_IMAGE,
        IMAGE_NAME
    ) 
    VALUES (
        p_fingerid,
        p_username,
        p_tenantid,
        p_areapermission,
        NOW(),
        p_fingerprint_image,
        p_image_name
    );
END //

-- Xóa vân tay
CREATE PROCEDURE DeleteFingerprint(IN p_fingerid VARCHAR(10))
BEGIN
    UPDATE FINGERPRINTS 
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE FINGERID = p_fingerid;
END //





-- USER
-- New 20/4
CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `check_account`(
    usern VARCHAR(50)
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

CREATE PROCEDURE UpdatePassword(
    IN p_email VARCHAR(255),
    IN p_password VARCHAR(255)
)
BEGIN
    DECLARE user_id VARCHAR(50) DEFAULT '';
    
    -- Lấy ID user thay vì count
    SELECT USERNAME INTO user_id FROM USER WHERE EMAIL = p_email;
	-- Cập nhật bằng khóa chính
	UPDATE USER 
	SET PASSWORD = p_password 
	WHERE USERNAME = user_id;
END //

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
    SELECT USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS FROM user WHERE USERNAME = usern AND PASSWORD = passw AND ISDELETED = 0;
END//





-- ASSET
CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Assets`(
    IN p_username VARCHAR(50))
BEGIN
	DELETE FROM ASSETS 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT 
        a.ASSETID,
        r.ROOMNAME,
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
    AND a.ISDELETED = 0
    AND r.ISDELETED = 0
    ORDER BY a.USE_DATE DESC;
END//

CREATE FUNCTION createAssetID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE new_key VARCHAR(10);
	DECLare max_key INT;
    
    SELECT COALESCE(MAX(CAST(SUBSTRING(ASSETID, 3) AS UNSIGNED)), 0) INTO max_key FROM ASSETS;

    SET max_key = max_key + 1;
    SET new_key = CONCAT('TS', LPAD(max_key, 4, '0'));
    RETURN new_key;
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
    DECLARE room_id VARCHAR(10);
    
    SELECT ROOMID INTO room_id FROM ROOM WHERE BUILDINGID = p_buildingid AND ROOMNAME = p_roomid;
    
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
		room_id,
		p_assetname,
		p_price,
		p_status,
		p_usedate
	);
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_updateAsset`(
    IN p_assetid VARCHAR(10),
    IN p_roomid VARCHAR(10),
    IN p_assetname VARCHAR(50),
    IN p_price FLOAT,
    IN p_status VARCHAR(50),
    IN p_usedate DATE,
    IN p_buildingid VARCHAR(10)
)
BEGIN
	DECLARE room_id VARCHAR(10);
    SELECT ROOMID into room_id FROM ROOM WHERE BUILDINGID = p_buildingid AND ROOMNAME = p_roomid;

    UPDATE ASSETS 
    SET 
        ROOMID = room_id,
        ASSETNAME = p_assetname,
        PRICE = p_price,
        STATUS = p_status,
        USE_DATE = p_usedate
    WHERE 
        ASSETID = p_assetid;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteAssets`(
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
        -- Cập nhật cả ISDELETED và DELETED_DATE
        UPDATE ASSETS 
        SET ISDELETED = 1, 
            DELETED_DATE = CURDATE() 
        WHERE ASSETID = p_assetid;
        
        SET p_result = 1;
        SET p_message = CONCAT('Đã xóa tài sản ', p_assetid, ' thành công. Tài sản sẽ được xóa vĩnh viễn sau 30 ngày.');
    END IF;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_FilterAssets`(
    IN p_username VARCHAR(20),
    IN p_sort_order VARCHAR(10), -- NULL, 'ASC' hoặc 'DESC'
    IN p_asset_name VARCHAR(100), -- Tên tài sản để tìm kiếm (có thể để NULL)
    IN p_buildingid VARCHAR(20)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM ASSETS 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;
    
    SELECT 
        r.ROOMNAME,
        a.ASSETID,
        a.ASSETNAME,
        a.PRICE,
        a.STATUS,
        a.USE_DATE
    FROM 
        ASSETS a
    JOIN 
        ROOM r ON a.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    JOIN 
        USER u ON b.USERNAME = u.USERNAME
    WHERE 
        u.USERNAME = p_username
        AND a.ISDELETED = 0
        AND (p_asset_name IS NULL OR a.ASSETNAME LIKE CONCAT('%', p_asset_name, '%') COLLATE utf8mb4_general_ci)
        AND (p_buildingid IS NULL OR r.BUILDINGID = p_buildingid)
    ORDER BY 
        CASE 
            WHEN p_sort_order = 'ASC' THEN a.PRICE 
            WHEN p_sort_order = 'DESC' THEN -a.PRICE -- Trick để sắp xếp DESC
            ELSE NULL 
        END,
        a.ASSETNAME COLLATE utf8mb4_general_ci;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AssetDetails`(
    IN p_username VARCHAR(20),
    IN p_buildingid VARCHAR(20))
BEGIN
	DELETE FROM ASSETS 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;
    -- Thông tin tài sản được gán cho user này (có lọc theo tòa nhà nếu cần)
    SELECT 
        a.ASSETID,
        a.ASSETNAME,
        a.PRICE,
        a.STATUS AS ASSET_STATUS,
        DATE_FORMAT(a.USE_DATE, '%d/%m/%Y') AS USE_DATE,
        r.ROOMNAME,
        r.TYPE AS ROOM_TYPE,
        r.FLOOR,
        b.BUILDINGID
    FROM 
        ASSETS a
    JOIN 
        ROOM r ON a.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    JOIN 
        USER u ON b.USERNAME = u.USERNAME
    WHERE 
        u.USERNAME = p_username
        AND a.ISDELETED = 0
        AND r.ISDELETED = 0
        AND (p_buildingid IS NULL OR b.BUILDINGID = p_buildingid);
    
    -- Lịch sử bảo trì các tài sản của user này (có lọc theo tòa nhà)
    SELECT 
        m.MAINTENANCEID,
        m.ASSETID,
        a.ASSETNAME,
        DATE_FORMAT(m.MAINTENANCE_DATE, '%d/%m/%Y') AS MAINTENANCE_DATE,
        m.DESCRIPTION,
        m.STATUS AS MAINTENANCE_STATUS,
        CASE 
            WHEN m.STATUS = 'Completed' THEN 'Hoàn thành'
            WHEN m.STATUS = 'Pending' THEN 'Đang chờ'
            WHEN m.STATUS = 'Cancelled' THEN 'Đã hủy'
            ELSE m.STATUS
        END AS STATUS_VN
    FROM 
        MAINTENANCE m
    JOIN 
        ASSETS a ON m.ASSETID = a.ASSETID
    JOIN 
        ROOM r ON a.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    JOIN 
        USER u ON b.USERNAME = u.USERNAME
    WHERE 
        u.USERNAME = p_username
        AND b.BUILDINGID = p_buildingid
        AND a.ISDELETED = 0
        AND r.ISDELETED = 0
    ORDER BY 
        m.MAINTENANCE_DATE DESC
    LIMIT 50; -- Giới hạn kết quả để tăng hiệu năng
    
    -- Lịch sử yêu cầu sửa chữa (có lọc theo tòa nhà)
    SELECT 
        rr.REQUESTID,
        rr.ASSETID,
        a.ASSETNAME,
        DATE_FORMAT(rr.REQUEST_DATE, '%d/%m/%Y %H:%i') AS REQUEST_DATE,
        rr.DESCRIPTION,
        rr.STATUS AS REQUEST_STATUS,
        CASE 
            WHEN rr.STATUS = 'Pending' THEN 'Chờ xử lý'
            WHEN rr.STATUS = 'Processing' THEN 'Đang xử lý'
            WHEN rr.STATUS = 'Completed' THEN 'Hoàn thành'
            WHEN rr.STATUS = 'Rejected' THEN 'Từ chối'
            ELSE rr.STATUS
        END AS STATUS_VN,
        CONCAT(t.FIRSTNAME, ' ', t.LASTNAME) AS TENANT_NAME,
        t.PHONENUMBER
    FROM 
        REPAIR_REQUEST rr
    JOIN 
        ASSETS a ON rr.ASSETID = a.ASSETID
    JOIN 
        ROOM r ON a.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    JOIN 
        USER u ON b.USERNAME = u.USERNAME
    JOIN 
        TENANT t ON rr.TENANTID = t.TENANTID
    WHERE 
        u.USERNAME = p_username
        AND a.ISDELETED = 0
        AND r.ISDELETED = 0
        AND t.ISDELETED = 0
        AND (p_buildingid IS NULL OR b.BUILDINGID = p_buildingid)
    ORDER BY 
        rr.REQUEST_DATE DESC
    LIMIT 50; -- Giới hạn kết quả
END//





-- ROOM
CREATE PROCEDURE GetRoomsByTenantAndBuilding(
    IN p_tenantID VARCHAR(50),
    IN p_buildingID VARCHAR(50)
)
BEGIN
	DELETE FROM contract 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT p.ROOMNAME 
    FROM contract c 
    JOIN room p ON c.ROOMID = p.ROOMID 
    WHERE c.TENANTID = p_tenantID 
    AND p.BUILDINGID = p_buildingID
    AND p.ISDELETED = 0;
END //

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Room_Extended`(IN p_username VARCHAR(50))
BEGIN
	DELETE FROM ROOM 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT 
        r.ROOMNAME, 
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

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_roomid`(IN p_buildingid VARCHAR(20))
BEGIN
	DELETE FROM ROOM 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT ROOMNAME 
    FROM ROOM 
    WHERE BUILDINGID = p_buildingid;
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
    DECLARE new_room_name VARCHAR(10);
	SET new_room_id = createRoomID(p_buildingid, p_floor);
    SET new_room_name = createRoomName(p_buildingid, p_floor);

    INSERT INTO ROOM (ROOMID, ROOMNAME, BUILDINGID, TYPE, FLOOR, CONVENIENT, AREA, PRICE, STATUS)
    VALUES (new_room_id, new_room_name, p_buildingid, p_type, p_floor, p_convenient, p_area, p_price, p_status);
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
	DECLARE room_id VARCHAR(10);
    
    SELECT ROOMID INTO room_id FROM ROOM WHERE BUILDINGID = p_buildingid AND ROOMNAME = p_roomid;

    UPDATE ROOM 
SET BUILDINGID = p_buildingid,
    TYPE = p_type,
    FLOOR = p_floor,
    CONVENIENT = p_convenient,
    AREA = p_area,
    PRICE = p_price,
    STATUS = p_status
WHERE ROOMNAME = p_roomid;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `sp_DeleteRoom`(
    IN p_roomid VARCHAR(10),
    IN p_buildingid VARCHAR(10),
    OUT p_result INT,
    OUT p_message VARCHAR(255))
BEGIN
    DECLARE room_exists INT;
    
    -- Kiểm tra xem phòng có tồn tại không
    SELECT COUNT(*) INTO room_exists FROM Room WHERE ROOMNAME = p_roomid AND BUILDINGID = p_buildingid;
    
    IF room_exists = 0 THEN
        SET p_result = 0;
        SET p_message = 'Phòng không tồn tại';
    ELSE
        -- Xóa phòng (với ON DELETE CASCADE, các bản ghi liên quan sẽ tự động xóa)
        UPDATE ROOM
		SET ISDELETED = 1,
		   DELETED_DATE = CURDATE() 
		WHERE ROOMNAME = p_roomid AND BUILDINGID = p_buildingid;
        
        SET p_result = 1;
        SET p_message = CONCAT('Đã xóa phòng ', p_roomid, ' thành công');
    END IF;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `filter_room`(
    IN p_username VARCHAR(50),
    IN p_buildingid VARCHAR(20),
    IN p_status_list VARCHAR(1000)
)
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM ROOM 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;
    
    IF p_buildingid is null then
		SELECT 
			r.ROOMNAME, 
			r.BUILDINGID, 
			r.TYPE, 
            r.FLOOR,
			r.CONVENIENT, 
			r.AREA, 
			r.PRICE, 
			r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		JOIN USER u ON u.USERNAME = b.USERNAME
		WHERE u.USERNAME = p_username
		AND r.ISDELETED = 0;
	ELSE

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
		SELECT r.ROOMNAME, r.BUILDINGID, r.TYPE, r.FLOOR, r.CONVENIENT, r.AREA, r.PRICE, r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		WHERE b.USERNAME = p_username 
		AND r.buildingid = p_buildingid
		AND r.ISDELETED = 0
		AND (
			SELECT COUNT(*) 
			FROM temp_statuses ts 
			WHERE r.STATUS LIKE CONCAT('%', ts.status_value, '%')
		) = @total_statuses;
		
		DROP TEMPORARY TABLE IF EXISTS temp_statuses;
	end if;
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
    
    SELECT NUMOFROOMS INTO max_rooms_on_floor
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
    
    -- Tìm số phòng lớn nhất hiện có trong toàn bộ tòa nhà và tăng thêm 1
    SELECT IFNULL(MAX(CAST(SUBSTRING(ROOMID, 2) AS UNSIGNED)), 0) + 1 
    INTO next_room_num
    FROM ROOM;
    
    -- Kiểm tra nếu số phòng vượt quá 9999 (4 chữ số)
    IF next_room_num > 9999 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Đã đạt số lượng phòng tối đa cho tòa nhà';
    END IF;
    
    -- Tạo mã phòng mới với định dạng R + 4 chữ số (ví dụ: R0001, R0002,...)
    SET new_room_id = CONCAT('R', LPAD(next_room_num, 4, '0'));
    
    RETURN new_room_id;
END//

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createRoomName`(
    building_id VARCHAR(10), 
    floor_num INT
) 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE next_room_num INT;
    DECLARE new_room_id VARCHAR(10);
    DECLARE floor_prefix VARCHAR(1);
    
    -- Chuyển số tầng thành ký tự đầu tiên (0-9)
    SET floor_prefix = CAST(floor_num AS CHAR);
    
    -- Tìm số phòng lớn nhất hiện có trên tầng này của tòa nhà
    SELECT IFNULL(MAX(CAST(SUBSTRING(ROOMID, 2) AS UNSIGNED)), 0) + 1 
    INTO next_room_num
    FROM ROOM 
    WHERE BUILDINGID = building_id AND FLOOR = floor_num
    AND ROOMNAME LIKE CONCAT('R', floor_prefix, '%');
    
    -- Kiểm tra nếu số phòng vượt quá 999 (3 chữ số)
    IF next_room_num > 999 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Đã đạt số lượng phòng tối đa';
    END IF;
    
    -- Tạo mã phòng mới với định dạng R + 1 chữ số tầng + 3 chữ số phòng (ví dụ: R0001, R1002,...)
    SET new_room_id = CONCAT('R', floor_prefix, LPAD(next_room_num, 2, '0'));
    
    RETURN new_room_id;
END//


CREATE DEFINER=`root`@`localhost` PROCEDURE `load_Room`(
    IN p_username VARCHAR(20), 
    IN p_buildingid VARCHAR(10))
BEGIN
	DELETE FROM ROOM 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

	IF p_buildingid is null then
		SELECT 
			r.ROOMNAME, 
			r.BUILDINGID, 
			r.TYPE, 
            r.FLOOR,
			r.CONVENIENT, 
			r.AREA, 
			r.PRICE, 
			r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		JOIN USER u ON u.USERNAME = b.USERNAME
		WHERE u.USERNAME = p_username
		AND r.ISDELETED = 0;
	ELSE
		SELECT 
			r.ROOMNAME, 
			r.BUILDINGID, 
            r.TYPE, 
			r.FLOOR,
			r.CONVENIENT, 
			r.AREA, 
			r.PRICE, 
			r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		JOIN USER u ON u.USERNAME = b.USERNAME
		WHERE u.USERNAME = p_username 
		AND b.BUILDINGID = p_buildingid
		AND r.ISDELETED = 0;
	END IF;
END//

CREATE PROCEDURE `load_RentalHistory`(
    IN p_username VARCHAR(50),
    IN p_buildingid VARCHAR(20))
BEGIN
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT 
        c.CONTRACTID AS RENTAL_HISTORY_ID,
        c.CONTRACTID,
        r.ROOMNAME,
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
        c.STARTDATE,
        c.ENDDATE,
        'Đã kết thúc' AS REASON_FOR_LEAVING,
        r.BUILDINGID,
        b.ADDRESS AS BUILDING_ADDRESS
    FROM 
        CONTRACT c
    JOIN 
        TENANT t ON c.TENANTID = t.TENANTID
    JOIN 
        ROOM r ON c.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE 
        b.USERNAME = p_username
        AND r.BUILDINGID = p_buildingid
        AND c.ENDDATE < CURDATE() -- Chỉ lấy các hợp đồng đã kết thúc
        AND t.ISDELETED = 0
        AND r.ISDELETED = 0
    ORDER BY 
        c.ENDDATE DESC;
END// 





-- BUILDING
CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_buildingid`(IN p_username VARCHAR(20))
BEGIN
	DELETE FROM BUILDING 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT BUILDINGID 
    FROM BUILDING 
    WHERE USERNAME = p_username;
END//

-- Thủ tục để lấy danh sách ID tòa nhà
CREATE PROCEDURE sp_GetAllBuildings()
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM BUILDING 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT BUILDINGID, ADDRESS FROM BUILDING 
    WHERE ISDELETED = 0
    ORDER BY BUILDINGID;
END //

-- Hàm để tạo ID tòa nhà mới tự động tăng
-- CREATE FUNCTION fn_GenerateNewBuildingId() 
-- RETURNS VARCHAR(10)
-- DETERMINISTIC
-- BEGIN
--     DECLARE max_id VARCHAR(10);
--     DECLARE number_part INT;
--     DECLARE new_id VARCHAR(10);
--     
--     SELECT IFNULL(MAX(BUILDINGID), 'BD000') INTO max_id FROM BUILDING
--     WHERE ISDELETED = 0;
--     SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
--     SET new_id = CONCAT('BD', LPAD(number_part, 3, '0'));
--     RETURN new_id;
-- END //
-- Thêm trigger để tự động cập nhật khi có tòa nhà mới
-- CREATE TRIGGER after_building_insert
-- AFTER INSERT ON BUILDING
-- FOR EACH ROW
-- BEGIN
--     -- Tự động tạo một bản ghi trong bảng PARKINGAREA với thông tin mặc định
--     DECLARE new_area_id VARCHAR(10);
--     SET new_area_id = createParkingAreaID();
--     
--     -- Thêm bãi đậu xe mặc định cho tòa nhà mới
--     INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
--     VALUES (new_area_id, NEW.BUILDINGID, CONCAT('Tầng hầm ', NEW.BUILDINGID), 'honhop', 10);
-- END //

-- New 15/4
CREATE PROCEDURE addBuilding(
	IN p_buildingkey VARCHAR(20),
	IN p_username VARCHAR(20),
   IN p_address VARCHAR(200),
   IN p_numoffloors INT,
   IN p_numofrooms INT
)
BEGIN
	DECLARE newid VARCHAR(20);
	SET newid = createBuildingID();
	
	
	INSERT INTO Building (
        BUILDINGID,
        BUILDING_KEY,
        USERNAME,
        ADDRESS,
        NUMOFFLOORS,
        NUMOFROOMS
    )
    VALUES (
        newid,
        p_buildingkey,
        p_username,
        p_address,
        p_numoffloors,
        p_numofrooms
    );
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_floor`(IN p_buildingid VARCHAR(20))
BEGIN
	DELETE FROM BUILDING 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT NUMOFFLOORS 
    FROM BUILDING 
    WHERE BUILDINGID = p_buildingid;
END//

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

CREATE FUNCTION createBuildingID() 
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

CREATE PROCEDURE add_building(
	IN p_BUILDING_KEY VARCHAR(20),
	IN p_USERNAME VARCHAR(20),
   IN p_ADDRESS VARCHAR(200)
)
BEGIN
	DECLARE newid VARCHAR(20);
	SET newid = createBuildingID();
	
	
	INSERT INTO Building (
        BUILDINGID,
        BUILDING_KEY,
        USERNAME,
        ADDRESS
    )
    VALUES (
        newid,
        p_BUILDING_KEY,
        p_USERNAME,
        p_ADDRESS
    );
END//

CREATE PROCEDURE load_building_by_user(
    IN usern VARCHAR(20)
)
BEGIN
	DELETE FROM BUILDING 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT b.BUILDINGID, b.BUILDING_KEY 
    FROM BUILDING b
    JOIN user u ON b.USERNAME = u.USERNAME
    WHERE u.USERNAME = usern
    AND b.ISDELETED = 0;
END//

CREATE PROCEDURE change_building_key(
    IN p_building_id VARCHAR(20),
    IN p_building_key VARCHAR(20)
)
BEGIN
    DECLARE key_exists INT;

    SELECT COUNT(*) INTO key_exists
    FROM building 
    WHERE BUILDING_KEY = p_building_key 
    AND BUILDINGID != p_building_id
    AND ISDELETED = 0;
    
    IF key_exists = 0 THEN
        UPDATE building 
        SET BUILDING_KEY = p_building_key
        WHERE BUILDINGID = p_building_id;
    END IF;
END//





-- CONTRACT
CREATE PROCEDURE load_outdateContract(
	IN p_buildingid VARCHAR(20)
)
BEGIN
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

   SELECT c.CONTRACTID, r.ROOMNAME, c.TENANTID, c.CREATEDATE, c.STARTDATE, c.ENDDATE, c.MONTHLYRENT, c.PAYMENTSCHEDULE, c.DEPOSIT, c.STATUS, c.NOTES, c.AUTO_RENEW, c.TERMINATION_REASON, c.CONTRACT_FILE_PATH
	FROM contract c
	JOIN room r ON r.ROOMID = c.ROOMID
	JOIN building b ON b.BUILDINGID = r.BUILDINGID
	WHERE c.ENDDATE < CURRENT_DATE()
	AND NOT EXISTS (
   SELECT 1 
   FROM tenant_history th 
   WHERE th.CONTRACTID = c.CONTRACTID)
	AND b.BUILDINGID = p_buildingid
	AND r.ISDELETED = 0;
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
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

   SELECT 
      c.CONTRACTID,
		r.ROOMNAME,
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
   WHERE c.CONTRACTID = contract_id
   AND t.ISDELETED = 0
   AND r.ISDELETED = 0;
END//

CREATE FUNCTION createContractID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(ContractID), 'CT000') INTO max_id FROM Contract;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('CT', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE add_Contract(
    IN p_building_id VARCHAR(50),
    IN p_id_room VARCHAR(50),
    IN p_tenantid VARCHAR(50),
    IN p_createddate DATETIME,
    IN p_startdate DATETIME,
    IN p_enddate DATETIME,
    IN p_paymentschedule VARCHAR(50),
    IN p_deposit FLOAT,
    IN p_note VARCHAR(200)
)
BEGIN
    DECLARE v_contractid VARCHAR(50);
    DECLARE v_monthrent FLOAT;
    DECLARE room_id VARCHAR(10);

    SET v_contractid = createContractID();

	SELECT ROOMID INTO room_id
    FROM ROOM
    WHERE BUILDINGID = p_building_id
    AND ROOMNAME = p_id_room;
    
    SELECT r.PRICE INTO v_monthrent
    FROM room r 
    JOIN building b ON b.BUILDINGID = r.BUILDINGID 
    WHERE b.BUILDINGID = p_building_id
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
        room_id,
        p_tenantid,
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

CREATE PROCEDURE del_Contract(
    IN contract_id VARCHAR(20)
)
BEGIN
    UPDATE contract
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE contract.CONTRACTID = contract_id;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Contract_filter`(
    IN p_buildingID VARCHAR(50),
    IN control VARCHAR(2),
    IN p_lastname VARCHAR(20)
)
BEGIN
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT 
        c.CONTRACTID,
        r.ROOMNAME,
        c.TENANTID,
        t.FIRSTNAME,
        t.LASTNAME,
        c.CREATEDATE,
        c.STARTDATE,
        c.ENDDATE,
        c.MONTHLYRENT, 
        c.PAYMENTSCHEDULE,
        c.DEPOSIT,
        c.NOTES
    FROM contract c
    JOIN room r ON r.ROOMID = c.ROOMID
    JOIN building b ON r.BUILDINGID = b.BUILDINGID
    JOIN user u ON u.USERNAME = b.USERNAME
    JOIN tenant t ON t.TENANTID = c.TENANTID
    WHERE b.BUILDINGID = p_buildingID
    AND t.ISDELETED = 0
    AND r.ISDELETED = 0
    AND c.ISDELETED = 0
    AND (
      (control = '1' AND DATEDIFF(c.ENDDATE, CURDATE()) BETWEEN 0 AND 30)
   OR (control = '2' AND c.ENDDATE < CURDATE()) 
   OR (control = '3' AND c.STARTDATE <= CURDATE() AND c.ENDDATE >= CURDATE()) 
   OR (control NOT IN ('1', '2', '3')) 
    )
	 AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'));
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE IF NOT EXISTS `load_Contract`(IN p_buildingID VARCHAR(50))
BEGIN
	DELETE FROM CONTRACT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

   SELECT 
      c.CONTRACTID,
      r.ROOMNAME,
      c.TENANTID,
      t.FIRSTNAME,
      t.LASTNAME,
      c.CREATEDATE,
      c.STARTDATE,
      c.ENDDATE,
      c.MONTHLYRENT, 
      c.PAYMENTSCHEDULE,
      c.DEPOSIT,
      c.NOTES
   FROM contract c
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building b ON r.BUILDINGID = b.BUILDINGID
   JOIN user u ON u.USERNAME = b.USERNAME
   JOIN tenant t ON t.TENANTID = c.TENANTID
   WHERE b.BUILDINGID = p_buildingID
   AND t.ISDELETED = 0
   AND r.ISDELETED = 0;
END//





-- SERVICE
CREATE PROCEDURE load_registration_service_to_add(
	IN p_tenant_id VARCHAR(20)
)
BEGIN
   SELECT us.SERVICEID,s.UNITPRICE FROM use_service us
   JOIN service s ON s.SERVICEID = us.SERVICEID
   WHERE us.TENANTID = p_tenant_id AND us.ISDELETED = 0 AND s.ISDELETED = 0;
END //

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
    UPDATE use_service
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE TENANTID = p_TenantID AND SERVICEID = p_ServiceID;
END //

CREATE PROCEDURE sp_GetAllDichVu ()
BEGIN
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM SERVICE 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT ServiceID, ServiceName, UnitPrice FROM SERVICE
    WHERE ISDELETED = 0;
END//

CREATE PROCEDURE DeleteDichVu(IN p_serviceID VARCHAR(10))
BEGIN
    UPDATE service 
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE service.SERVICEID = p_serviceID;
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


CREATE PROCEDURE GetServiceUsage(
    IN P_BUILDINGID VARCHAR(10),
    IN P_SORTOPTION VARCHAR(10) 
)
BEGIN
    SET @row_num = 0;
    SET @orderClause = CASE 
        WHEN P_SORTOPTION = 'TenTang' THEN 'TENANTNAME ASC'
        WHEN P_SORTOPTION = 'GiaTang' THEN 'UNITPRICE ASC'
        WHEN P_SORTOPTION = 'GiaGiam' THEN 'UNITPRICE DESC'
        WHEN P_SORTOPTION = 'NgayMoi' THEN 'START_DATE DESC'
        WHEN P_SORTOPTION = 'NgayCu' THEN 'START_DATE ASC'
        ELSE 'ROOMID ASC'
    END;

    SET @sql = CONCAT('
        SELECT 
            (@row_num := @row_num + 1) AS STT,
            R.ROOMNAME, 
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
        JOIN BUILDING B ON R.BUILDINGID = B.BUILDINGID 
        WHERE R.BUILDINGID = ''', P_BUILDINGID, '''
        AND T.ISDELETED = 0
        AND R.ISDELETED = 0
        AND S.ISDELETED = 0
        ORDER BY ', @orderClause);

    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //


-- REGISTRATION
CREATE FUNCTION createRegisterID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(temporary_registration.REGISTRATIONID), 'DK000') INTO max_id FROM temporary_registration;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('DK', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE add_Registration(
    IN p_tenant_id VARCHAR(50),
    IN p_room_id VARCHAR(50),
    IN p_registration_date DATETIME,
    IN p_expiration_date DATETIME,
    IN p_status VARCHAR(50),
    IN p_buildingid VARCHAR(50)
)
BEGIN
   DECLARE v_registration_id VARCHAR(50);
	DECLARE room_id VARCHAR(10);
	SET v_registration_id = createRegisterID();

	SELECT ROOMID INTO room_id FROM ROOM WHERE BUILDINGID = p_buildingid AND ROOMNAME = p_room_id;

    INSERT INTO temporary_registration (
        REGISTRATIONID,
        TENANTID,
        ROOMID,
        REGISTRATION_DATE,
        EXPIRATION_DATE,
        STATUS
    ) VALUES (
        v_registration_id,
        p_tenant_id,
        room_id,
        p_registration_date,
        p_expiration_date,
        p_status
    );
END //

CREATE PROCEDURE update_registration(
	IN p_registration_id VARCHAR(20),
    IN p_status VARCHAR(20),
    IN p_endDate VARCHAR(20)
)
BEGIN
    UPDATE temporary_registration t
    SET t.`STATUS` = p_status
    and t.EXPIRATION_DATE = p_endDate
    WHERE t.REGISTRATIONID = p_registration_id;
END//

CREATE PROCEDURE del_registration(
    IN p_registration_id VARCHAR(50)
)
BEGIN 
    UPDATE temporary_registration 
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE REGISTRATIONID = p_registration_id;
END//

CREATE PROCEDURE load_registration(
    IN p_building_id VARCHAR(50),
    IN p_lastname VARCHAR(20)
)
BEGIN 
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM temporary_registration 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT tr.REGISTRATIONID,r.ROOMNAME,tr.TENANTID,t.FIRSTNAME,t.LASTNAME,tr.REGISTRATION_DATE,tr.EXPIRATION_DATE,tr.`STATUS` FROM temporary_registration tr
	JOIN room r ON r.ROOMID = tr.ROOMID
	JOIN tenant t ON t.TENANTID = tr.TENANTID
	WHERE r.BUILDINGID = p_building_id
	AND t.ISDELETED = 0
	AND r.ISDELETED = 0
    AND tr.ISDELETED = 0
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'));
END//

-- TENANT
DROP PROCEDURE IF EXISTS GetTenantsByUsername //
CREATE PROCEDURE GetTenantsByUsername(IN p_username VARCHAR(20), IN p_buildingid VARCHAR(10))
BEGIN
	DELETE FROM TENANT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT t.TENANTID, t.FIRSTNAME, t.LASTNAME, t.PHONENUMBER, r.ROOMNAME, r.BUILDINGID
    FROM TENANT t
    LEFT JOIN CONTRACT c ON t.TENANTID = c.TENANTID
    LEFT JOIN ROOM r ON c.ROOMID = r.ROOMID
    WHERE r.BUILDINGID = p_buildingid
    AND t.ISDELETED = 0
    AND r.ISDELETED = 0;
END //

CREATE PROCEDURE GetTenantsByBuilding(
    IN p_buildingID VARCHAR(50)
)
BEGIN
	DELETE FROM TENANT 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT T.TenantID, T.FIRSTNAME, T.LASTNAME 
    FROM Tenant T
    JOIN CONTRACT C ON T.TenantID = C.TenantID
    JOIN ROOM R ON C.RoomID = R.RoomID
    WHERE R.BUILDINGID = p_buildingID
    AND T.ISDELETED = 0
    AND R.ISDELETED = 0;
END //

CREATE PROCEDURE update_Tenant(
    IN p_TenantID VARCHAR(50),
    IN p_FirstName VARCHAR(100),
    IN p_LastName vARCHAR(100),
    IN p_Birthday DATETime,
    IN p_Gender VARCHAR(10),
    IN p_PhoneNumber VARCHAR(20),
    IN p_Email VARCHAR(100))
    
BEGIN
     UPDATE tenant SET
         FIRSTNAME = p_FirstName,
         LASTNAME = p_LastName,
         BIRTHDAY = p_Birthday,
         GENDER = p_Gender,
         PHONENUMBER = p_PhoneNumber,
         EMAIL = p_Email
     WHERE TENANTID = p_TenantID;
END //


CREATE FUNCTION createTenantID()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(TENANTID), 'T000') INTO max_id FROM tenant;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('T', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE del_Tenant(
    IN p_TenantID VARCHAR(50)
) 
BEGIN
    UPDATE tenant
    SET ISDELETED = 1,
        DELETED_DATE = CURDATE()
    WHERE TENANTID = p_TenantID;
END //

CREATE PROCEDURE load_Tenant(
	IN p_username VARCHAR(20),
    IN p_lastname VARCHAR(20)
)
BEGIN 
    -- Delete records that have been soft-deleted for more than 30 days
    DELETE FROM tenant 
    WHERE ISDELETED = 1 AND DATEDIFF(CURDATE(), DELETED_DATE) > 30;

    SELECT t.* FROM tenant t
	JOIN user u ON u.USERNAME = t.USERNAME 
	WHERE u.USERNAME = p_username
	AND t.ISDELETED = 0
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'));
END//

CREATE PROCEDURE add_Tenant(
	IN p_username VARCHAR(20),
    IN p_FirstName NVARCHAR(100),
    IN p_LastName NVARCHAR(100),
    IN p_Birthday DATE,
    IN p_Gender VARCHAR(10),
    IN p_PhoneNumber VARCHAR(20),
    IN p_Email VARCHAR(100)
)
BEGIN
	DECLARE newid VARCHAR(20);
	SET newid = createTenantID();
    INSERT INTO Tenant (
    		tenant.USERNAME,
        TENANTID,
        FIRSTNAME,
        LASTNAME,
        BIRTHDAY,
        GENDER,
        PHONENUMBER,
        EMAIL
    ) VALUES (
    		p_username,
    		newid,
        p_FirstName,
        p_LastName,
        p_Birthday,
        p_Gender,
        p_PhoneNumber,
        p_Email
    );
END //























-- Thủ tục để kiểm tra dữ liệu và thêm bãi đậu xe mới
-- CREATE PROCEDURE sp_AddParkingArea(
--     IN p_buildingId VARCHAR(10),
--     IN p_address VARCHAR(100),
--     IN p_type VARCHAR(50),
--     IN p_capacity INT,
--     OUT p_message VARCHAR(255),
--     OUT p_success BOOLEAN
-- )
-- BEGIN
--     DECLARE new_area_id VARCHAR(10);
--     
--     -- Mặc định thành công
--     SET p_success = TRUE;
--     SET p_message = 'Thêm bãi đậu xe thành công!';
--     
--     -- Kiểm tra dữ liệu đầu vào
--     IF p_buildingId IS NULL OR p_buildingId = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'ID tòa nhà không được để trống!';
--     ELSEIF p_address IS NULL OR p_address = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Địa chỉ không được để trống!';
--     ELSEIF p_type IS NULL OR p_type = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Loại bãi đậu xe không được để trống!';
--     ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
--     ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
--         SET p_success = FALSE;
--         SET p_message = 'Sức chứa phải là số nguyên dương!';
--     ELSE
--         -- Kiểm tra tòa nhà có tồn tại không
--         IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
--             SET p_success = FALSE;
--             SET p_message = 'ID tòa nhà không tồn tại!';
--         ELSE
--             -- Tạo ID mới
--             SET new_area_id = fn_GenerateNewParkingAreaId();
--             
--             -- Thực hiện thêm dữ liệu
--             INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
--             VALUES (new_area_id, p_buildingId, p_address, p_type, p_capacity);
--             
--             -- Trả về ID mới tạo trong thông báo
--             SET p_message = CONCAT('Thêm bãi đậu xe thành công! ID mới: ', new_area_id);
--         END IF;
--     END IF;
-- END //

-- Thủ tục để khởi tạo dữ liệu form
-- CREATE PROCEDURE sp_InitParkingAreaForm(
--     OUT p_new_area_id VARCHAR(10)
-- )
-- BEGIN
--     -- Tạo ID mới
--     SET p_new_area_id = fn_GenerateNewParkingAreaId();
-- END //

-- Thủ tục để cập nhật bãi đậu xe
-- CREATE PROCEDURE sp_UpdateParkingArea(
--     IN p_areaId VARCHAR(10),
--     IN p_buildingId VARCHAR(10),
--     IN p_address VARCHAR(100),
--     IN p_type VARCHAR(50),
--     IN p_capacity INT,
--     OUT p_message VARCHAR(255),
--     OUT p_success BOOLEAN
-- )
-- BEGIN
--     -- Mặc định thành công
--     SET p_success = TRUE;
--     SET p_message = 'Cập nhật bãi đậu xe thành công!';
--     
--     -- Kiểm tra dữ liệu đầu vào
--     IF p_areaId IS NULL OR p_areaId = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'ID bãi đậu xe không được để trống!';
--     ELSEIF p_buildingId IS NULL OR p_buildingId = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'ID tòa nhà không được để trống!';
--     ELSEIF p_address IS NULL OR p_address = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Địa chỉ không được để trống!';
--     ELSEIF p_type IS NULL OR p_type = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Loại bãi đậu xe không được để trống!';
--     ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
--         SET p_success = FALSE;
--         SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
--     ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
--         SET p_success = FALSE;
--         SET p_message = 'Sức chứa phải là số nguyên dương!';
--     ELSE
--         -- Kiểm tra bãi đậu xe có tồn tại không
--         IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
--             SET p_success = FALSE;
--             SET p_message = 'ID bãi đậu xe không tồn tại!';
--         ELSE
--             -- Kiểm tra tòa nhà có tồn tại không
--             IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
--                 SET p_success = FALSE;
--                 SET p_message = 'ID tòa nhà không tồn tại!';
--             ELSE
--                 -- Thực hiện cập nhật dữ liệu
--                 UPDATE PARKINGAREA
--                 SET BUILDINGID = p_buildingId, 
--                     ADDRESS = p_address, 
--                     TYPE = p_type, 
--                     CAPACITY = p_capacity
--                 WHERE AREAID = p_areaId;
--             END IF;
--         END IF;
--     END IF;
-- END //

-- Thủ tục để xóa bãi đậu xe
-- CREATE PROCEDURE sp_DeleteParkingArea(
--     IN p_areaId VARCHAR(10),
--     OUT p_message VARCHAR(255),
--     OUT p_success BOOLEAN
-- )
-- BEGIN
--     -- Mặc định thành công
--     SET p_success = TRUE;
--     SET p_message = 'Xóa bãi đậu xe thành công!';
--     
--     -- Kiểm tra dữ liệu đầu vào
--     IF p_areaId IS NULL OR p_areaId = '' THEN
--         SET p_success = FALSE;
--         SET p_message = 'ID bãi đậu xe không được để trống!';
--     ELSE
--         -- Kiểm tra bãi đậu xe có tồn tại không
--         IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
--             SET p_success = FALSE;
--             SET p_message = 'ID bãi đậu xe không tồn tại!';
--         ELSE
--             -- Kiểm tra có xe đang đậu không
--             IF EXISTS (SELECT 1 FROM PARKING WHERE AREAID = p_areaId) THEN
--                 SET p_success = FALSE;
--                 SET p_message = 'Không thể xóa bãi đậu xe đang có xe!';
--             ELSE
--                 -- Thực hiện xóa dữ liệu
--                 DELETE FROM PARKINGAREA WHERE AREAID = p_areaId;
--             END IF;
--         END IF;
--     END IF;
-- END //