proc_login/*==============================================================*/
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

CREATE DEFINER=`root`@`localhost` PROCEDURE `proc_login`(
	IN username VARCHAR(20),
	IN password VARCHAR(20)
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY INVOKER
COMMENT ''
BEGIN
	SELECT * FROM user  WHERE user.USERNAME = username AND user.PASSWORD = password;
END