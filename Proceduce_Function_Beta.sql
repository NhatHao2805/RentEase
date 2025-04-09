-- 9-4
delimiter //
DROP FUNCTION IF EXISTS createBillID//
DROP FUNCTION IF EXISTS createFigureID//
DROP FUNCTION IF EXISTS createPaymentID//
DROP FUNCTION IF EXISTS createBillDetailID//

DROP PROCEDURE IF EXISTS auto_AddTenantHistory//
DROP PROCEDURE IF EXISTS load_outdateContract//
DROP PROCEDURE IF EXISTS update_tenantHistory//
DROP PROCEDURE IF EXISTS load_allTH//
DROP PROCEDURE IF EXISTS load_lstn//
DROP PROCEDURE IF EXISTS load_bill//
DROP PROCEDURE IF EXISTS load_billdetail//
DROP PROCEDURE IF EXISTS load_W_E//
DROP PROCEDURE IF EXISTS del_W_E//
DROP PROCEDURE IF EXISTS add_w_e//
DROP PROCEDURE IF EXISTS del_bill//
DROP PROCEDURE IF EXISTS load_payment//
DROP PROCEDURE IF EXISTS add_detailBill//
DROP PROCEDURE IF EXISTS add_all_registration_Ser_into_billdetail//
DROP PROCEDURE IF EXISTS load_registration_service_to_add//
DROP PROCEDURE IF EXISTS load_tenant_by_roomid//
DROP PROCEDURE IF EXISTS take_billid//
DROP PROCEDURE IF EXISTS calculate_bill//

DROP TRIGGER IF EXISTS before_del_Bill//
DROP TRIGGER IF EXISTS before_del_Billdetail//
DROP TRIGGER IF EXISTS before_del_W_E//

CREATE TRIGGER before_del_Bill
BEFORE DELETE ON bill
FOR EACH ROW
BEGIN	
   DELETE FROM water_electricity
   WHERE FIGUREID IN (
		SELECT ID FROM billdetail
		WHERE billdetail.BILLID = OLD.BILLID);
END//

CREATE PROCEDURE calculate_bill()
BEGIN
	DECLARE bill_id VARCHAR(20);
	
	SELECT b.BILLID INTO bill_id FROM bill b
	WHERE b.TOTAL IS NULL
	LIMIT 1;
	
   UPDATE bill 
	SET bill.TOTAL = (
		SELECT SUM(AMOUNT) FROM billdetail
		WHERE billdetail.BILLID = bill_id
	),
	bill.START_DATE = DATE_FORMAT(CURDATE(), '%Y-%m-01'),
	bill.END_DATE = LAST_DAY(CURDATE())
	WHERE bill.BILLID = bill_id;
   
END //

CREATE PROCEDURE take_billid()
BEGIN
   SELECT b.BILLID FROM bill b
	WHERE b.TOTAL IS NULL
	LIMIT 1;
END //

CREATE PROCEDURE load_registration_service_to_add(
	IN p_tenant_id VARCHAR(20)
)
BEGIN
   SELECT us.SERVICEID,s.UNITPRICE FROM use_service us
   JOIN service s ON s.SERVICEID = us.SERVICEID
   WHERE us.TENANTID = p_tenant_id;
END //

CREATE PROCEDURE load_tenant_by_roomid(
	IN p_room_id VARCHAR(20)
)
BEGIN
   SELECT t.TENANTID,t.FIRSTNAME,t.LASTNAME FROM tenant t
   JOIN contract c ON c.TENANTID = t.TENANTID
   WHERE c.ROOMID = p_room_id;
END //

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
	DECLARE id_1 VARCHAR(50);
	DECLARE id_2 VARCHAR(50);
	DECLARE bill_id VARCHAR(50);	
	DECLARE water VARCHAR(50);
	DECLARE electrcity VARCHAR(50);
	DECLARE amount_w VARCHAR(50);
	DECLARE amount_e VARCHAR(50);
   
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
    VALUES (new_ID_0, 'UP002',p_tenantID,  p_o_w, p_n_w, v_start_date, v_end_date,v_now,'WATER','m3');
	
	SELECT weu.UNITPRICE INTO water FROM water_elect_unitprice weu WHERE UNITPRICEID = 'UP002';
	SELECT weu.UNITPRICE INTO electrcity FROM water_elect_unitprice weu WHERE UNITPRICEID = 'UP001';
	
	SET amount_w = (p_n_w - p_o_w) * water;
	SET amount_e = (p_n_e - p_o_e) * electrcity;
	
	SET bill_id = createBillID();
	INSERT INTO bill (BILLID,TENANTID) 
	VALUES (bill_id,p_tenantID);
	
	SET id_1 = createBillDetailID();
	INSERT INTO billdetail (BILLDETAIL_ID,BILLID,ID,AMOUNT) 
	VALUES (id_1,bill_id,new_ID,amount_e);
	
	SET id_2 = createBillDetailID();
	INSERT INTO billdetail (BILLDETAIL_ID,BILLID,ID,AMOUNT) 
	VALUES (id_2,bill_id,new_ID_0,amount_w);
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
CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createBillDetailID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(b.BILLDETAIL_ID), 'HD000') INTO max_id FROM billdetail b;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('DB', LPAD(number_part, 3, '0'));
    RETURN new_id;
END//

CREATE PROCEDURE load_billdetail(
	IN p_billID VARCHAR(20)
)
BEGIN
   SELECT bd.BILLDETAIL_ID,bd.BILLID,bd.ID,s.SERVICENAME,bd.AMOUNT FROM billdetail bd 
   JOIN service s ON s.SERVICEID = bd.ID
   WHERE bd.BILLID = p_billID
	union
	SELECT bd.BILLDETAIL_ID,bd.BILLID,bd.ID,
	CASE 
        WHEN w.`TYPE` = 'WATER' THEN 'Nước'
        WHEN w.`TYPE` = 'ELECTRICITY' THEN 'Điện'
        ELSE w.`TYPE`
   END,bd.AMOUNT FROM billdetail bd 
   JOIN water_electricity w ON w.FIGUREID = bd.ID
	WHERE bd.BILLID = p_billID;
END//



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
   SELECT b.BILLID,b.TENANTID,t.FIRSTNAME,t.LASTNAME,b.TOTAL,b.START_DATE,b.END_DATE,COALESCE(p.TOTAL,0) AS TOTALS FROM   bill b
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