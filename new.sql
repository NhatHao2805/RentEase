DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_FilterAssets`(
    IN p_username VARCHAR(20),
    IN p_sort_order VARCHAR(10), -- NULL, 'ASC' hoặc 'DESC'
    IN p_asset_name VARCHAR(100), -- Tên tài sản để tìm kiếm (có thể để NULL)
    IN p_buildingid VARCHAR(20)
)
BEGIN
    SELECT 
        r.ROOMID,
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `load_Room`(
    IN p_username VARCHAR(20), 
    IN p_buildingid VARCHAR(10))
BEGIN
	IF p_buildingid is null then
		SELECT 
			r.ROOMID, 
			r.BUILDINGID, 
			r.FLOOR,
			r.TYPE, 
			r.CONVENIENT, 
			r.AREA, 
			r.PRICE, 
			r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		JOIN USER u ON u.USERNAME = b.USERNAME
		WHERE u.USERNAME = p_username;
	ELSE
		SELECT 
			r.ROOMID, 
			r.BUILDINGID, 
			r.FLOOR,
			r.TYPE, 
			r.CONVENIENT, 
			r.AREA, 
			r.PRICE, 
			r.STATUS
		FROM ROOM r
		JOIN BUILDING b ON r.BUILDINGID = b.BUILDINGID
		JOIN USER u ON u.USERNAME = b.USERNAME
		WHERE u.USERNAME = p_username AND b.BUILDINGID = p_buildingid;
	END IF;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `load_RentalHistory`(
    IN p_username VARCHAR(50),
    IN p_buildingid VARCHAR(20))
BEGIN
    SELECT 
        rh.CONTRACTID AS RENTAL_HISTORY_ID,
        c.CONTRACTID,
        r.ROOMID,
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
        r.BUILDINGID,
        b.ADDRESS AS BUILDING_ADDRESS
    FROM 
        RENTAL_HISTORY rh
    JOIN 
        CONTRACT c ON rh.CONTRACTID = c.CONTRACTID
    JOIN 
        TENANT t ON c.TENANTID = t.TENANTID
    JOIN 
        ROOM r ON c.ROOMID = r.ROOMID
    JOIN 
        BUILDING b ON r.BUILDINGID = b.BUILDINGID
    WHERE 
        b.USERNAME = p_username
        AND  r.BUILDINGID = p_buildingid
    ORDER BY 
        rh.ENDDATE DESC;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `load_Assets`(
    IN p_username VARCHAR(50),
    IN p_buildingid VARCHAR(20))
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
    AND (p_buildingid IS NULL OR r.BUILDINGID = p_buildingid)
    ORDER BY a.USE_DATE DESC;
END//

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AssetDetails`(
    IN p_username VARCHAR(20),
    IN p_buildingid VARCHAR(20))
BEGIN
    -- Thông tin tài sản được gán cho user này (có lọc theo tòa nhà nếu cần)
    SELECT 
        a.ASSETID,
        a.ASSETNAME,
        a.PRICE,
        a.STATUS AS ASSET_STATUS,
        DATE_FORMAT(a.USE_DATE, '%d/%m/%Y') AS USE_DATE,
        r.ROOMID,
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
        AND (p_buildingid IS NULL OR b.BUILDINGID = p_buildingid)
    ORDER BY 
        rr.REQUEST_DATE DESC
    LIMIT 50; -- Giới hạn kết quả
END//