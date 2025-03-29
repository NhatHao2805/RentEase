
DELIMITER //
CREATE PROCEDURE GetServiceUsage()
BEGIN
    -- Khai báo biến STT toàn cục
    SET @row_num = 0;

    -- Lấy danh sách dịch vụ đã sử dụng
    SELECT 
        (@row_num := @row_num + 1) AS STT,  -- Số thứ tự tự động tăng
        R.ROOMID, 
        CONCAT(T.FIRSTNAME, ' ', T.LASTNAME) AS TENANTNAME,  -- Ghép họ và tên
        S.SERVICENAME, 
        S.UNITPRICE,
        US.START_DATE,
        US.END_DATE
    FROM USE_SERVICE US
    JOIN TENANT T ON US.TENANTID = T.TENANTID
    JOIN SERVICE S ON US.SERVICEID = S.SERVICEID
    JOIN CONTRACT C ON C.TENANTID = T.TENANTID
    JOIN ROOM R ON C.ROOMID = R.ROOMID;
    
END //

DELIMITER ;
-- || ------------------------------------------------------------------------------------------------
DELIMITER //
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
DELIMITER ;
-- ||--------------------------------------------------------------------
DELIMITER //
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
DELIMITER ;
-- ||--------------------------------------------------------------------
DELIMITER //

CREATE PROCEDURE DeleteTenantService(
    IN p_TenantID VARCHAR(10),
    IN p_ServiceID VARCHAR(10)
)
BEGIN
    DELETE FROM use_service
    WHERE TENANTID = p_TenantID AND SERVICEID = p_ServiceID;
END //
DELIMITER ;
-- || -----------------------------------------------------------
DELIMITER //

CREATE PROCEDURE DeleteDichVu(IN p_serviceID VARCHAR(10))
BEGIN
    DELETE FROM service WHERE service.SERVICEID = p_serviceID;
END//

DELIMITER ;
-- || ------------------------------------------------------
DELIMITER //
CREATE PROCEDURE UpdateServicePrice(
    IN p_ServiceID VARCHAR(255),
    IN p_NewPrice DECIMAL(10,2)
)
BEGIN
    UPDATE service 
    SET UNITPRICE = p_NewPrice
    WHERE SERVICEID = p_ServiceID;
END //
DELIMITER ;


