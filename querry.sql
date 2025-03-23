INSERT INTO USER (USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS)
VALUES 
('user01', 'Nguyễn Văn A', 'password01', 'nguyenvana@example.com', '1990-01-15', 'Nam', '0912345678', '123 Đường ABC, Quận 1, TP.HCM'),
('user02', 'Trần Thị B', 'password02', 'tranthib@example.com', '1992-05-20', 'Nữ', '0912345679', '456 Đường XYZ, Quận 2, TP.HCM'),
('user03', 'Lê Văn C', 'password03', 'levanc@example.com', '1988-11-30', 'Nam', '0912345680', '789 Đường DEF, Quận 3, TP.HCM'),
('user04', 'Phạm Thị D', 'password04', 'phamthid@example.com', '1995-07-25', 'Nữ', '0912345681', '321 Đường GHI, Quận 4, TP.HCM'),
('user05', 'Hoàng Văn E', 'password05', 'hoangvane@example.com', '1993-03-10', 'Nam', '0912345682', '654 Đường KLM, Quận 5, TP.HCM');

INSERT INTO BUILDING (BUILDINGID, USERNAME, ADDRESS, NUMOFFLOORS, NUMOFROOMS)
VALUES 
('B001', 'user01', '123 Đường ABC, Quận 1, TP.HCM', 10, 50),
('B002', 'user02', '456 Đường XYZ, Quận 2, TP.HCM', 15, 80),
('B003', 'user03', '789 Đường DEF, Quận 3, TP.HCM', 8, 40),
('B004', 'user04', '321 Đường GHI, Quận 4, TP.HCM', 12, 60),
('B005', 'user05', '654 Đường KLM, Quận 5, TP.HCM', 20, 100);

INSERT INTO ROOM (ROOMID, BUILDINGID, TYPE, CONVENIENT, AREA, PRICE, STATUS, LAST_MAINTENANCE_DATE)
VALUES 
('R001', 'B001', 'Căn hộ', 'Điều hòa, Wifi, Bếp', 50.5, 12000000, 'Còn trống', '2023-09-15'),
('R002', 'B001', 'Căn hộ', 'Điều hòa, Wifi, Bếp, Máy giặt', 60.0, 15000000, 'Đã thuê', '2023-08-20'),
('R003', 'B002', 'Văn phòng', 'Điều hòa, Wifi, Máy in', 100.0, 25000000, 'Còn trống', '2023-07-10'),
('R004', 'B003', 'Căn hộ', 'Điều hòa, Wifi, Bếp, Máy giặt, Gym', 70.5, 18000000, 'Còn trống', '2023-09-01'),
('R005', 'B002', 'Văn phòng', 'Điều hòa, Wifi, Máy in, Phòng họp', 120.0, 30000000, 'Đã thuê', '2023-06-25');

select * from ROOM