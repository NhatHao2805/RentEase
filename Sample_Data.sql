-- 1 USER
INSERT INTO USER (USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS) VALUES
('ad', 'Nguyễn Văn An', 'ad', 'hoaianduong2411@gmail.com', '1980-05-15', 'nam', '0912345678', '123 Đường Lê Lợi, Q1, TP.HCM'),
('manager02', 'Trần Thị Bình', 'manager@123', 'manager2@rentease.com', '1985-08-20', 'nu', '0987654321', '456 Đường Nguyễn Huệ, Q1, TP.HCM'),
('owner03', 'Lê Hoàng Cường', 'owner@123', 'owner3@rentease.com', '1975-11-10', 'nam', '0909123456', '789 Đường Pasteur, Q3, TP.HCM'),
('staff04', 'Phạm Thị Dung', 'staff@123', 'staff4@rentease.com', '1990-03-25', 'nu', '0911222333', '321 Đường CMT8, Q10, TP.HCM'),
('supervisor05', 'Vũ Văn Em', 'super@123', 'super5@rentease.com', '1982-07-30', 'nam', '0988999888', '654 Đường 3/2, Q11, TP.HCM'),
('operator06', 'Nguyễn Thị Phương', 'operator@123', 'operator6@rentease.com', '1992-09-12', 'nu', '0912345999', '987 Đường Lý Thường Kiệt, Q.Tân Bình, TP.HCM'),
('director07', 'Trần Văn Giang', 'director@123', 'director7@rentease.com', '1978-12-05', 'nam', '0988123123', '147 Đường Lê Văn Sỹ, Q.Phú Nhuận, TP.HCM'),
('accountant08', 'Hoàng Thị Hương', 'account@123', 'account8@rentease.com', '1987-04-18', 'nu', '0909876543', '258 Đường Nguyễn Trãi, Q5, TP.HCM'),
('technician09', 'Phan Văn Long', 'tech@123', 'tech9@rentease.com', '1983-06-22', 'nam', '0912456789', '369 Đường Bà Hạt, Q10, TP.HCM'),
('reception10', 'Lý Thị Mai', 'reception@123', 'reception10@rentease.com', '1991-02-14', 'nu', '0987654321', '753 Đường Lạc Long Quân, Q.Tân Bình, TP.HCM'),
('user11', 'Nguyễn Văn Tâm', 'pass123', 'user11@gmail.com', '1990-01-15', 'nam', '0911111111', '111 Đường 1, Q1, TP.HCM'),
('user12', 'Trần Thị Uyên', 'pass123', 'user12@gmail.com', '1992-05-20', 'nu', '0922222222', '222 Đường 2, Q2, TP.HCM'),
('user13', 'Lê Văn Vinh', 'pass123', 'user13@gmail.com', '1988-08-10', 'nam', '0933333333', '333 Đường 3, Q3, TP.HCM'),
('user14', 'Phạm Thị Xuân', 'pass123', 'user14@gmail.com', '1995-03-25', 'nu', '0944444444', '444 Đường 4, Q4, TP.HCM'),
('user15', 'Hoàng Văn Yên', 'pass123', 'user15@gmail.com', '1987-11-30', 'nam', '0955555555', '555 Đường 5, Q5, TP.HCM'),
('user16', 'Vũ Thị Zin', 'pass123', 'user16@gmail.com', '1993-07-12', 'nu', '0966666666', '666 Đường 6, Q6, TP.HCM'),
('user17', 'Nguyễn Văn Anh', 'pass123', 'user17@gmail.com', '1985-04-18', 'nam', '0977777777', '777 Đường 7, Q7, TP.HCM'),
('user18', 'Trần Thị Bình', 'pass123', 'user18@gmail.com', '1991-09-22', 'nu', '0988888888', '888 Đường 8, Q8, TP.HCM'),
('user19', 'Lê Văn Cảnh', 'pass123', 'user19@gmail.com', '1989-12-05', 'nam', '0999999999', '999 Đường 9, Q9, TP.HCM'),
('user20', 'Phạm Thị Duyên', 'pass123', 'user20@gmail.com', '1994-06-28', 'nu', '0900000000', '000 Đường 10, Q10, TP.HCM');

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
('B010', 'BLD010', 'reception10', '753 Đường Lạc Long Quân, Q.Tân Bình, TP.HCM', 4, 16),
('B011', 'BLD011', 'user11', '111 Đường 11, Q11, TP.HCM', 3, 12),
('B012', 'BLD012', 'user12', '222 Đường 12, Q12, TP.HCM', 4, 16),
('B013', 'BLD013', 'user13', '333 Đường 13, Q13, TP.HCM', 5, 20),
('B014', 'BLD014', 'user14', '444 Đường 14, Q14, TP.HCM', 2, 8),
('B015', 'BLD015', 'user15', '555 Đường 15, Q15, TP.HCM', 6, 24),
('B016', 'BLD016', 'user16', '666 Đường 16, Q16, TP.HCM', 3, 10),
('B017', 'BLD017', 'user17', '777 Đường 17, Q17, TP.HCM', 4, 14),
('B018', 'BLD018', 'user18', '888 Đường 18, Q18, TP.HCM', 5, 18),
('B019', 'BLD019', 'user19', '999 Đường 19, Q19, TP.HCM', 2, 6),
('B020', 'BLD020', 'user20', '000 Đường 20, Q20, TP.HCM', 3, 9);

