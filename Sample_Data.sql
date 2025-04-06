-- 1 USER
INSERT INTO USER (USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS) VALUES
('ad', 'Nguyễn Văn An', 'ad', 'admin1@rentease.com', '1980-05-15', 'Nam', '0912345678', '123 Đường Lê Lợi, Q1, TP.HCM'),
('manager02', 'Trần Thị Bình', 'manager@123', 'manager2@rentease.com', '1985-08-20', 'Nữ', '0987654321', '456 Đường Nguyễn Huệ, Q1, TP.HCM'),
('owner03', 'Lê Hoàng Cường', 'owner@123', 'owner3@rentease.com', '1975-11-10', 'Nam', '0909123456', '789 Đường Pasteur, Q3, TP.HCM'),
('staff04', 'Phạm Thị Dung', 'staff@123', 'staff4@rentease.com', '1990-03-25', 'Nữ', '0911222333', '321 Đường CMT8, Q10, TP.HCM'),
('supervisor05', 'Vũ Văn Em', 'super@123', 'super5@rentease.com', '1982-07-30', 'Nam', '0988999888', '654 Đường 3/2, Q11, TP.HCM'),
('operator06', 'Nguyễn Thị Phương', 'operator@123', 'operator6@rentease.com', '1992-09-12', 'Nữ', '0912345999', '987 Đường Lý Thường Kiệt, Q.Tân Bình, TP.HCM'),
('director07', 'Trần Văn Giang', 'director@123', 'director7@rentease.com', '1978-12-05', 'Nam', '0988123123', '147 Đường Lê Văn Sỹ, Q.Phú Nhuận, TP.HCM'),
('accountant08', 'Hoàng Thị Hương', 'account@123', 'account8@rentease.com', '1987-04-18', 'Nữ', '0909876543', '258 Đường Nguyễn Trãi, Q5, TP.HCM'),
('technician09', 'Phan Văn Long', 'tech@123', 'tech9@rentease.com', '1983-06-22', 'Nam', '0912456789', '369 Đường Bà Hạt, Q10, TP.HCM'),
('reception10', 'Lý Thị Mai', 'reception@123', 'reception10@rentease.com', '1991-02-14', 'Nữ', '0987654321', '753 Đường Lạc Long Quân, Q.Tân Bình, TP.HCM');

-- 2 BUILDING
INSERT INTO BUILDING (BUILDINGID, BUILDING_KEY, USERNAME, ADDRESS, NUMOFFLOORS, NUMOFROOMS) VALUES
('B001', 'BLD001', 'ad', '123 Đường Lê Lợi, Q1, TP.HCM', 5, 20),
('B002', 'BLD002', 'ad', '456 Đường Nguyễn Huệ, Q1, TP.HCM', 3, 12),
('B003', 'BLD003', 'ad', '789 Đường Pasteur, Q3, TP.HCM', 7, 30),
('B004', 'BLD004', 'staff04', '321 Đường CMT8, Q10, TP.HCM', 4, 15),
('B005', 'BLD005', 'supervisor05', '654 Đường 3/2, Q11, TP.HCM', 6, 25),
('B006', 'BLD006', 'operator06', '987 Đường Lý Thường Kiệt, Q.Tân Bình, TP.HCM', 2, 8),
('B007', 'BLD007', 'director07', '147 Đường Lê Văn Sỹ, Q.Phú Nhuận, TP.HCM', 8, 35),
('B008', 'BLD008', 'accountant08', '258 Đường Nguyễn Trãi, Q5, TP.HCM', 3, 10),
('B009', 'BLD009', 'technician09', '369 Đường Bà Hạt, Q10, TP.HCM', 5, 18),
('B010', 'BLD010', 'reception10', '753 Đường Lạc Long Quân, Q.Tân Bình, TP.HCM', 4, 16);

