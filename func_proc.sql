-- proc
CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_addRoom`(
	IN new_roomid 		VARCHAR(20), 
    IN new_buildingid 	VARCHAR(10),
    IN new_type       	VARCHAR(50),
    IN new_convenient   VARCHAR(200),
    IN new_price        FLOAT,
    IN new_area        	FLOAT,
    IN new_status       VARCHAR(50),
    IN new_last_maintenance_date 	DATE
    )
BEGIN
    -- Kiểm tra xem phòng đã tồn tại chưa
    IF NOT EXISTS (SELECT 1 FROM ROOM WHERE ROOMID = new_roomid) THEN
        -- Nếu không tồn tại, thêm phòng mới
        INSERT INTO ROOM (ROOMID, BUILDINGID, TYPE, CONVENIENT, PRICE, AREA, STATUS, LAST_MAINTENANCE_DATE) 
				VALUES 	(new_roomid, new_buildingid, new_type, new_convenient, new_price, new_area, new_status, new_last_maintenance_date);
    END IF;
END;

--func
CREATE DEFINER=`root`@`localhost` FUNCTION `check_Room`(new_roomid VARCHAR(100)) RETURNS int
    DETERMINISTIC
BEGIN
    DECLARE result INT;

    IF NOT EXISTS (SELECT 1 FROM ROOM WHERE ROOMID = new_roomid) THEN
        SET result = 1;
    ELSE
        SET result = 0;
    END IF;

    RETURN result;
END