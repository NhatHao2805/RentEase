delimiter //
DROP FUNCTION IF EXISTS createBillID//
DROP FUNCTION IF EXISTS createFigureID//
DROP FUNCTION IF EXISTS createPaymentID//

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
   SELECT p.PAYMENTID,t.TENANTID,t.FIRSTNAME,t.LASTNAME,p.BILLID,p.METHOD,p.TOTAL,Date(p.PAYMENTTIME)  FROM payment p 
   JOIN bill bi ON bi.BILLID = p.BILLID
	JOIN tenant t ON t.TENANTID = bi.TENANTID
   JOIN contract c ON c.TENANTID = t.TENANTID
   JOIN room r ON r.ROOMID = c.ROOMID
   JOIN building b ON b.BUILDINGID = r.BUILDINGID

   WHERE b.BUILDINGID = p_buildingID
	AND (p_lastname IS NULL OR CONCAT(t.FIRSTNAME,' ',t.LASTNAME) LIKE CONCAT('%', p_lastname, '%'))
	AND (p_tenantid IS NULL OR t.TENANTID = p_tenantid);
END//


-- CREATE TRIGGER before_del_Bill
-- BEFORE DELETE ON bill
-- FOR EACH ROW
-- BEGIN
--     DELETE FROM payment  
--     WHERE BILLID = OLD.BILLID;    
-- 	 DELETE FROM billdetail  
--     WHERE BILLID = OLD.BILLID;   
-- END//

-- CREATE TRIGGER before_del_Billdetail
-- BEFORE DELETE ON billdetail
-- FOR EACH ROW
-- BEGIN
--     DELETE FROM water_electricity  
--     WHERE water_electricity.FIGUREID = OLD.ID;       
-- END//

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
   SELECT b.BILLID,b.TENANTID,t.FIRSTNAME,t.LASTNAME,b.TOTAL,b.START_DATE,b.END_DATE,COALESCE(p.TOTAL,0) FROM bill b
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

delimiter ;