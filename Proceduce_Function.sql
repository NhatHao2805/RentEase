DELIMITER //

CREATE PROCEDURE load_Contract(IN p_username VARCHAR(50))
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
   WHERE u.USERNAME = p_username;
END//

CREATE PROCEDURE `proc_addAccount`(
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

CREATE PROCEDURE `proc_login`(
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

CREATE PROCEDURE load_Room(IN p_username VARCHAR(50))
BEGIN
    SELECT 
        r.ROOMID, 
        r.BUILDINGID, 
        r.TYPE, 
        r.CONVENIENT, 
        r.AREA, 
        r.PRICE, 
        r.STATUS, 
        r.LAST_MAINTENANCE_DATE 
    FROM room r
    JOIN building b ON r.BUILDINGID = b.BUILDINGID
    JOIN user u ON u.USERNAME = b.USERNAME
    WHERE u.USERNAME = p_username;
END//

CREATE FUNCTION `check_account`(
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

CREATE FUNCTION `createContractID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(ContractID), 'CT000') INTO max_id FROM contract;

    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;

    SET new_id = CONCAT('CT', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END//

DELIMITER ;