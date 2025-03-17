/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     3/14/2025 4:50:50 PM                         */
/*==============================================================*/
drop database if exists rentease;
CREATE DATABASE rentease DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE rentease;

/*==============================================================*/
/* Table: BILL                                                  */
/*==============================================================*/
CREATE TABLE BILL (
    BILLID               VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    FIGUREID             VARCHAR(20) NOT NULL COMMENT 'ID chỉ số',
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    TOTAL                FLOAT COMMENT 'Tổng số tiền',
    PAYMENTTIME          DATETIME COMMENT 'Thời gian thanh toán',
    METHOD               VARCHAR(50) COMMENT 'Phương thức thanh toán',
    NOTIFICATION_SENT    BOOLEAN DEFAULT FALSE COMMENT 'Đánh dấu thông báo nhắc nợ đã được gửi',
    REFUND_AMOUNT        FLOAT COMMENT 'Số tiền hoàn trả',
    PRIMARY KEY (BILLID)
);

/*==============================================================*/
/* Table: BILL_SERVICE                                          */
/*==============================================================*/
CREATE TABLE BILL_SERVICE (
    SERVICEID            VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    BILLID               VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn',
    PRIMARY KEY (SERVICEID, BILLID)
);

/*==============================================================*/
/* Table: BIOMETRICENROLLMENTMANAGEMENT                         */
/*==============================================================*/
CREATE TABLE FINGERPRINTS (
    FINGERID             VARCHAR(10) NOT NULL COMMENT 'ID vân tay',
    USERNAME             VARCHAR(20) NOT NULL COMMENT 'Tên chủ trọ/quản lý',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    AREAPERMISSION       VARCHAR(200) COMMENT 'Quyền truy cập khu vực',
    ENROLLMENT_DATE      DATE COMMENT 'Ngày đăng ký vân tay',
    PRIMARY KEY (FINGERID)
);

/*==============================================================*/
/* Table: CONTRACT                                              */
/*==============================================================*/
CREATE TABLE CONTRACT (
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    HOUSEID              VARCHAR(20) NOT NULL COMMENT 'ID nhà',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    CREATEDATE           DATETIME COMMENT 'Ngày tạo hợp đồng',
    STARTDATE            DATETIME COMMENT 'Ngày bắt đầu hợp đồng',
    ENDDATE              DATETIME COMMENT 'Ngày kết thúc hợp đồng',
    MONTHLYRENT          FLOAT COMMENT 'Tiền thuê hàng tháng',
    PAYMENTSCHEDULE      VARCHAR(50) COMMENT 'Lịch thanh toán',
    DEPOSIT              FLOAT COMMENT 'Tiền đặt cọc',
    STATUS               VARCHAR(50) COMMENT 'Trạng thái hợp đồng',
    NOTES                VARCHAR(200) COMMENT 'Ghi chú',
    AUTO_RENEW           BOOLEAN DEFAULT FALSE COMMENT 'Đánh dấu hợp đồng tự động gia hạn',
    TERMINATION_REASON   VARCHAR(200) COMMENT 'Lý do chấm dứt hợp đồng trước hạn',
    CONTRACT_FILE_PATH   VARCHAR(255) COMMENT 'Đường dẫn đến bản sao hợp đồng điện tử',
    PRIMARY KEY (CONTRACTID)
);

/*==============================================================*/
/* Table: FEEDBACK                                              */
/*==============================================================*/
CREATE TABLE FEEDBACK (
    FEEDBACKID           VARCHAR(10) NOT NULL COMMENT 'ID phản hồi',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    TYPE                 VARCHAR(50) COMMENT 'Loại phản hồi',
    CONTENT              VARCHAR(200) COMMENT 'Nội dung',
    STATUS               ENUM('PENDING', 'RESOLVED') DEFAULT 'PENDING' COMMENT 'Trạng thái xử lý',
    RESOLVED_BY          VARCHAR(20) COMMENT 'Người xử lý',
    PRIMARY KEY (FEEDBACKID)
);