-- 3 ROOM
INSERT INTO ROOM (ROOMID, ROOMNAME, BUILDINGID, TYPE, FLOOR, CONVENIENT, AREA, PRICE, STATUS) VALUES
('R0001', 'R101', 'B001', 'studio', 1, 'Điều hòa, Wifi, Tủ lạnh', 25.5, 5000000, 'dango; saphethanhopdong'),
('R0002', 'R201', 'B001', 'phongdon', 2, 'Điều hòa, Wifi, Máy giặt', 35.0, 7000000, 'dangtrong'),
('R0003', 'R301', 'B002', 'phongdoi', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 45.5, 9000000, 'dango; dangnotien'),
('R0004', 'R102', 'B003', 'studio', 1, 'Điều hòa, Wifi', 22.0, 4500000, 'dangbaoketthuc; daquahanhopdong'),
('R0005', 'R202', 'B004', 'phongthuong', 2, 'Điều hòa, Wifi, Tủ lạnh', 30.0, 6000000, 'dangtrong'),
('R0006', 'R401', 'B005', 'phongcapcap', 4, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt, Bếp', 60.0, 12000000, 'dango; saphethanhopdong; dangnotien'),
('R0007', 'R103', 'B006', 'studio', 1, 'Điều hòa, Wifi', 20.0, 4000000, 'dangcocgiucho'),
('R0008', 'R302', 'B007', 'phongnguyencan', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 42.0, 8500000, 'dango; daquahanhopdong'),
('R0009', 'R203', 'B008', 'phongdoi', 2, 'Điều hòa, Wifi', 28.0, 5500000, 'dangtrong'),
('R0010', 'R104', 'B009', 'phongcaocap', 1, 'Điều hòa, Wifi, Tủ lạnh', 24.0, 4800000, 'daquahanhopdong'),
('R0011', 'R101', 'B011', 'studio', 1, 'Điều hòa, Wifi', 20.0, 4000000, 'dangtrong'),
('R0012', 'R201', 'B012', 'phongdoi', 2, 'Điều hòa, Wifi, Tủ lạnh', 30.0, 6000000, 'dango'),
('R0013', 'R301', 'B013', 'phongnguyencan', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 45.0, 9000000, 'dango; daquahanhopdong'),
('R0014', 'R102', 'B014', 'studio', 1, 'Điều hòa, Wifi', 22.0, 4500000, 'dangtrong'),
('R0015', 'R202', 'B015', 'phongdoi', 2, 'Điều hòa, Wifi, Tủ lạnh', 32.0, 6500000, 'dango'),
('R0016', 'R302', 'B016', 'phongnguyencan', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 48.0, 9500000, 'dangtrong'),
('R0017', 'R103', 'B017', 'studio', 1, 'Điều hòa, Wifi', 24.0, 5000000, 'dangtrong'),
('R0018', 'R203', 'B018', 'phongdoi', 2, 'Điều hòa, Wifi, Tủ lạnh', 34.0, 7000000, 'saphethanhopdong'),
('R0019', 'R303', 'B019', 'phongnguyencan', 3, 'Điều hòa, Wifi, Tủ lạnh, Máy giặt', 50.0, 10000000, 'dango'),
('R0020', 'R104', 'B020', 'studio', 1, 'Điều hòa, Wifi', 26.0, 5500000, 'dangtrong');

-- 4 TENANT
INSERT INTO TENANT (USERNAME, TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, BUILDINGID) VALUES
('ad', 'T001', 'Lê Văn', 'Cường', '1990-07-25', 'nam', '0911222333', 'tenant1@gmail.com','B001'),
('ad', 'T002', 'Phạm Thị', 'Dung', '1995-03-12', 'nu', '0988777666', 'tenant2@gmail.com','B002'),
('ad', 'T003', 'Hoàng Văn', 'Em', '1988-11-05', 'nam', '0909123456', 'tenant3@gmail.com','B003'),
('staff04', 'T004', 'Nguyễn Thị', 'Giang', '1992-09-18', 'nu', '0912345678', 'tenant4@gmail.com','B004'),
('staff04', 'T005', 'Trần Văn', 'Hải', '1985-04-30', 'nam', '0987654321', 'tenant5@gmail.com','B002'),
('operator06', 'T006', 'Vũ Thị', 'Lan', '1993-12-15', 'nu', '0909876543', 'tenant6@gmail.com','B001'),
('operator06', 'T007', 'Phan Văn', 'Minh', '1987-06-22', 'nam', '0912456789', 'tenant7@gmail.com','B002'),
('accountant08', 'T008', 'Lý Thị', 'Nga', '1991-02-14', 'nu', '0988999888', 'tenant8@gmail.com','B004'),
('technician09', 'T009', 'Đặng Văn', 'Phong', '1983-08-10', 'nam', '0911222444', 'tenant9@gmail.com','B003'),
('reception10', 'T010', 'Bùi Thị', 'Quỳnh', '1994-05-28', 'nu', '0909111222', 'tenant10@gmail.com','B002'),
('user11', 'T011', 'Nguyễn Văn', 'Tâm', '1990-01-15', 'nam', '0911111111', 'tenant11@gmail.com', 'B011'),
('user12', 'T012', 'Trần Thị', 'Uyên', '1992-05-20', 'nu', '0922222222', 'tenant12@gmail.com', 'B012'),
('user13', 'T013', 'Lê Văn', 'Vinh', '1988-08-10', 'nam', '0933333333', 'tenant13@gmail.com', 'B013'),
('user14', 'T014', 'Phạm Thị', 'Xuân', '1995-03-25', 'nu', '0944444444', 'tenant14@gmail.com', 'B014'),
('user15', 'T015', 'Hoàng Văn', 'Yên', '1987-11-30', 'nam', '0955555555', 'tenant15@gmail.com', 'B015'),
('user16', 'T016', 'Vũ Thị', 'Zin', '1993-07-12', 'nu', '0966666666', 'tenant16@gmail.com', 'B016'),
('user17', 'T017', 'Nguyễn Văn', 'Anh', '1985-04-18', 'nam', '0977777777', 'tenant17@gmail.com', 'B017'),
('user18', 'T018', 'Trần Thị', 'Bình', '1991-09-22', 'nu', '0988888888', 'tenant18@gmail.com', 'B018'),
('user19', 'T019', 'Lê Văn', 'Cảnh', '1989-12-05', 'nam', '0999999999', 'tenant19@gmail.com', 'B019'),
('user20', 'T020', 'Phạm Thị', 'Duyên', '1994-06-28', 'nu', '0900000000', 'tenant20@gmail.com', 'B020');

-- 5 CONTRACT
INSERT INTO CONTRACT (CONTRACTID, ROOMID, TENANTID, CREATEDATE, STARTDATE, ENDDATE, MONTHLYRENT, PAYMENTSCHEDULE, DEPOSIT, STATUS, NOTES, AUTO_RENEW, TERMINATION_REASON, CONTRACT_FILE_PATH) VALUES
('CT001', 'R0001', 'T001', '2024-01-10', '2024-01-15', '2025-01-14', 5000000, 'dauthang', 10000000, 'khonghieuluc ', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct001.pdf'),
('CT002', 'R0003', 'T002', '2024-02-05', '2024-02-10', '2024-08-09', 9000000, 'cuoithang', 18000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct002.pdf'),
('CT003', 'R0004', 'T003', '2024-03-01', '2024-03-05', '2025-03-04', 4500000, 'dauthang', 9000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct003.pdf'),
('CT004', 'R0006', 'T004', '2024-04-15', '2024-04-20', '2024-10-19', 12000000, 'cuoithang', 24000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct004.pdf'),
('CT005', 'R0008', 'T005', '2024-05-10', '2024-05-15', '2025-05-14', 8500000, 'dauthang', 17000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct005.pdf'),
('CT006', 'R0010', 'T006', '2024-06-05', '2024-06-10', '2024-12-09', 4800000, 'cuoithang', 9600000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct006.pdf'),
('CT007', 'R0002', 'T007', '2024-07-01', '2024-07-05', '2025-07-04', 7000000, 'dauthang', 14000000, 'khonghieuluc ', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct007.pdf'),
('CT008', 'R0005', 'T008', '2024-08-15', '2024-08-20', '2025-02-19', 6000000, 'cuoithang', 12000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct008.pdf'),
('CT009', 'R0007', 'T009', '2024-09-10', '2024-09-15', '2025-09-14', 4000000, 'dauthang', 8000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct009.pdf'),
('CT010', 'R0009', 'T010', '2024-10-05', '2024-10-10', '2025-04-09', 5500000, 'cuoithang', 11000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct010.pdf'),
('CT011', 'R0011', 'T011', '2024-01-10', '2024-01-15', '2025-01-14', 4000000, 'dauthang', 8000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct011.pdf'),
('CT012', 'R0012', 'T012', '2024-02-05', '2024-02-10', '2024-08-09', 6000000, 'cuoithang', 12000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct012.pdf'),
('CT013', 'R0013', 'T013', '2024-03-01', '2024-03-05', '2025-03-04', 9000000, 'dauthang', 18000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct013.pdf'),
('CT014', 'R0014', 'T014', '2024-04-15', '2024-04-20', '2024-10-19', 4500000, 'cuoithang', 9000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct014.pdf'),
('CT015', 'R0015', 'T015', '2024-05-10', '2024-05-15', '2025-05-14', 6500000, 'dauthang', 13000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct015.pdf'),
('CT016', 'R0016', 'T016', '2024-06-05', '2024-06-10', '2024-12-09', 9500000, 'cuoithang', 19000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct016.pdf'),
('CT017', 'R0017', 'T017', '2024-07-01', '2024-07-05', '2025-07-04', 5000000, 'dauthang', 10000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct017.pdf'),
('CT018', 'R0018', 'T018', '2024-08-15', '2024-08-20', '2025-02-19', 7000000, 'cuoithang', 14000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct018.pdf'),
('CT019', 'R0019', 'T019', '2024-09-10', '2024-09-15', '2025-09-14', 10000000, 'dauthang', 20000000, 'danghieuluc', 'Hợp đồng 1 năm', TRUE, NULL, '/contracts/ct019.pdf'),
('CT020', 'R0020', 'T020', '2024-10-05', '2024-10-10', '2025-04-09', 5500000, 'cuoithang', 11000000, 'danghieuluc', 'Hợp đồng 6 tháng', FALSE, NULL, '/contracts/ct020.pdf');

-- 6 SERVICE
INSERT INTO SERVICE (SERVICEID, SERVICENAME, UNITPRICE) VALUES
('SV001', 'Dọn phòng hàng tuần', 500000),
('SV002', 'Giặt ủi', 300000),
('SV003', 'Bảo vệ 24/7', 1000000),
('SV004', 'Gửi xe máy', 500000),
('SV005', 'Gửi ô tô', 1500000),
('SV006', 'Internet tốc độ cao', 300000),
('SV007', 'Truyền hình cáp', 200000),
('SV009', 'Dịch vụ phòng gym', 800000),
('SV010', 'Dịch vụ bể bơi', 600000),
('SV011', 'Dọn phòng hàng tuần', 200000),
('SV012', 'Giặt ủi', 150000),
('SV013', 'Đưa đón sân bay', 500000),
('SV014', 'Dịch vụ bảo vệ 24/7', 1000000),
('SV015', 'Dịch vụ phòng gym', 300000),
('SV016', 'Dịch vụ hồ bơi', 250000),
('SV017', 'Dịch vụ spa', 400000),
('SV018', 'Dịch vụ ăn sáng', 100000),
('SV019', 'Dịch vụ dọn nhà', 350000),
('SV020', 'Dịch vụ đỗ xe', 200000);

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
('T005', 'SV001', '2024-05-15', '2025-05-14'),
('T011', 'SV011', '2024-01-15', '2025-01-14'),
('T012', 'SV012', '2024-02-10', '2024-08-09'),
('T013', 'SV013', '2024-03-05', '2025-03-04'),
('T014', 'SV014', '2024-04-20', '2024-10-19'),
('T015', 'SV015', '2024-05-15', '2025-05-14'),
('T016', 'SV016', '2024-06-10', '2024-12-09'),
('T017', 'SV017', '2024-07-05', '2025-07-04'),
('T018', 'SV018', '2024-08-20', '2025-02-19'),
('T019', 'SV019', '2024-09-15', '2025-09-14'),
('T020', 'SV020', '2024-10-10', '2025-04-09');

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
('HD010', 'T005', 9350000, '2024-06-15', '2024-07-14', FALSE, 0),
('HD011', 'T011', 4200000, '2024-01-15', '2024-02-14', FALSE, 0),
('HD012', 'T012', 6150000, '2024-02-10', '2024-03-09', FALSE, 0),
('HD013', 'T013', 9500000, '2024-03-05', '2024-04-04', FALSE, 0),
('HD014', 'T014', 4550000, '2024-04-20', '2024-05-19', FALSE, 0),
('HD015', 'T015', 6800000, '2024-05-15', '2024-06-14', FALSE, 0),
('HD016', 'T016', 9750000, '2024-06-10', '2024-07-09', FALSE, 0),
('HD017', 'T017', 5400000, '2024-07-05', '2024-08-04', FALSE, 0),
('HD018', 'T018', 7100000, '2024-08-20', '2024-09-19', FALSE, 0),
('HD019', 'T019', 10350000, '2024-09-15', '2024-10-14', FALSE, 0),
('HD020', 'T020', 5700000, '2024-10-10', '2024-11-09', FALSE, 0);

-- 9 WATER_ELEC_UNITPRICE
INSERT INTO WATER_ELECT_UNITPRICE VALUES
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
('CS010', 'UP002', 'T005', 45, 65, 'm3', '2024-05-15', '2024-06-14', '2024-06-14', 'WATER'),
('CS011', 'UP001', 'T011', 100, 150, 'kWh', '2024-01-15', '2024-02-14', '2024-02-15', 'ELECTRICITY'),
('CS012', 'UP002', 'T011', 5, 7, 'm3', '2024-01-15', '2024-02-14', '2024-02-15', 'WATER'),
('CS013', 'UP001', 'T012', 200, 250, 'kWh', '2024-02-10', '2024-03-09', '2024-03-10', 'ELECTRICITY'),
('CS014', 'UP002', 'T012', 8, 10, 'm3', '2024-02-10', '2024-03-09', '2024-03-10', 'WATER'),
('CS015', 'UP001', 'T013', 150, 200, 'kWh', '2024-03-05', '2024-04-04', '2024-04-05', 'ELECTRICITY'),
('CS016', 'UP002', 'T013', 6, 8, 'm3', '2024-03-05', '2024-04-04', '2024-04-05', 'WATER'),
('CS017', 'UP001', 'T014', 120, 170, 'kWh', '2024-04-20', '2024-05-19', '2024-05-20', 'ELECTRICITY'),
('CS018', 'UP002', 'T014', 7, 9, 'm3', '2024-04-20', '2024-05-19', '2024-05-20', 'WATER'),
('CS019', 'UP001', 'T015', 180, 230, 'kWh', '2024-05-15', '2024-06-14', '2024-06-15', 'ELECTRICITY'),
('CS020', 'UP002', 'T015', 9, 11, 'm3', '2024-05-15', '2024-06-14', '2024-06-15', 'WATER');

-- 11 BILL_DETAIL
INSERT INTO BILLDETAIL (BILLDETAIL_ID, BILLID, ID, AMOUNT) VALUES
('BD001', 'HD001', 'SV001', 500000),
('BD002', 'HD001', 'SV002',  1000000),
('BD003', 'HD001', 'SV003',  300000),
('BD007', 'HD001', 'CS001',  300000),
('BD008', 'HD001', 'CS002', 300000),
('BD004', 'HD002', 'SV004',  300000),
('BD005', 'HD002', 'SV005',  500000),
('BD006', 'HD003', 'SV006',  1000000),
('BD011', 'HD011', 'DV011', 200000),
('BD012', 'HD012', 'DV012', 150000),
('BD013', 'HD013', 'DV013', 500000),
('BD014', 'HD014', 'DV014', 1000000),
('BD015', 'HD015', 'DV015', 300000),
('BD016', 'HD016', 'DV016', 250000),
('BD017', 'HD017', 'DV017', 400000),
('BD018', 'HD018', 'DV018', 100000),
('BD019', 'HD019', 'DV019', 350000),
('BD020', 'HD020', 'DV020', 200000);

-- 12 PAYMENT
INSERT INTO PAYMENT (PAYMENTID, BILLID, METHOD, TOTAL, PAYMENTTIME) VALUES
('TT001', 'HD001', 'chuyenkhoan', 5800000, UNIX_TIMESTAMP('2024-01-20')),
('TT002', 'HD002', 'tienmat', 9800000, UNIX_TIMESTAMP('2024-02-15')),
('TT003', 'HD003', 'chuyenkhoan', 5000000, UNIX_TIMESTAMP('2024-03-10')),
('TT004', 'HD004', 'thetindung', 13500000, UNIX_TIMESTAMP('2024-04-25')),
('TT005', 'HD005', 'chuyenkhoan', 9350000, UNIX_TIMESTAMP('2024-05-20')),
('TT006', 'HD006', 'tienmat', 5800000, UNIX_TIMESTAMP('2024-02-20')),
('TT007', 'HD007', 'chuyenkhoan', 9800000, UNIX_TIMESTAMP('2024-03-15')),
('TT008', 'HD008', 'thetindung', 5000000, UNIX_TIMESTAMP('2024-04-10')),
('TT009', 'HD009', 'chuyenkhoan', 13500000, UNIX_TIMESTAMP('2024-05-25')),
('TT010', 'HD010', 'tienmat', 9350000, UNIX_TIMESTAMP('2024-06-20')),
('TT011', 'HD011', 'Chuyển khoản', 4200000, 20240115),
('TT012', 'HD012', 'Tiền mặt', 6150000, 20240210),
('TT013', 'HD013', 'Chuyển khoản', 9500000, 20240305),
('TT014', 'HD014', 'Thẻ tín dụng', 4550000, 20240420),
('TT015', 'HD015', 'Chuyển khoản', 6800000, 20240515),
('TT016', 'HD016', 'Tiền mặt', 9750000, 20240610),
('TT017', 'HD017', 'Thẻ tín dụng', 5400000, 20240705),
('TT018', 'HD018', 'Chuyển khoản', 7100000, 20240820),
('TT019', 'HD019', 'Tiền mặt', 10350000, 20240915),
('TT020', 'HD020', 'Chuyển khoản', 5700000, 20241010);

-- 13 VEHICLE
INSERT INTO VEHICLE (VEHICLEID, TENANTID, VEHICLE_UNITPRICE_ID, TYPE, LICENSEPLATE) VALUES
('V0001', 'T001', 'VUP002', 'xemay', '51A-12345'),
('V0002', 'T002', 'VUP002', 'xemay', '51B-54321'),
('V0003', 'T003', 'VUP001', 'xeoto', '51C-67890'),
('V0004', 'T004', 'VUP001', 'xeoto', '51D-09876'),
('V0005', 'T005', 'VUP002', 'xemay', '51E-11223'),
('V0006', 'T006', 'VUP002', 'xemay', '51F-33445'),
('V0007', 'T007', 'VUP001', 'xeoto', '51G-55667'),
('V0008', 'T008', 'VUP002', 'xemay', '51H-77889'),
('V0009', 'T009', 'VUP002', 'xemay', '51K-99001'),
('V0010', 'T010', 'VUP001', 'xeoto', '51L-22334'),
('V0011', 'T011', 'VUP002', 'xemay', '51M-44556'),
('V0012', 'T012', 'VUP001', 'xeoto', '51N-66778'),
('V0013', 'T013', 'VUP002', 'xemay', '51P-88990'),
('V0014', 'T014', 'VUP001', 'xeoto', '51Q-11224'),
('V0015', 'T015', 'VUP002', 'xemay', '51R-33446'),
('V0016', 'T016', 'VUP001', 'xeoto', '51S-55668'),
('V0017', 'T017', 'VUP002', 'xemay', '51T-77880'),
('V0018', 'T018', 'VUP001', 'xeoto', '51U-99012'),
('V0019', 'T019', 'VUP002', 'xemay', '51V-12356'),
('V0020', 'T020', 'VUP001', 'xeoto', '51X-34567');


-- 14 PARKINGAREA
INSERT INTO PARKINGAREA (AREAID, BUILDINGID, ADDRESS, TYPE, CAPACITY) VALUES
('PA0001', 'B001', 'Tầng hầm B1', 'xemay/xedap', 50),
('PA0002', 'B001', 'Tầng hầm B2', 'xeoto', 20),
('PA0003', 'B002', 'Khu vực sau tòa nhà', 'xemay/xedap', 30),
('PA0004', 'B003', 'Tầng hầm B1', 'honhop', 40),
('PA0005', 'B003', 'Tầng hầm B2', 'xeoto', 15),
('PA0006', 'B004', 'Khu vực trước tòa nhà', 'honhop', 25),
('PA0007', 'B005', 'Tầng hầm B1', 'xemay/xedap', 35),
('PA0008', 'B005', 'Tầng hầm B2', 'honhop', 10),
('PA0009', 'B006', 'Khu vực bên hông', 'xemay/xedap', 20),
('PA0010', 'B007', 'Tầng hầm B1', 'xemay/xedap', 45),
('PA0011', 'B011', 'Tầng hầm 1', 'honhop', 20),
('PA0012', 'B012', 'Tầng hầm 2', 'xemay', 30),
('PA0013', 'B013', 'Tầng hầm 3', 'xeoto', 15),
('PA0014', 'B014', 'Tầng hầm 4', 'honhop', 25),
('PA0015', 'B015', 'Tầng hầm 5', 'xemay', 35),
('PA0016', 'B016', 'Tầng hầm 6', 'xeoto', 20),
('PA0017', 'B017', 'Tầng hầm 7', 'honhop', 30),
('PA0018', 'B018', 'Tầng hầm 8', 'xemay', 40),
('PA0019', 'B019', 'Tầng hầm 9', 'xeoto', 25),
('PA0020', 'B020', 'Tầng hầm 10', 'honhop', 35);

-- 15 ASSETS
INSERT INTO ASSETS (ASSETID, ROOMID, ASSETNAME, PRICE, STATUS, USE_DATE) VALUES
('TS0001', 'R0001', 'Điều hòa', 8000000, 'tot', '2023-12-01'),
('TS0002', 'R0001', 'Tủ lạnh', 7000000, 'tot', '2023-12-01'),
('TS0003', 'R0002', 'Điều hòa', 8000000, 'tot', '2023-12-15'),
('TS0004', 'R0002', 'Máy giặt', 6000000, 'tot', '2023-12-15'),
('TS0005', 'R0003', 'Điều hòa', 8000000, 'tot', '2024-01-05'),
('TS0006', 'R0003', 'Tủ lạnh', 7000000, 'tot', '2024-01-05'),
('TS0007', 'R0003', 'Máy giặt', 6000000, 'tot', '2024-01-05'),
('TS0008', 'R0004', 'Điều hòa', 8000000, 'tot', '2024-02-01'),
('TS0009', 'R0005', 'Điều hòa', 8000000, 'tot', '2024-03-01'),
('TS0010', 'R0005', 'Tủ lạnh', 7000000, 'tot', '2024-03-01'),
('TS011', 'R0011', 'Điều hòa', 8000000, 'tot', '2024-01-15'),
('TS012', 'R0012', 'Tủ lạnh', 7000000, 'tot', '2024-02-10'),
('TS013', 'R0013', 'Máy giặt', 6000000, 'tot', '2024-03-05'),
('TS014', 'R0014', 'TV', 10000000, 'tot', '2024-04-20'),
('TS015', 'R0015', 'Bàn ghế', 3000000, 'tot', '2024-05-15'),
('TS016', 'R0016', 'Giường', 4000000, 'tot', '2024-06-10'),
('TS017', 'R0017', 'Tủ quần áo', 2500000, 'tot', '2024-07-05'),
('TS018', 'R0018', 'Bếp điện', 3500000, 'tot', '2024-08-20'),
('TS019', 'R0019', 'Máy lọc nước', 5000000, 'tot', '2024-09-15'),
('TS020', 'R0020', 'Quạt trần', 1500000, 'tot', '2024-10-10');

-- 16 MAINTENANCE
INSERT INTO MAINTENANCE (MAINTENANCEID, ASSETID, MAINTENANCE_DATE, DESCRIPTION, STATUS) VALUES
('BT001', 'TS0001', '2024-01-15', 'Vệ sinh điều hòa', 'hoanthanh'),
('BT002', 'TS0002', '2024-01-15', 'Kiểm tra tủ lạnh', 'hoanthanh'),
('BT003', 'TS0003', '2024-02-20', 'Bảo dưỡng điều hòa', 'hoanthanh'),
('BT004', 'TS0004', '2024-02-20', 'Kiểm tra máy giặt', 'hoanthanh'),
('BT005', 'TS0005', '2024-03-10', 'Vệ sinh điều hòa', 'hoanthanh'),
('BT006', 'TS0006', '2024-03-10', 'Kiểm tra tủ lạnh', 'hoanthanh'),
('BT007', 'TS0007', '2024-03-10', 'Bảo dưỡng máy giặt', 'hoanthanh'),
('BT008', 'TS0008', '2024-04-05', 'Vệ sinh điều hòa', 'hoanthanh'),
('BT009', 'TS0009', '2024-05-12', 'Kiểm tra điều hòa', 'hoanthanh'),
('BT010', 'TS0010', '2024-05-12', 'Bảo dưỡng tủ lạnh', 'hoanthanh'),
('MT011', 'TS011', '2024-01-20', 'Vệ sinh điều hòa', 'hoanthanh'),
('MT012', 'TS012', '2024-02-15', 'Kiểm tra tủ lạnh', 'hoanthanh'),
('MT013', 'TS013', '2024-03-10', 'Bảo dưỡng máy giặt', 'hoanthanh'),
('MT014', 'TS014', '2024-04-25', 'Sửa chữa TV', 'hoanthanh'),
('MT015', 'TS015', '2024-05-20', 'Thay bàn ghế mới', 'hoanthanh'),
('MT016', 'TS016', '2024-06-15', 'Sửa giường', 'hoanthanh'),
('MT017', 'TS017', '2024-07-10', 'Vệ sinh tủ quần áo', 'hoanthanh'),
('MT018', 'TS018', '2024-08-25', 'Kiểm tra bếp điện', 'hoanthanh'),
('MT019', 'TS019', '2024-09-20', 'Thay lõi lọc nước', 'hoanthanh'),
('MT020', 'TS020', '2024-10-15', 'Bảo dưỡng quạt trần', 'hoanthanh');

-- 17 REPAIR_REQUEST
INSERT INTO REPAIR_REQUEST (REQUESTID, ASSETID, TENANTID, REQUEST_DATE, DESCRIPTION, STATUS) VALUES
('YC001', 'TS0001', 'T001', '2024-01-20', 'Điều hòa chảy nước', 'daxuly'),
('YC002', 'TS0002', 'T001', '2024-01-25', 'Tủ lạnh không lạnh', 'daxuly'),
('YC003', 'TS0003', 'T002', '2024-02-15', 'Máy giặt không vắt', 'daxuly'),
('YC004', 'TS0004', 'T002', '2024-02-20', 'Điều hòa không mát', 'daxuly'),
('YC005', 'TS0005', 'T003', '2024-03-12', 'Tủ lạnh kêu to', 'daxuly'),
('YC006', 'TS0006', 'T003', '2024-03-15', 'Máy giặt rò rỉ nước', 'daxuly'),
('YC007', 'TS0007', 'T004', '2024-04-25', 'Điều hòa không hoạt động', 'daxuly'),
('YC008', 'TS0008', 'T004', '2024-05-05', 'Tủ lạnh đóng tuyết', 'daxuly'),
('YC009', 'TS0009', 'T005', '2024-05-20', 'Máy giặt không cấp nước', 'daxuly'),
('YC010', 'TS0010', 'T005', '2024-06-10', 'Điều hòa không lạnh', 'dangxuly'),
('YC011', 'TS011', 'T011', '2024-01-18', 'Điều hòa không mát', 'hoanthanh'),
('YC012', 'TS012', 'T012', '2024-02-13', 'Tủ lạnh không lạnh', 'hoanthanh'),
('YC013', 'TS013', 'T013', '2024-03-08', 'Máy giặt không vắt', 'hoanthanh'),
('YC014', 'TS014', 'T014', '2024-04-23', 'TV không lên hình', 'hoanthanh'),
('YC015', 'TS015', 'T015', '2024-05-18', 'Bàn ghế bị gãy', 'hoanthanh'),
('YC016', 'TS016', 'T016', '2024-06-13', 'Giường bị lỏng', 'hoanthanh'),
('YC017', 'TS017', 'T017', '2024-07-08', 'Tủ quần áo bị kẹt', 'hoanthanh'),
('YC018', 'TS018', 'T018', '2024-08-23', 'Bếp điện không nóng', 'hoanthanh'),
('YC019', 'TS019', 'T019', '2024-09-18', 'Máy lọc nước rò rỉ', 'hoanthanh'),
('YC020', 'TS020', 'T020', '2024-10-13', 'Quạt trần không quay', 'hoanthanh');

-- 19 FEEDBACK
INSERT INTO FEEDBACK (FEEDBACKID, TENANTID, TYPE, CONTENT, DATESEND, STATUS) VALUES
('PH001', 'T001', 'chatluongphong', 'Phòng sạch sẽ, đầy đủ tiện nghi', '2024-01-25', 'resolved'),
('PH002', 'T002', 'dichvu', 'Nhân viên nhiệt tình, thân thiện', '2024-02-15', 'resolved'),
('PH003', 'T003', 'cosovatchat', 'Máy lạnh hoạt động không tốt', '2024-03-10', 'resolved'),
('PH004', 'T004', 'anninh', 'Khu vực để xe cần tăng cường bảo vệ', '2024-04-20', 'resolved'),
('PH005', 'T005', 'vesinh', 'Khu vực chung cần vệ sinh thường xuyên hơn', '2024-05-15', 'resolved'),
('PH006', 'T006', 'tienich', 'Cần bổ sung thêm máy tập gym', '2024-06-10', 'pending'),
('PH007', 'T007', 'dichvu', 'Thang máy chờ lâu', '2024-07-05', 'resolved'),
('PH008', 'T008', 'cosovatchat', 'Vòi nước bị rò rỉ', '2024-08-20', 'resolved'),
('PH009', 'T009', 'anninh', 'Hệ thống khóa cửa cần nâng cấp', '2024-09-15', 'pending'),
('PH010', 'T010', 'tienich', 'Wifi chập chờn', '2024-10-10', 'pending');

-- 22 PET
INSERT INTO PET (PETID, TENANTID, TYPE) VALUES
('TC001', 'T001', 'cho'),
('TC002', 'T002', 'meo'),
('TC003', 'T003', 'cho'),
('TC004', 'T004', 'meo'),
('TC005', 'T005', 'chim'),
('TC006', 'T006', 'ca'),
('TC007', 'T007', 'cho'),
('TC008', 'T008', 'meo'),
('TC009', 'T009', 'chim'),
('TC010', 'T010', 'ca');

-- 23 TEMPORARY_REGISTRATION
INSERT INTO TEMPORARY_REGISTRATION (REGISTRATIONID, TENANTID, ROOMID, REGISTRATION_DATE, EXPIRATION_DATE, STATUS, CREATE_DATE, UPDATE_DATE) VALUES
('DK001', 'T001', 'R0001', '2024-01-15', '2025-01-14', 'daduyet', '2024-01-10', '2024-01-10'),
('DK002', 'T002', 'R0003', '2024-02-10', '2024-08-09', 'daduyet', '2024-02-05', '2024-02-05'),
('DK003', 'T003', 'R0004', '2024-03-05', '2025-03-04', 'daduyet', '2024-03-01', '2024-03-01'),
('DK004', 'T004', 'R0006', '2024-04-20', '2024-10-19', 'daduyet', '2024-04-15', '2024-04-15'),
('DK005', 'T005', 'R0008', '2024-05-15', '2025-05-14', 'daduyet', '2024-05-10', '2024-05-10'),
('DK006', 'T006', 'R0010', '2024-06-10', '2024-12-09', 'dangcho', '2024-06-05', '2024-06-05'),
('DK007', 'T007', 'R0002', '2024-07-05', '2025-07-04', 'daduyet', '2024-07-01', '2024-07-01'),
('DK008', 'T008', 'R0005', '2024-08-20', '2025-02-19', 'daduyet', '2024-08-15', '2024-08-15'),
('DK009', 'T009', 'R0007', '2024-09-15', '2025-09-14', 'daduyet', '2024-09-10', '2024-09-10'),
('DK010', 'T010', 'R0009', '2024-10-10', '2025-04-09', 'dangcho', '2024-10-05', '2024-10-05'),
('DK011', 'T011', 'R0011', '2024-01-15', '2024-02-14', 'dangky', '2024-01-15', '2024-01-15'),
('DK012', 'T012', 'R0012', '2024-02-10', '2024-03-09', 'dangky', '2024-02-10', '2024-02-10'),
('DK013', 'T013', 'R0013', '2024-03-05', '2024-04-04', 'dangky', '2024-03-05', '2024-03-05'),
('DK014', 'T014', 'R0014', '2024-04-20', '2024-05-19', 'dangky', '2024-04-20', '2024-04-20'),
('DK015', 'T015', 'R0015', '2024-05-15', '2024-06-14', 'dangky', '2024-05-15', '2024-05-15'),
('DK016', 'T016', 'R0016', '2024-06-10', '2024-07-09', 'dangky', '2024-06-10', '2024-06-10'),
('DK017', 'T017', 'R0017', '2024-07-05', '2024-08-04', 'dangky', '2024-07-05', '2024-07-05'),
('DK018', 'T018', 'R0018', '2024-08-20', '2024-09-19', 'dangky', '2024-08-20', '2024-08-20'),
('DK019', 'T019', 'R0019', '2024-09-15', '2024-10-14', 'dangky', '2024-09-15', '2024-09-15'),
('DK020', 'T020', 'R0020', '2024-10-10', '2024-11-09', 'dangky', '2024-10-10', '2024-10-10');

-- 26 PARKING
INSERT INTO PARKING (PARKINGID, AREAID, VEHICLEID, STATUS) VALUES
('P0001', 'PA0001', 'V0001', 'dangsudung'),
('P0002', 'PA0001', 'V0002', 'dangsudung'),
('P0003', 'PA0002', 'V0003', 'dangsudung'),
('P0004', 'PA0002', 'V0004', 'dangsudung'),
('P0005', 'PA0003', 'V0005', 'dangsudung'),
('P0006', 'PA0004', 'V0006', 'dangsudung'),
('P0007', 'PA0005', 'V0007', 'dangsudung'),
('P0008', 'PA0006', 'V0008', 'dangsudung'),
('P0009', 'PA0007', 'V0009', 'dangsudung'),
('P0010', 'PA0008', 'V0010', 'dangsudung'),
('P0011', 'PA0011', 'V0011', 'dangsudung'),
('P0012', 'PA0012', 'V0012', 'dangsudung'),
('P0013', 'PA0013', 'V0013', 'dangsudung'),
('P0014', 'PA0014', 'V0014', 'dangsudung'),
('P0015', 'PA0015', 'V0015', 'dangsudung'),
('P0016', 'PA0016', 'V0016', 'dangsudung'),
('P0017', 'PA0017', 'V0017', 'dangsudung'),
('P0018', 'PA0018', 'V0018', 'dangsudung'),
('P0019', 'PA0019', 'V0019', 'dangsudung'),
('P0020', 'PA0020', 'V0020', 'dangsudung');

-- 27 VEHICLE_UNITPRICE
INSERT INTO VEHICLE_UNITPRICE (VEHICLE_UNITPRICE_ID, UNITPRICE, TYPE) VALUES
('VUP001', 500000, 'xeoto'),
('VUP002', 100000, 'xemay'),
('VUP003', 50000, 'xedap');
