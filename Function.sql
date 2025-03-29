DELIMITER //

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `check_account`(
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

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createBuildingID`() 
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

CREATE DEFINER=`root`@`localhost` FUNCTION IF NOT EXISTS `createContractID`()
RETURNS VARCHAR(20) 
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(20);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(20);
    
    SELECT IFNULL(MAX(ContractID), 'c000') INTO max_id FROM Contract;
    SET number_part = CAST(SUBSTRING(max_id, 2) AS UNSIGNED) + 1;
    SET new_id = CONCAT('c', LPAD(number_part, 3, '0'));
    RETURN new_id;
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
    
    SELECT COUNT(*) INTO max_rooms_on_floor
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
    
    -- Tìm số phòng lớn nhất hiện có trên tầng này của tòa nhà
    SELECT IFNULL(MAX(CAST(SUBSTRING(ROOMID, 5) AS UNSIGNED)), 0) + 1 INTO next_room_num
    FROM ROOM 
    WHERE BUILDINGID = building_id AND FLOOR = floor_num
    AND ROOMID LIKE CONCAT('R', floor_num, '%');
    
    -- Tạo mã phòng mới (ví dụ: R101, R102,...)
    SET new_room_id = CONCAT('R', floor_num, LPAD(next_room_num, 2, '0'));
    
    RETURN new_room_id;
END//