/*==============================================================*/
/* Table: HOUSE                                                 */
/*==============================================================*/
CREATE TABLE HOUSE (
    HOUSEID              VARCHAR(20) NOT NULL COMMENT 'ID nhà',
    ADDRESS            VARCHAR(100) COMMENT 'Địa chỉ nhà',
    TYPE                 VARCHAR(50) COMMENT 'Loại nhà',
    CONVENIENT           VARCHAR(200) COMMENT 'Tiện ích',
    AREA                 VARCHAR(50) COMMENT 'Diện tích',
    PRICE                FLOAT COMMENT 'Giá',
    STATUS               VARCHAR(50) COMMENT 'Trạng thái',
    LAST_MAINTENANCE_DATE DATE COMMENT 'Ngày bảo trì gần nhất',
    PRIMARY KEY (HOUSEID)
);

/*==============================================================*/
/* Table: USER                                               */
/*==============================================================*/
CREATE TABLE USER (
    USERNAME             VARCHAR(20) NOT NULL COMMENT 'Tên người dùng',
    FULLNAME             VARCHAR(50) COMMENT 'Họ và tên',
    PASSWORD             VARCHAR(20) COMMENT 'Mật khẩu',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    BIRTH                DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    ADDRESS              VARCHAR(100) COMMENT 'Địa chỉ',
    PRIMARY KEY (USERNAME)
);

/*==============================================================*/
/* Table: PARKINGMANAGEMENT                                     */
/*==============================================================*/
CREATE TABLE PARKINGMANAGEMENT (
    PARKINGID            VARCHAR(10) NOT NULL COMMENT 'ID bãi đậu xe',
    ADDRESS              VARCHAR(100) COMMENT 'Địa chỉ',
    TYPE                 VARCHAR(50) COMMENT 'Loại bãi đậu xe',
    CAPACITY             INT COMMENT 'Sức chứa',
    AVAILABLE            INT COMMENT 'Số chỗ trống',
    PRIMARY KEY (PARKINGID)
);

/*==============================================================*/
/* Table: PAYMENTHISTORY                                        */
/*==============================================================*/
CREATE TABLE PAYMENTHISTORY (
    BILLID               VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn',
    TENANTID             VARCHAR(20) COMMENT 'ID người thuê',
    FIGUREID             VARCHAR(20) COMMENT 'ID chỉ số',
    CONTRACTID           VARCHAR(10) COMMENT 'ID hợp đồng',
    TOTAL                FLOAT COMMENT 'Tổng số tiền',
    PAYMENTTIME          DATETIME COMMENT 'Thời gian thanh toán',
    METHOD               VARCHAR(50) COMMENT 'Phương thức thanh toán',
    NOTES                VARCHAR(200) COMMENT 'Ghi chú',
    PRIMARY KEY (BILLID)
);

