DELIMITER //

-- ===== CÁC STORED PROCEDURE VÀ FUNCTION CHO QUẢN LÝ BÃI ĐẬU XE =====

-- Thủ tục để lấy tất cả bãi đậu xe
CREATE PROCEDURE sp_GetAllParkingAreas()
BEGIN
    SELECT * FROM PARKINGAREA ORDER BY AREAID;
END //

-- Thủ tục để lấy danh sách ID tòa nhà
CREATE PROCEDURE sp_GetAllBuildings()
BEGIN
    SELECT BUILDINGID, ADDRESS FROM BUILDING ORDER BY BUILDINGID;
END //

-- Hàm để tạo ID tòa nhà mới tự động tăng
CREATE FUNCTION fn_GenerateNewBuildingId() 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(10);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(10);
    
    -- Lấy ID lớn nhất hiện tại, nếu không có thì mặc định là 'BD000'
    SELECT IFNULL(MAX(BUILDINGID), 'BD000') INTO max_id FROM BUILDING;
    
    -- Tách phần số và tăng lên 1
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    
    -- Tạo ID mới với format 'BDxxx' 
    SET new_id = CONCAT('BD', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END //
-- Thêm trigger để tự động cập nhật khi có tòa nhà mới
CREATE TRIGGER after_building_insert
AFTER INSERT ON BUILDING
FOR EACH ROW
BEGIN
    -- Tự động tạo một bản ghi trong bảng PARKINGAREA với thông tin mặc định
    DECLARE new_area_id VARCHAR(10);
    SET new_area_id = fn_GenerateNewParkingAreaId();
    
    -- Thêm bãi đậu xe mặc định cho tòa nhà mới
    INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
    VALUES (new_area_id, NEW.BUILDINGID, CONCAT('Khu vực trước tòa nhà ', NEW.BUILDINGID), 'Xe máy', 10);
END //

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

-- Thủ tục để lấy danh sách địa chỉ đã có trong bảng PARKINGAREA
CREATE PROCEDURE sp_GetParkingAddresses()
BEGIN
    SELECT DISTINCT ADDRESS FROM PARKINGAREA ORDER BY ADDRESS;
END //

-- Hàm để tạo ID bãi đậu xe mới tự động tăng
CREATE FUNCTION fn_GenerateNewParkingAreaId() 
RETURNS VARCHAR(10)
DETERMINISTIC
BEGIN
    DECLARE max_id VARCHAR(10);
    DECLARE number_part INT;
    DECLARE new_id VARCHAR(10);
    
    SELECT IFNULL(MAX(AREAID), 'PA000') INTO max_id FROM PARKINGAREA;
    SET number_part = CAST(SUBSTRING(max_id, 3) AS UNSIGNED) + 1;
    SET new_id = CONCAT('PA', LPAD(number_part, 3, '0'));
    
    RETURN new_id;
END //

-- Thủ tục để kiểm tra dữ liệu và thêm bãi đậu xe mới
CREATE PROCEDURE sp_AddParkingArea(
    IN p_buildingId VARCHAR(10),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT,
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    DECLARE new_area_id VARCHAR(10);
    
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Thêm bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_buildingId IS NULL OR p_buildingId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID tòa nhà không được để trống!';
    ELSEIF p_address IS NULL OR p_address = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Địa chỉ không được để trống!';
    ELSEIF p_type IS NULL OR p_type = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không được để trống!';
    ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
    ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Sức chứa phải là số nguyên dương!';
    ELSE
        -- Kiểm tra tòa nhà có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID tòa nhà không tồn tại!';
        ELSE
            -- Tạo ID mới
            SET new_area_id = fn_GenerateNewParkingAreaId();
            
            -- Thực hiện thêm dữ liệu
            INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY)
            VALUES (new_area_id, p_buildingId, p_address, p_type, p_capacity);
            
            -- Trả về ID mới tạo trong thông báo
            SET p_message = CONCAT('Thêm bãi đậu xe thành công! ID mới: ', new_area_id);
        END IF;
    END IF;
END //

-- Thủ tục để khởi tạo dữ liệu form
CREATE PROCEDURE sp_InitParkingAreaForm(
    OUT p_new_area_id VARCHAR(10)
)
BEGIN
    -- Tạo ID mới
    SET p_new_area_id = fn_GenerateNewParkingAreaId();
END //

-- Thủ tục để cập nhật bãi đậu xe
CREATE PROCEDURE sp_UpdateParkingArea(
    IN p_areaId VARCHAR(10),
    IN p_buildingId VARCHAR(10),
    IN p_address VARCHAR(100),
    IN p_type VARCHAR(50),
    IN p_capacity INT,
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Cập nhật bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_areaId IS NULL OR p_areaId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID bãi đậu xe không được để trống!';
    ELSEIF p_buildingId IS NULL OR p_buildingId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID tòa nhà không được để trống!';
    ELSEIF p_address IS NULL OR p_address = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Địa chỉ không được để trống!';
    ELSEIF p_type IS NULL OR p_type = '' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không được để trống!';
    ELSEIF p_type != 'Xe máy' AND p_type != 'Ô tô' THEN
        SET p_success = FALSE;
        SET p_message = 'Loại bãi đậu xe không hợp lệ. Chỉ chấp nhận "Xe máy" hoặc "Ô tô"!';
    ELSEIF p_capacity IS NULL OR p_capacity <= 0 THEN
        SET p_success = FALSE;
        SET p_message = 'Sức chứa phải là số nguyên dương!';
    ELSE
        -- Kiểm tra bãi đậu xe có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID bãi đậu xe không tồn tại!';
        ELSE
            -- Kiểm tra tòa nhà có tồn tại không
            IF NOT EXISTS (SELECT 1 FROM BUILDING WHERE BUILDINGID = p_buildingId) THEN
                SET p_success = FALSE;
                SET p_message = 'ID tòa nhà không tồn tại!';
            ELSE
                -- Thực hiện cập nhật dữ liệu
                UPDATE PARKINGAREA
                SET BUILDINGID = p_buildingId, 
                    ADDRESS = p_address, 
                    TYPE = p_type, 
                    CAPACITY = p_capacity
                WHERE AREAID = p_areaId;
            END IF;
        END IF;
    END IF;
END //

-- Thủ tục để xóa bãi đậu xe
CREATE PROCEDURE sp_DeleteParkingArea(
    IN p_areaId VARCHAR(10),
    OUT p_message VARCHAR(255),
    OUT p_success BOOLEAN
)
BEGIN
    -- Mặc định thành công
    SET p_success = TRUE;
    SET p_message = 'Xóa bãi đậu xe thành công!';
    
    -- Kiểm tra dữ liệu đầu vào
    IF p_areaId IS NULL OR p_areaId = '' THEN
        SET p_success = FALSE;
        SET p_message = 'ID bãi đậu xe không được để trống!';
    ELSE
        -- Kiểm tra bãi đậu xe có tồn tại không
        IF NOT EXISTS (SELECT 1 FROM PARKINGAREA WHERE AREAID = p_areaId) THEN
            SET p_success = FALSE;
            SET p_message = 'ID bãi đậu xe không tồn tại!';
        ELSE
            -- Kiểm tra có xe đang đậu không
            IF EXISTS (SELECT 1 FROM PARKING WHERE AREAID = p_areaId) THEN
                SET p_success = FALSE;
                SET p_message = 'Không thể xóa bãi đậu xe đang có xe!';
            ELSE
                -- Thực hiện xóa dữ liệu
                DELETE FROM PARKINGAREA WHERE AREAID = p_areaId;
            END IF;
        END IF;
    END IF;
END //

-- Thủ tục để lấy thông tin sức chứa của bãi đậu xe
CREATE PROCEDURE sp_GetParkingAreaCapacity(
    IN p_areaId VARCHAR(10),
    OUT p_totalCapacity INT,
    OUT p_usedCapacity INT,
    OUT p_availableCapacity INT
)
BEGIN
    -- Lấy tổng sức chứa
    SELECT CAPACITY INTO p_totalCapacity
    FROM PARKINGAREA
    WHERE AREAID = p_areaId;
    
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
    SELECT * FROM PARKINGAREA WHERE TYPE = p_type ORDER BY AREAID;
END //

-- Thủ tục để lấy tất cả bãi đậu xe theo tòa nhà
CREATE PROCEDURE sp_GetParkingAreasByBuilding(
    IN p_buildingId VARCHAR(10)
)
BEGIN
    SELECT * FROM PARKINGAREA WHERE BUILDINGID = p_buildingId ORDER BY AREAID;
END //

DELIMITER ;