-- 3 ROOM
INSERT INTO ROOM (ROOMID, BUILDINGID, TYPE, FLOOR, CONVENIENT, AREA, PRICE, STATUS) VALUES
('R001', 'B001', 'Studio', 1, 'Điều hòa, Wifi, Tủ lạnh', 25.5, 5000000, 'Đang ở; Sắp hết hạn hợp đồng'),
('R002', 'B001', '1 Phòng ngủ', 2, 'Điều hòa, Wifi, Máy giặt', 35.0, 7000000, 'Đang trống'),
('R003', 'B002', '2 Phòng ngủ', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 45.5, 9000000, 'Đang ở; Đang nợ tiền'),
('R004', 'B003', 'Studio', 1, 'Điều hòa, Wifi', 22.0, 4500000, 'Đang báo kết thúc; Đã quá hạn hợp đồng'),
('R005', 'B004', '1 Phòng ngủ', 2, 'Điều hòa, Wifi, Tủ lạnh', 30.0, 6000000, 'Đang trống'),
('R006', 'B005', '3 Phòng ngủ', 4, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt, Bếp', 60.0, 12000000, 'Đang ở; Sắp hết hạn hợp đồng; Đang nợ tiền'),
('R007', 'B006', 'Studio', 1, 'Điều hòa, Wifi', 20.0, 4000000, 'Đang cọc giữ chỗ'),
('R008', 'B007', '2 Phòng ngủ', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 42.0, 8500000, 'Đang ở; Đã quá hạn hợp đồng'),
('R009', 'B008', '1 Phòng ngủ', 2, 'Điều hòa, Wifi', 28.0, 5500000, 'Đang trống'),
('R010', 'B009', 'Studio', 1, 'Điều hòa, Wifi, Tủ lạnh', 24.0, 4800000, 'Đang ở');

-- 4 TENANT
INSERT INTO TENANT (USERNAME, TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL) VALUES
('ad', 'T001', 'Lê Văn', 'Cường', '1990-07-25', 'Nam', '0911222333', 'tenant1@gmail.com'),
('ad', 'T002', 'Phạm Thị', 'Dung', '1995-03-12', 'Nữ', '0988777666', 'tenant2@gmail.com'),
('ad', 'T003', 'Hoàng Văn', 'Em', '1988-11-05', 'Nam', '0909123456', 'tenant3@gmail.com'),
('staff04', 'T004', 'Nguyễn Thị', 'Giang', '1992-09-18', 'Nữ', '0912345678', 'tenant4@gmail.com'),
('staff04', 'T005', 'Trần Văn', 'Hải', '1985-04-30', 'Nam', '0987654321', 'tenant5@gmail.com'),
('operator06', 'T006', 'Vũ Thị', 'Lan', '1993-12-15', 'Nữ', '0909876543', 'tenant6@gmail.com'),
('operator06', 'T007', 'Phan Văn', 'Minh', '1987-06-22', 'Nam', '0912456789', 'tenant7@gmail.com'),
('accountant08', 'T008', 'Lý Thị', 'Nga', '1991-02-14', 'Nữ', '0988999888', 'tenant8@gmail.com'),
('technician09', 'T009', 'Đặng Văn', 'Phong', '1983-08-10', 'Nam', '0911222444', 'tenant9@gmail.com'),
('reception10', 'T010', 'Bùi Thị', 'Quỳnh', '1994-05-28', 'Nữ', '0909111222', 'tenant10@gmail.com');

-- 5 CONTRACT
INSERT INTO CONTRACT (CONTRACTID, ROOMID, TENANTID, CREATEDATE, STARTDATE, ENDDATE, MONTHLYRENT, PAYMENTSCHEDULE, DEPOSIT, STATUS, NOTES, AUTO_RENEW, TERMINATION_REASON, CONTRACT_FILE_PATH) VALUES
('CT001', 'R001', 'T001', '2024-01-10', '2024-01-15', '2025-01-14', 5000000, 'Đầu tháng', 10000000, 'InActive', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct001.pdf'),
('CT002', 'R003', 'T002', '2024-02-05', '2024-02-10', '2024-08-09', 9000000, 'Cuối tháng', 18000000, 'Active', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct002.pdf'),
('CT003', 'R004', 'T003', '2024-03-01', '2024-03-05', '2025-03-04', 4500000, 'Đầu tháng', 9000000, 'Active', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct003.pdf'),
('CT004', 'R006', 'T004', '2024-04-15', '2024-04-20', '2024-10-19', 12000000, 'Cuối tháng', 24000000, 'Active', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct004.pdf'),
('CT005', 'R008', 'T005', '2024-05-10', '2024-05-15', '2025-05-14', 8500000, 'Đầu tháng', 17000000, 'Active', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct005.pdf'),
('CT006', 'R010', 'T006', '2024-06-05', '2024-06-10', '2024-12-09', 4800000, 'Cuối tháng', 9600000, 'Active', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct006.pdf'),
('CT007', 'R002', 'T007', '2024-07-01', '2024-07-05', '2025-07-04', 7000000, 'Đầu tháng', 14000000, 'InActive', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct007.pdf'),
('CT008', 'R005', 'T008', '2024-08-15', '2024-08-20', '2025-02-19', 6000000, 'Cuối tháng', 12000000, 'Active', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct008.pdf'),
('CT009', 'R007', 'T009', '2024-09-10', '2024-09-15', '2025-09-14', 4000000, 'Đầu tháng', 8000000, 'Active', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct009.pdf'),
('CT010', 'R009', 'T010', '2024-10-05', '2024-10-10', '2025-04-09', 5500000, 'Cuối tháng', 11000000, 'Active', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct010.pdf');

-- 6 SERVICE
INSERT INTO SERVICE (SERVICEID, SERVICENAME, UNITPRICE) VALUES
('SV001', 'Dọn phòng hàng tuần', 500000),
('SV002', 'Giặt ủi', 300000),
('SV003', 'Bảo vệ 24/7', 1000000),
('SV004', 'Gửi xe máy', 500000),
('SV005', 'Gửi ô tô', 1500000),
('SV006', 'Internet tốc độ cao', 300000),
('SV007', 'Truyền hình cáp', 200000),
('SV008', 'Điện nước', 0),
('SV009', 'Dịch vụ phòng gym', 800000),
('SV010', 'Dịch vụ bể bơi', 600000);

-- 7 USE_SERVICE
INSERT INTO USE_SERVICE (TENANTID, SERVICEID, START_DATE, END_DATE) VALUES
('T001', 'SV001', '2024-01-15', '2025-01-14'),
('T001', 'SV003', '2024-01-15', '2025-01-14'),
('T001', 'SV006', '2024-01-15', '2025-01-14'),
('T002', 'SV002', '2024-02-10', '2024-08-09'),
('T002', 'SV004', '2024-02-10', '2024-08-09'),
('T003', 'SV003', '2024-03-05', '2025-03-04'),
('T003', 'SV007', '2024-03-05', '2025-03-04'),
('T004', 'SV005', '2024-04-20', '2024-10-19'),
('T004', 'SV009', '2024-04-20', '2024-10-19'),
('T005', 'SV001', '2024-05-15', '2025-05-14');

-- 8 BILL
INSERT INTO BILL (BILLID, TENANTID, TOTAL, START_DATE, END_DATE, NOTIFICATION_SENT, REFUND_AMOUNT) VALUES
('HD001', 'T001', 5800000, '2024-01-15', '2024-02-14', TRUE, 0),
('HD002', 'T002', 9800000, '2024-02-10', '2024-03-09', TRUE, 0),
('HD003', 'T003', 5000000, '2024-03-05', '2024-04-04', TRUE, 0),
('HD004', 'T004', 13500000, '2024-04-20', '2024-05-19', TRUE, 0),
('HD005', 'T005', 9350000, '2024-05-15', '2024-06-14', TRUE, 0),
('HD006', 'T001', 5800000, '2024-02-15', '2024-03-14', TRUE, 0),
('HD007', 'T002', 9800000, '2024-03-10', '2024-04-09', TRUE, 0),
('HD008', 'T003', 5000000, '2024-04-05', '2024-05-04', TRUE, 0),
('HD009', 'T004', 13500000, '2024-05-20', '2024-06-19', TRUE, 0),
('HD010', 'T005', 9350000, '2024-06-15', '2024-07-14', FALSE, 0);

-- 9 WATER_ELEC_UNITPRICE
INSERT INTO WATER_ELECT_UNITPRICE (UNITPRICEID, TYPE, UNITPRICE) VALUES
('UP001', 'ELECTRICITY', 3500),  -- 3,500 VND/kWh
('UP002', 'WATER', 10000);       -- 10,000 VND/m3

-- 10 WATER_ELECTRICITY
INSERT INTO WATER_ELECTRICITY (FIGUREID, UNITPRICEID, TENANTID, OLDFIGURE, NEWFIGURE, UNIT, START_DATE, END_DATE, RECORD_DATE, TYPE) VALUES
('CS001', 'UP001', 'T001', 100, 150, 'kWh', '2024-01-15', '2024-02-14', '2024-02-14', 'ELECTRICITY'),
('CS002', 'UP002', 'T001', 50, 70, 'm3', '2024-01-15', '2024-02-14', '2024-02-14', 'WATER'),
('CS003', 'UP001', 'T002', 120, 180, 'kWh', '2024-02-10', '2024-03-09', '2024-03-09', 'ELECTRICITY'),
('CS004', 'UP002', 'T002', 60, 85, 'm3', '2024-02-10', '2024-03-09', '2024-03-09', 'WATER'),
('CS005', 'UP001', 'T003', 80, 120, 'kWh', '2024-03-05', '2024-04-04', '2024-04-04', 'ELECTRICITY'),
('CS006', 'UP002', 'T003', 40, 55, 'm3', '2024-03-05', '2024-04-04', '2024-04-04', 'WATER'),
('CS007', 'UP001', 'T004', 150, 220, 'kWh', '2024-04-20', '2024-05-19', '2024-05-19', 'ELECTRICITY'),
('CS008', 'UP002', 'T004', 70, 100, 'm3', '2024-04-20', '2024-05-19', '2024-05-19', 'WATER'),
('CS009', 'UP001', 'T005', 90, 140, 'kWh', '2024-05-15', '2024-06-14', '2024-06-14', 'ELECTRICITY'),
('CS010', 'UP002', 'T005', 45, 65, 'm3', '2024-05-15', '2024-06-14', '2024-06-14', 'WATER');

-- 11 BILL_DETAIL
INSERT INTO BILLDETAIL (BILLDETAIL_ID, BILLID, SERVICEID, FIGUREID, AMOUNT) VALUES
('BD001', 'HD001', 'SV001', 'CS001', 500000),
('BD002', 'HD001', 'SV002', 'CS002', 1000000),
('BD003', 'HD001', 'SV003', 'CS003', 300000),
('BD004', 'HD002', 'SV004', 'CS004', 300000),
('BD005', 'HD002', 'SV005', 'CS005', 500000),
('BD006', 'HD003', 'SV006', 'CS006', 1000000);

-- 12 PAYMENT
INSERT INTO PAYMENT (PAYMENTID, BILLID, METHOD, TOTAL, PAYMENTTIME) VALUES
('TT001', 'HD001', 'Chuyển khoản', 5800000, UNIX_TIMESTAMP('2024-01-20')),
('TT002', 'HD002', 'Tiền mặt', 9800000, UNIX_TIMESTAMP('2024-02-15')),
('TT003', 'HD003', 'Chuyển khoản', 5000000, UNIX_TIMESTAMP('2024-03-10')),
('TT004', 'HD004', 'Thẻ tín dụng', 13500000, UNIX_TIMESTAMP('2024-04-25')),
('TT005', 'HD005', 'Chuyển khoản', 9350000, UNIX_TIMESTAMP('2024-05-20')),
('TT006', 'HD006', 'Tiền mặt', 5800000, UNIX_TIMESTAMP('2024-02-20')),
('TT007', 'HD007', 'Chuyển khoản', 9800000, UNIX_TIMESTAMP('2024-03-15')),
('TT008', 'HD008', 'Thẻ tín dụng', 5000000, UNIX_TIMESTAMP('2024-04-10')),
('TT009', 'HD009', 'Chuyển khoản', 13500000, UNIX_TIMESTAMP('2024-05-25')),
('TT010', 'HD010', 'Tiền mặt', 9350000, UNIX_TIMESTAMP('2024-06-20'));

-- 13 VEHICLE
INSERT INTO VEHICLE (VEHICLEID, TENANTID, TYPE, LICENSEPLATE) VALUES
('XE001', 'T001', 'Xe máy', '51A-12345'),
('XE002', 'T002', 'Xe máy', '51B-54321'),
('XE003', 'T003', 'Xe ô tô', '51C-67890'),
('XE004', 'T004', 'Xe ô tô', '51D-09876'),
('XE005', 'T005', 'Xe máy', '51E-11223'),
('XE006', 'T006', 'Xe máy', '51F-33445'),
('XE007', 'T007', 'Xe ô tô', '51G-55667'),
('XE008', 'T008', 'Xe máy', '51H-77889'),
('XE009', 'T009', 'Xe máy', '51K-99001'),
('XE010', 'T010', 'Xe ô tô', '51L-22334');

-- 14 PARKINGAREA
INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY) VALUES
('PA001', 'B001', 'Tầng hầm B1', 'Xe máy', 50),
('PA002', 'B001', 'Tầng hầm B2', 'Ô tô', 20),
('PA003', 'B002', 'Khu vực sau tòa nhà', 'Xe máy', 30),
('PA004', 'B003', 'Tầng hầm B1', 'Xe máy', 40),
('PA005', 'B003', 'Tầng hầm B2', 'Ô tô', 15),
('PA006', 'B004', 'Khu vực trước tòa nhà', 'Xe máy', 25),
('PA007', 'B005', 'Tầng hầm B1', 'Xe máy', 35),
('PA008', 'B005', 'Tầng hầm B2', 'Ô tô', 10),
('PA009', 'B006', 'Khu vực bên hông', 'Xe máy', 20),
('PA010', 'B007', 'Tầng hầm B1', 'Xe máy', 45);


-- 15 ASSETS
INSERT INTO ASSETS (ASSETID, ROOMID, ASSETNAME, PRICE, STATUS, USE_DATE) VALUES
('TS001', 'R001', 'Điều hòa', 8000000, 'Tốt', '2023-12-01'),
('TS002', 'R001', 'Tủ lạnh', 7000000, 'Tốt', '2023-12-01'),
('TS003', 'R002', 'Điều hòa', 8000000, 'Tốt', '2023-12-15'),
('TS004', 'R002', 'Máy giặt', 6000000, 'Tốt', '2023-12-15'),
('TS005', 'R003', 'Điều hòa', 8000000, 'Tốt', '2024-01-05'),
('TS006', 'R003', 'Tủ lạnh', 7000000, 'Tốt', '2024-01-05'),
('TS007', 'R003', 'Máy giặt', 6000000, 'Tốt', '2024-01-05'),
('TS008', 'R004', 'Điều hòa', 8000000, 'Tốt', '2024-02-01'),
('TS009', 'R005', 'Điều hòa', 8000000, 'Tốt', '2024-03-01'),
('TS010', 'R005', 'Tủ lạnh', 7000000, 'Tốt', '2024-03-01');

-- 16 MAINTENANCE
INSERT INTO MAINTENANCE (MAINTENANCEID, ASSETID, MAINTENANCE_DATE, DESCRIPTION, STATUS) VALUES
('BT001', 'TS001', '2024-01-15', 'Vệ sinh điều hòa', 'Hoàn thành'),
('BT002', 'TS002', '2024-01-15', 'Kiểm tra tủ lạnh', 'Hoàn thành'),
('BT003', 'TS003', '2024-02-20', 'Bảo dưỡng điều hòa', 'Hoàn thành'),
('BT004', 'TS004', '2024-02-20', 'Kiểm tra máy giặt', 'Hoàn thành'),
('BT005', 'TS005', '2024-03-10', 'Vệ sinh điều hòa', 'Hoàn thành'),
('BT006', 'TS006', '2024-03-10', 'Kiểm tra tủ lạnh', 'Hoàn thành'),
('BT007', 'TS007', '2024-03-10', 'Bảo dưỡng máy giặt', 'Hoàn thành'),
('BT008', 'TS008', '2024-04-05', 'Vệ sinh điều hòa', 'Hoàn thành'),
('BT009', 'TS009', '2024-05-12', 'Kiểm tra điều hòa', 'Hoàn thành'),
('BT010', 'TS010', '2024-05-12', 'Bảo dưỡng tủ lạnh', 'Hoàn thành');

-- 17 REPAIR_REQUEST
INSERT INTO REPAIR_REQUEST (REQUESTID, ASSETID, TENANTID, REQUEST_DATE, DESCRIPTION, STATUS) VALUES
('YC001', 'TS001', 'T001', '2024-01-20', 'Điều hòa chảy nước', 'Đã xử lý'),
('YC002', 'TS002', 'T001', '2024-01-25', 'Tủ lạnh không lạnh', 'Đã xử lý'),
('YC003', 'TS003', 'T002', '2024-02-15', 'Máy giặt không vắt', 'Đã xử lý'),
('YC004', 'TS004', 'T002', '2024-02-20', 'Điều hòa không mát', 'Đã xử lý'),
('YC005', 'TS005', 'T003', '2024-03-12', 'Tủ lạnh kêu to', 'Đã xử lý'),
('YC006', 'TS006', 'T003', '2024-03-15', 'Máy giặt rò rỉ nước', 'Đã xử lý'),
('YC007', 'TS007', 'T004', '2024-04-25', 'Điều hòa không hoạt động', 'Đã xử lý'),
('YC008', 'TS008', 'T004', '2024-05-05', 'Tủ lạnh đóng tuyết', 'Đã xử lý'),
('YC009', 'TS009', 'T005', '2024-05-20', 'Máy giặt không cấp nước', 'Đã xử lý'),
('YC010', 'TS010', 'T005', '2024-06-10', 'Điều hòa không lạnh', 'Đang xử lý');

-- 18 FINGERPRINTS
INSERT INTO FINGERPRINTS (FINGERID, USERNAME, TENANTID, AREAPERMISSION, ENROLLMENT_DATE) VALUES
('VT001', 'ad', 'T001', 'Tất cả khu vực', '2024-01-10'),
('VT002', 'manager02', 'T002', 'Phòng riêng, khu vực chung', '2024-02-05'),
('VT003', 'owner03', 'T003', 'Phòng riêng, khu vực chung', '2024-03-01'),
('VT004', 'staff04', 'T004', 'Phòng riêng, khu vực chung, phòng gym', '2024-04-15'),
('VT005', 'supervisor05', 'T005', 'Phòng riêng, khu vực chung, bể bơi', '2024-05-10'),
('VT006', 'operator06', 'T006', 'Phòng riêng, khu vực chung', '2024-06-05'),
('VT007', 'director07', 'T007', 'Phòng riêng, khu vực chung, phòng gym', '2024-07-01'),
('VT008', 'accountant08', 'T008', 'Phòng riêng, khu vực chung', '2024-08-15'),
('VT009', 'technician09', 'T009', 'Phòng riêng, khu vực chung, bể bơi', '2024-09-10'),
('VT010', 'reception10', 'T010', 'Phòng riêng, khu vực chung', '2024-10-05');

-- 19 FEEDBACK
INSERT INTO FEEDBACK (FEEDBACKID, TENANTID, TYPE, CONTENT, DATESEND, STATUS) VALUES
('PH001', 'T001', 'Chất lượng phòng', 'Phòng sạch sẽ, đầy đủ tiện nghi', '2024-01-25', 'RESOLVED'),
('PH002', 'T002', 'Dịch vụ', 'Nhân viên nhiệt tình, thân thiện', '2024-02-15', 'RESOLVED'),
('PH003', 'T003', 'Cơ sở vật chất', 'Máy lạnh hoạt động không tốt', '2024-03-10', 'RESOLVED'),
('PH004', 'T004', 'An ninh', 'Khu vực để xe cần tăng cường bảo vệ', '2024-04-20', 'RESOLVED'),
('PH005', 'T005', 'Vệ sinh', 'Khu vực chung cần vệ sinh thường xuyên hơn', '2024-05-15', 'RESOLVED'),
('PH006', 'T006', 'Tiện ích', 'Cần bổ sung thêm máy tập gym', '2024-06-10', 'PENDING'),
('PH007', 'T007', 'Dịch vụ', 'Thang máy chờ lâu', '2024-07-05', 'RESOLVED'),
('PH008', 'T008', 'Cơ sở vật chất', 'Vòi nước bị rò rỉ', '2024-08-20', 'RESOLVED'),
('PH009', 'T009', 'An ninh', 'Hệ thống khóa cửa cần nâng cấp', '2024-09-15', 'PENDING'),
('PH010', 'T010', 'Tiện ích', 'Wifi chập chờn', '2024-10-10', 'PENDING');

-- 20 RELATIVES
INSERT INTO RELATIVES (RELATIVEID, FULLNAME, BIRTH, GENDER) VALUES
('NT001', 'Lê Thị Mận', '1965-05-20', 'Nữ'),
('NT002', 'Trần Văn Đào', '1970-08-15', 'Nam'),
('NT003', 'Phạm Thị Lê', '1980-03-10', 'Nữ'),
('NT004', 'Hoàng Văn Cam', '1975-11-25', 'Nam'),
('NT005', 'Nguyễn Thị Quýt', '1982-07-30', 'Nữ'),
('NT006', 'Vũ Văn Bưởi', '1978-09-12', 'Nam'),
('NT007', 'Đặng Thị Chanh', '1985-04-18', 'Nữ'),
('NT008', 'Bùi Văn Ổi', '1972-12-05', 'Nam'),
('NT009', 'Lý Thị Mít', '1987-06-22', 'Nữ'),
('NT010', 'Phan Văn Sầu riêng', '1990-02-14', 'Nam');

-- 21 RELATIONSHIP
INSERT INTO RELATIONSHIP (TENANTID, RELATIVEID, RELATIONSHIP) VALUES
('T001', 'NT001', 'Mẹ'),
('T001', 'NT002', 'Bố'),
('T002', 'NT003', 'Chị gái'),
('T003', 'NT004', 'Anh trai'),
('T004', 'NT005', 'Vợ'),
('T005', 'NT006', 'Chồng'),
('T006', 'NT007', 'Em gái'),
('T007', 'NT008', 'Em trai'),
('T008', 'NT009', 'Mẹ'),
('T009', 'NT010', 'Bố');

-- 22 PET
INSERT INTO PET (PETID, TENANTID, TYPE) VALUES
('TC001', 'T001', 'Chó'),
('TC002', 'T002', 'Mèo'),
('TC003', 'T003', 'Chó'),
('TC004', 'T004', 'Mèo'),
('TC005', 'T005', 'Chim'),
('TC006', 'T006', 'Cá'),
('TC007', 'T007', 'Chó'),
('TC008', 'T008', 'Mèo'),
('TC009', 'T009', 'Chim'),
('TC010', 'T010', 'Cá');

-- 23 TEMPORARY_REGISTRATION
INSERT INTO TEMPORARY_REGISTRATION (REGISTRATIONID, TENANTID, ROOMID, REGISTRATION_DATE, EXPIRATION_DATE, STATUS, CREATE_DATE, UPDATE_DATE) VALUES
('DK001', 'T001', 'R001', '2024-01-15', '2025-01-14', 'Đã duyệt', '2024-01-10', '2024-01-10'),
('DK002', 'T002', 'R003', '2024-02-10', '2024-08-09', 'Đã duyệt', '2024-02-05', '2024-02-05'),
('DK003', 'T003', 'R004', '2024-03-05', '2025-03-04', 'Đã duyệt', '2024-03-01', '2024-03-01'),
('DK004', 'T004', 'R006', '2024-04-20', '2024-10-19', 'Đã duyệt', '2024-04-15', '2024-04-15'),
('DK005', 'T005', 'R008', '2024-05-15', '2025-05-14', 'Đã duyệt', '2024-05-10', '2024-05-10'),
('DK006', 'T006', 'R010', '2024-06-10', '2024-12-09', 'Đang chờ', '2024-06-05', '2024-06-05'),
('DK007', 'T007', 'R002', '2024-07-05', '2025-07-04', 'Đã duyệt', '2024-07-01', '2024-07-01'),
('DK008', 'T008', 'R005', '2024-08-20', '2025-02-19', 'Đã duyệt', '2024-08-15', '2024-08-15'),
('DK009', 'T009', 'R007', '2024-09-15', '2025-09-14', 'Đã duyệt', '2024-09-10', '2024-09-10'),
('DK010', 'T010', 'R009', '2024-10-10', '2025-04-09', 'Đang chờ', '2024-10-05', '2024-10-05');

-- 24 TENANT_HISTORY
INSERT INTO TENANT_HISTORY (HISTORYID, CONTRACTID, TENANTID, ROOMID, STARTDATE, ENDDATE, NOTES) VALUES
('LS001', 'CT001', 'T001', 'R001', '2024-01-15', NULL, 'Người thuê tốt, thanh toán đúng hạn'),
('LS002', 'CT002', 'T002', 'R003', '2024-02-10', NULL, 'Thường xuyên sử dụng dịch vụ bổ sung'),
('LS003', 'CT003', 'T003', 'R004', '2024-03-05', NULL, 'Giữ phòng sạch sẽ, ít khiếu nại'),
('LS004', 'CT004', 'T004', 'R006', '2024-04-20', NULL, 'Có thú cưng nhưng được quản lý tốt'),
('LS005', 'CT005', 'T005', 'R008', '2024-05-15', NULL, 'Thân thiện với hàng xóm'),
('LS006', 'CT006', 'T006', 'R010', '2024-06-10', NULL, 'Ít khi ở nhà, chủ yếu đi công tác'),
('LS007', 'CT007', 'T007', 'R002', '2024-07-05', NULL, 'Thường xuyên có khách thăm'),
('LS008', 'CT008', 'T008', 'R005', '2024-08-20', NULL, 'Đúng giờ trong thanh toán'),
('LS009', 'CT009', 'T009', 'R007', '2024-09-15', NULL, 'Yêu cầu bảo trì thường xuyên'),
('LS010', 'CT010', 'T010', 'R009', '2024-10-10', NULL, 'Mới chuyển đến, chưa có đánh giá');

-- 25 RENTAL_HISTORY
INSERT INTO RENTAL_HISTORY (CONTRACTID, ROOMID, TENANTID, STARTDATE, ENDDATE, REASON_FOR_LEAVING) VALUES
('CT011', 'R001', 'T001', '2023-01-15', '2024-01-14', 'Chuyển công tác'),
('CT012', 'R002', 'T002', '2023-02-10', '2024-02-09', 'Mua nhà riêng'),
('CT013', 'R003', 'T003', '2023-03-05', '2024-03-04', 'Về quê'),
('CT014', 'R004', 'T004', '2023-04-20', '2024-04-19', 'Đi nước ngoài'),
('CT015', 'R005', 'T005', '2023-05-15', '2024-05-14', 'Chuyển chỗ ở'),
('CT016', 'R006', 'T006', '2023-06-10', '2024-06-09', 'Kết hôn'),
('CT017', 'R007', 'T007', '2023-07-05', '2024-07-04', 'Chuyển công tác'),
('CT018', 'R008', 'T008', '2023-08-20', '2024-08-19', 'Mua nhà riêng'),
('CT019', 'R009', 'T009', '2023-09-15', '2024-09-14', 'Về quê'),
('CT020', 'R010', 'T010', '2023-10-10', '2024-10-09', 'Chuyển công tác');

-- 26 PARKING
INSERT INTO PARKING (PARKINGID, AREAID, VEHICLEID, STATUS) VALUES
('PK001', 'PA001', 'XE001', 'Đang sử dụng'),
('PK002', 'PA001', 'XE002', 'Đang sử dụng'),
('PK003', 'PA002', 'XE003', 'Đang sử dụng'),
('PK004', 'PA002', 'XE004', 'Đang sử dụng'),
('PK005', 'PA003', 'XE005', 'Đang sử dụng'),
('PK006', 'PA004', 'XE006', 'Đang sử dụng'),
('PK007', 'PA005', 'XE007', 'Đang sử dụng'),
('PK008', 'PA006', 'XE008', 'Đang sử dụng'),
('PK009', 'PA007', 'XE009', 'Đang sử dụng'),
('PK010', 'PA008', 'XE010', 'Đang sử dụng');

-- 27 VEHICLE_UNITPRICE
INSERT INTO VEHICLE_UNITPRICE (VEHICLE_UNITPRICE_ID, UNITPRICE) VALUES
('VUP001', 500000),  -- Giá gửi xe máy
('VUP002', 1500000);  -- Giá gửi ô tô