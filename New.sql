DELIMITER //

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


DELIMITER ;