/*==============================================================*/
/* Table: PET                                                   */
/*==============================================================*/
CREATE TABLE PET (
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    TYPEOFANIMAL         VARCHAR(20) COMMENT 'Loại động vật',
    QUANTITY             INT COMMENT 'Số lượng',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: RELATIONSHIP                                          */
/*==============================================================*/
CREATE TABLE TENANTRELATIVES (
    RELATIVEID       VARCHAR(20) NOT NULL COMMENT 'ID mối quan hệ',
    FULLNAME             VARCHAR(50) COMMENT 'Họ và tên',
    BIRTH                DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    RELATIONSHIP         VARCHAR(50) COMMENT 'Mối quan hệ',
    PRIMARY KEY (RELATIVEID)
);

/*==============================================================*/
/* Table: RELATIVE                                              */
/*==============================================================*/
CREATE TABLE RELATIVE (
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    RELATIVEID       VARCHAR(20) NOT NULL COMMENT 'ID mối quan hệ',
    PRIMARY KEY (TENANTID, RELATIVEID)
);

/*==============================================================*/
/* Table: RENTALHISTORY                                         */
/*==============================================================*/
CREATE TABLE RENTALHISTORY (
    HOUSEID              VARCHAR(20) NOT NULL COMMENT 'ID nhà',
    OLDTENANTID          VARCHAR(10) NOT NULL COMMENT 'ID người thuê cũ',
    HOUSENAME            VARCHAR(100) COMMENT 'Tên nhà',
    TYPE                 VARCHAR(50) COMMENT 'Loại nhà',
    CONVENIENT           VARCHAR(200) COMMENT 'Tiện ích',
    AREA                 VARCHAR(50) COMMENT 'Diện tích',
    PRICE                FLOAT COMMENT 'Giá',
    STATUS               VARCHAR(50) COMMENT 'Trạng thái',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    STARTDATE            DATETIME COMMENT 'Ngày bắt đầu',
    ENDDATE              DATETIME COMMENT 'Ngày kết thúc',
    REASON_FOR_LEAVING   VARCHAR(200) COMMENT 'Lý do rời đi',
    PRIMARY KEY (HOUSEID, OLDTENANTID)
);

/*==============================================================*/
/* Table: TEMPORARY_RESIDENCE                                   */
/*==============================================================*/
CREATE TABLE TEMPORARY_RESIDENCE (
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    PERMANENTADDRESS     VARCHAR(100) COMMENT 'Địa chỉ thường trú',
    REGISTEDADDRESS      VARCHAR(100) COMMENT 'Địa chỉ đăng ký',
    STARTDATE            DATETIME COMMENT 'Ngày bắt đầu',
    NOTES                VARCHAR(200) COMMENT 'Ghi chú',
    EXPIRY_DATE          DATE COMMENT 'Ngày hết hạn đăng ký',
    REGISTRATION_FILE_PATH VARCHAR(255) COMMENT 'Đường dẫn đến bản sao giấy tờ đăng ký',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: TENANT                                                */
/*==============================================================*/
CREATE TABLE TENANT (
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    PROFILE_PICTURE      VARCHAR(255) COMMENT 'Đường dẫn đến ảnh đại diện',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: TENANTHISTORY                                         */
/*==============================================================*/
CREATE TABLE TENANTHISTORY (
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    ADDRESS              VARCHAR(100) COMMENT 'Địa chỉ',
    STARTDATE            DATETIME COMMENT 'Ngày bắt đầu',
    NOTES                VARCHAR(200) COMMENT 'Ghi chú',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: TENANT_SERVICE                                        */
/*==============================================================*/
CREATE TABLE TENANT_SERVICE (
    SERVICEID            VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    START_DATE           DATE COMMENT 'Ngày bắt đầu sử dụng dịch vụ',
    END_DATE             DATE COMMENT 'Ngày kết thúc sử dụng dịch vụ',
    PRIMARY KEY (SERVICEID, TENANTID)
);

/*==============================================================*/
/* Table: VEHICLE                                               */
/*==============================================================*/
CREATE TABLE VEHICLE (
    VEHICLEID            VARCHAR(10) NOT NULL COMMENT 'ID phương tiện',
    BILLID               VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    PARKINGID            VARCHAR(10) COMMENT 'ID bãi đậu xe',
    TYPE                 VARCHAR(50) COMMENT 'Loại phương tiện',
    LICENSEPLATE         VARCHAR(20) COMMENT 'Biển số xe',
    QUANTITY             INT COMMENT 'Số lượng',
    UNITPRICE            FLOAT COMMENT 'Đơn giá',
    PARKING_FEE          FLOAT COMMENT 'Phí gửi xe',
    PRIMARY KEY (VEHICLEID)
);

/*==============================================================*/
/* Table: WATERELECTRICITY                                      */
/*==============================================================*/
CREATE TABLE WATERELECTRICITY (
    FIGUREID             VARCHAR(20) NOT NULL COMMENT 'ID chỉ số',
    TENANTID             VARCHAR(20) NOT NULL COMMENT 'ID người thuê',
    OLDFIGURE            FLOAT COMMENT 'Chỉ số cũ',
    NEWFIGURE            FLOAT COMMENT 'Chỉ số mới',
    REGISTEDADDRESS      VARCHAR(100) COMMENT 'Địa chỉ đăng ký',
    UNIT                 VARCHAR(10) COMMENT 'Đơn vị tính',
    UNITPRICE            FLOAT COMMENT 'Đơn giá',
    RECORD_DATE          DATE COMMENT 'Ngày ghi chỉ số',
    TYPE                 ENUM('ELECTRICITY', 'WATER') NOT NULL COMMENT 'Loại chỉ số (điện/nước)',
    PRIMARY KEY (FIGUREID)
);

/*==============================================================*/
/* Table: SERVICE                                               */
/*==============================================================*/
CREATE TABLE SERVICE (
    SERVICEID            VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    SERVICENAME          VARCHAR(100) COMMENT 'Tên dịch vụ',
    DESCRIPTION          VARCHAR(200) COMMENT 'Mô tả dịch vụ',
    UNIT_PRICE           FLOAT COMMENT 'Đơn giá',
    PRIMARY KEY (SERVICEID)
);

/*==============================================================*/
/* Table: INVOICE_DETAIL                                        */
/*==============================================================*/
CREATE TABLE INVOICE_DETAIL (
    INVOICEID            VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn',
    BILLID               VARCHAR(20) NOT NULL COMMENT 'ID hóa đơn tổng hợp',
    ITEM_NAME            VARCHAR(100) COMMENT 'Tên khoản phí',
    AMOUNT               FLOAT COMMENT 'Số tiền',
    PRIMARY KEY (INVOICEID),
    FOREIGN KEY (BILLID) REFERENCES BILL(BILLID)
);

/*==============================================================*/
/* Table: CONTRACT_NOTIFICATION                                 */
/*==============================================================*/
CREATE TABLE CONTRACT_NOTIFICATION (
    NOTIFICATIONID       VARCHAR(20) NOT NULL COMMENT 'ID thông báo',
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    NOTIFICATION_DATE    DATE COMMENT 'Ngày gửi thông báo',
    STATUS               ENUM('SENT', 'PENDING') DEFAULT 'PENDING' COMMENT 'Trạng thái thông báo',
    PRIMARY KEY (NOTIFICATIONID),
    FOREIGN KEY (CONTRACTID) REFERENCES CONTRACT(CONTRACTID)
);

/*==============================================================*/
/* Foreign Key Constraints                                      */
/*==============================================================*/
ALTER TABLE BILL ADD CONSTRAINT FK_BILL_WATERELECTRICITY FOREIGN KEY (FIGUREID)
      REFERENCES WATERELECTRICITY (FIGUREID);

ALTER TABLE BILL ADD CONSTRAINT FK_BILL_CONTRACT FOREIGN KEY (CONTRACTID)
      REFERENCES CONTRACT (CONTRACTID);

ALTER TABLE BILL ADD CONSTRAINT FK_BILL_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE BILL_SERVICE ADD CONSTRAINT FK_BILL_SERVICE_BILL FOREIGN KEY (BILLID)
      REFERENCES BILL (BILLID);
      
ALTER TABLE BILL_SERVICE ADD CONSTRAINT FK_BILL_SERVICE_SERVICE FOREIGN KEY (SERVICEID)
      REFERENCES SERVICE (SERVICEID);

ALTER TABLE FINGERPRINTS ADD CONSTRAINT FK_FINGERPRINTS_USER FOREIGN KEY (USERNAME)
      REFERENCES USER (USERNAME);

ALTER TABLE FINGERPRINTS ADD CONSTRAINT FK_FINGERPRINTS_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE CONTRACT ADD CONSTRAINT FK_CONTRACT_HOUSE FOREIGN KEY (HOUSEID)
      REFERENCES HOUSE (HOUSEID);

ALTER TABLE CONTRACT ADD CONSTRAINT FK_CONTRACT_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE FEEDBACK ADD CONSTRAINT FK_FEEDBACK_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE PAYMENTHISTORY ADD CONSTRAINT FK_PAYMENTHISTORY_BILL FOREIGN KEY (BILLID)
      REFERENCES BILL (BILLID);

ALTER TABLE PET ADD CONSTRAINT FK_PET_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE RELATIVE ADD CONSTRAINT FK_RELATIVE_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE RELATIVE ADD CONSTRAINT FK_RELATIVE_TENANTRELATIVES FOREIGN KEY (RELATIVEID)
      REFERENCES TENANTRELATIVES (RELATIVEID);

ALTER TABLE RENTALHISTORY ADD CONSTRAINT FK_RENTALHISTORY_HOUSE FOREIGN KEY (HOUSEID)
      REFERENCES HOUSE (HOUSEID);

ALTER TABLE TEMPORARY_RESIDENCE ADD CONSTRAINT FK_TEMPORARY_RESIDENCE_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE TENANTHISTORY ADD CONSTRAINT FK_TENANTHISTORY_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE TENANT_SERVICE ADD CONSTRAINT FK_TENANT_SERVICE_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE VEHICLE ADD CONSTRAINT FK_VEHICLE_BILL FOREIGN KEY (BILLID)
      REFERENCES BILL (BILLID);

ALTER TABLE VEHICLE ADD CONSTRAINT FK_VEHICLE_PARKINGMANAGEMENT FOREIGN KEY (PARKINGID)
      REFERENCES PARKINGMANAGEMENT (PARKINGID);

ALTER TABLE VEHICLE ADD CONSTRAINT FK_VEHICLE_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);

ALTER TABLE WATERELECTRICITY ADD CONSTRAINT FK_WATERELECTRICITY_TENANT FOREIGN KEY (TENANTID)
      REFERENCES TENANT (TENANTID);
      
-- Thêm dữ liệu cho bảng USER
INSERT INTO USER (USERNAME, FULLNAME, PASSWORD, EMAIL, BIRTH, GENDER, PHONENUMBER, ADDRESS)
VALUES 
('admin01', 'Nguyễn Văn An', 'Admin@123', 'admin01@gmail.com', '1988-05-15', 'Nam', '0901234567', '123 Lê Lợi, Quận 1, TP.HCM'),
('admin02', 'Trần Thị Bình', 'Admin@456', 'admin02@gmail.com', '1990-08-20', 'Nữ', '0912345678', '456 Nguyễn Huệ, Quận 1, TP.HCM'),
('admin03', 'Lê Văn Cường', 'Admin@789', 'admin03@gmail.com', '1985-12-10', 'Nam', '0923456789', '789 Trần Hưng Đạo, Quận 5, TP.HCM');

-- Thêm dữ liệu cho bảng HOUSE
INSERT INTO HOUSE (HOUSEID, ADDRESS, TYPE, CONVENIENT, AREA, PRICE, STATUS, LAST_MAINTENANCE_DATE)
VALUES 
('H001', '123 Nguyễn Trãi, Quận 5, TP.HCM', 'Nhà nguyên căn', 'Wifi, máy lạnh, máy giặt', '80m²', 8000000, 'Đã cho thuê', '2023-08-15'),
('H002', '456 Lý Thường Kiệt, Quận 10, TP.HCM', 'Căn hộ', 'Wifi, máy lạnh, bếp điện', '50m²', 5500000, 'Đã cho thuê', '2023-09-20'),
('H003', '789 CMT8, Quận 3, TP.HCM', 'Phòng trọ', 'Wifi, máy lạnh', '25m²', 3000000, 'Đã cho thuê', '2023-10-10'),
('H004', '234 Nguyễn Văn Cừ, Quận 5, TP.HCM', 'Nhà nguyên căn', 'Wifi, máy lạnh, sân vườn', '100m²', 10000000, 'Trống', '2024-01-05'),
('H005', '567 Lê Hồng Phong, Quận 10, TP.HCM', 'Căn hộ', 'Wifi, máy lạnh, hồ bơi', '60m²', 7000000, 'Trống', '2024-02-15');

-- Thêm dữ liệu cho bảng PARKINGMANAGEMENT
INSERT INTO PARKINGMANAGEMENT (PARKINGID, ADDRESS, TYPE, CAPACITY, AVAILABLE)
VALUES 
('P001', '123 Nguyễn Trãi, Quận 5, TP.HCM', 'Bãi xe máy', 50, 20),
('P002', '456 Lý Thường Kiệt, Quận 10, TP.HCM', 'Bãi xe hỗn hợp', 100, 35),
('P003', '789 CMT8, Quận 3, TP.HCM', 'Bãi xe máy', 30, 10);

-- Thêm dữ liệu cho bảng SERVICE
INSERT INTO SERVICE (SERVICEID, SERVICENAME, DESCRIPTION, UNIT_PRICE)
VALUES 
('SV001', 'Internet', 'Wifi tốc độ cao 100Mbps', 200000),
('SV002', 'Dọn phòng', 'Dịch vụ dọn phòng hàng tuần', 300000),
('SV003', 'Giặt ủi', 'Dịch vụ giặt ủi theo kg', 50000),
('SV004', 'Bảo vệ 24/7', 'Dịch vụ bảo vệ 24/7', 150000),
('SV005', 'Vệ sinh chung', 'Dịch vụ vệ sinh khu vực chung', 100000);

-- Thêm dữ liệu cho bảng TENANT
INSERT INTO TENANT (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, PROFILE_PICTURE)
VALUES 
('T001', 'Văn', 'Nguyễn', '1995-03-20', 'Nam', '0978123456', 'van.nguyen@gmail.com', '/profiles/van_nguyen.jpg'),
('T002', 'Thị', 'Phạm', '1992-07-15', 'Nữ', '0989234567', 'thi.pham@gmail.com', '/profiles/thi_pham.jpg'),
('T003', 'Minh', 'Trần', '1998-11-05', 'Nam', '0967345678', 'minh.tran@gmail.com', '/profiles/minh_tran.jpg'),
('T004', 'Hương', 'Lê', '1990-05-10', 'Nữ', '0956456789', 'huong.le@gmail.com', '/profiles/huong_le.jpg'),
('T005', 'Dũng', 'Hoàng', '1993-09-25', 'Nam', '0934567890', 'dung.hoang@gmail.com', '/profiles/dung_hoang.jpg');

-- Thêm dữ liệu cho bảng TEMPORARY_RESIDENCE
INSERT INTO TEMPORARY_RESIDENCE (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, PERMANENTADDRESS, REGISTEDADDRESS, STARTDATE, NOTES, EXPIRY_DATE, REGISTRATION_FILE_PATH)
VALUES 
('T001', 'Văn', 'Nguyễn', '1995-03-20', 'Nam', '0978123456', 'van.nguyen@gmail.com', 'Hà Nội', '123 Nguyễn Trãi, Quận 5, TP.HCM', '2023-01-01 00:00:00', 'Đã nộp đầy đủ giấy tờ', '2024-01-01', '/documents/T001_reg.pdf'),
('T002', 'Thị', 'Phạm', '1992-07-15', 'Nữ', '0989234567', 'thi.pham@gmail.com', 'Đà Nẵng', '456 Lý Thường Kiệt, Quận 10, TP.HCM', '2023-02-01 00:00:00', 'Còn thiếu xác nhận công an', '2024-02-01', '/documents/T002_reg.pdf'),
('T003', 'Minh', 'Trần', '1998-11-05', 'Nam', '0967345678', 'minh.tran@gmail.com', 'Cần Thơ', '789 CMT8, Quận 3, TP.HCM', '2023-03-01 00:00:00', 'Hoàn thành thủ tục', '2024-03-01', '/documents/T003_reg.pdf');

-- Thêm dữ liệu cho bảng TENANTHISTORY
INSERT INTO TENANTHISTORY (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, ADDRESS, STARTDATE, NOTES)
VALUES 
('T001', 'Văn', 'Nguyễn', '1995-03-20', 'Nam', '0978123456', 'van.nguyen@gmail.com', '123 Nguyễn Trãi, Quận 5, TP.HCM', '2022-01-01 00:00:00', 'Thuê lần đầu'),
('T002', 'Thị', 'Phạm', '1992-07-15', 'Nữ', '0989234567', 'thi.pham@gmail.com', '456 Lý Thường Kiệt, Quận 10, TP.HCM', '2022-02-01 00:00:00', 'Chuyển từ phòng khác'),
('T003', 'Minh', 'Trần', '1998-11-05', 'Nam', '0967345678', 'minh.tran@gmail.com', '789 CMT8, Quận 3, TP.HCM', '2022-03-01 00:00:00', 'Khách hàng mới');

-- Thêm dữ liệu cho bảng TENANTRELATIVES
INSERT INTO TENANTRELATIVES (RELATIVEID, FULLNAME, BIRTH, GENDER, RELATIONSHIP)
VALUES 
('R001', 'Nguyễn Thị Hoa', '1970-05-10', 'Nữ', 'Mẹ'),
('R002', 'Phạm Văn Tuấn', '1990-08-15', 'Nam', 'Anh trai'),
('R003', 'Trần Thị Mai', '1995-12-20', 'Nữ', 'Em gái'),
('R004', 'Lê Văn Hùng', '1968-04-05', 'Nam', 'Cha'),
('R005', 'Hoàng Thị Lan', '1994-06-12', 'Nữ', 'Chị gái');

-- Thêm dữ liệu cho bảng RELATIVE
INSERT INTO RELATIVE (TENANTID, RELATIVEID)
VALUES 
('T001', 'R001'),
('T001', 'R002'),
('T002', 'R003'),
('T003', 'R004'),
('T003', 'R005');

-- Thêm dữ liệu cho bảng PET
INSERT INTO PET (TENANTID, FIRSTNAME, LASTNAME, BIRTHDAY, GENDER, PHONENUMBER, EMAIL, TYPEOFANIMAL, QUANTITY)
VALUES 
('T001', 'Văn', 'Nguyễn', '1995-03-20', 'Nam', '0978123456', 'van.nguyen@gmail.com', 'Chó', 1),
('T002', 'Thị', 'Phạm', '1992-07-15', 'Nữ', '0989234567', 'thi.pham@gmail.com', 'Mèo', 2),
('T003', 'Minh', 'Trần', '1998-11-05', 'Nam', '0967345678', 'minh.tran@gmail.com', 'Cá', 3);

-- Thêm dữ liệu cho bảng CONTRACT
INSERT INTO CONTRACT (CONTRACTID, HOUSEID, TENANTID, CREATEDATE, STARTDATE, ENDDATE, MONTHLYRENT, PAYMENTSCHEDULE, DEPOSIT, STATUS, NOTES, AUTO_RENEW, TERMINATION_REASON, CONTRACT_FILE_PATH)
VALUES 
('C001', 'H001', 'T001', '2023-01-01 10:00:00', '2023-01-15 00:00:00', '2024-01-15 00:00:00', 8000000, 'Hàng tháng vào ngày 15', 16000000, 'Đang hiệu lực', 'Hợp đồng năm đầu tiên', TRUE, NULL, '/contracts/C001.pdf'),
('C002', 'H002', 'T002', '2023-02-01 11:00:00', '2023-02-15 00:00:00', '2024-02-15 00:00:00', 5500000, 'Hàng tháng vào ngày 15', 11000000, 'Đang hiệu lực', 'Có thú cưng', FALSE, NULL, '/contracts/C002.pdf'),
('C003', 'H003', 'T003', '2023-03-01 09:00:00', '2023-03-15 00:00:00', '2024-03-15 00:00:00', 3000000, 'Hàng tháng vào ngày 15', 6000000, 'Đang hiệu lực', 'Sinh viên', TRUE, NULL, '/contracts/C003.pdf'),
('C004', 'H001', 'T004', '2023-04-01 14:00:00', '2023-04-15 00:00:00', '2024-04-15 00:00:00', 8000000, 'Hàng tháng vào ngày 15', 16000000, 'Đã chấm dứt', 'Chuyển công tác', FALSE, 'Chuyển công tác đi xa', '/contracts/C004.pdf'),
('C005', 'H002', 'T005', '2023-05-01 15:00:00', '2023-05-15 00:00:00', '2024-05-15 00:00:00', 5500000, 'Hàng tháng vào ngày 15', 11000000, 'Đang hiệu lực', 'Ở cùng gia đình', TRUE, NULL, '/contracts/C005.pdf');

-- Thêm dữ liệu cho bảng CONTRACT_NOTIFICATION
INSERT INTO CONTRACT_NOTIFICATION (NOTIFICATIONID, CONTRACTID, NOTIFICATION_DATE, STATUS)
VALUES 
('CN001', 'C001', '2023-12-15', 'SENT'),
('CN002', 'C002', '2024-01-15', 'SENT'),
('CN003', 'C003', '2024-02-15', 'PENDING');

-- Thêm dữ liệu cho bảng TENANT_SERVICE
INSERT INTO TENANT_SERVICE (SERVICEID, TENANTID, START_DATE, END_DATE)
VALUES 
('SV001', 'T001', '2023-01-15', NULL),
('SV002', 'T001', '2023-01-15', NULL),
('SV001', 'T002', '2023-02-15', NULL),
('SV003', 'T002', '2023-02-15', NULL),
('SV001', 'T003', '2023-03-15', NULL),
('SV004', 'T003', '2023-03-15', NULL),
('SV001', 'T004', '2023-04-15', '2023-12-15'),
('SV001', 'T005', '2023-05-15', NULL)