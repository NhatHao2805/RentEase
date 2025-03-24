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
    BILLID               VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    TOTAL                FLOAT COMMENT 'Tổng số tiền',
    START_DATE           DATETIME COMMENT 'Thời gian bắt đầu thanh toán',
    END_DATE          	 DATETIME COMMENT 'Thời gian kết thúc thanh toán',
    NOTIFICATION_SENT    BOOLEAN DEFAULT FALSE COMMENT 'Đánh dấu thông báo nhắc nợ đã được gửi',
    REFUND_AMOUNT        FLOAT COMMENT 'Số tiền hoàn trả',
    PRIMARY KEY (BILLID)
);

/*==============================================================*/
/* Table: SERVICE                                                  */
/*==============================================================*/
CREATE TABLE SERVICE (
    SERVICEID               VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    SERVICENAME             VARCHAR(100) NOT NULL COMMENT 'Tên dịch vụ',
    UNITPRICE           	FLOAT NOT NULL COMMENT 'Đơn giá',
    PRIMARY KEY (SERVICEID)
);

/*==============================================================*/
/* Table: BILLDETAIL                                                  */
/*==============================================================*/
CREATE TABLE BILLDETAIL (
	BILLID               	VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    SERVICEID               VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    QUANTITY             	FLOAT NOT NULL COMMENT 'Số lượng',
    AMOUNT           		FLOAT NOT NULL COMMENT 'Thành tiền',
    PRIMARY KEY (BILLID, SERVICEID)
);

/*==============================================================*/
/* Table: PAYMENT                                                  */
/*==============================================================*/
CREATE TABLE PAYMENT (
	PAYMENTID               VARCHAR(10) NOT NULL COMMENT 'ID thanh toán',
    BILLID               	VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    METHOD               	VARCHAR(10) NOT NULL COMMENT 'Phương thức',
    TOTAL             		FLOAT NOT NULL COMMENT 'Tổng tiền',
    PAYMENTTIME           	FLOAT NOT NULL COMMENT 'Thời gian thanh toán',
    PRIMARY KEY (PAYMENTID)
);

/*==============================================================*/
/* Table: BIOMETRICENROLLMENTMANAGEMENT                         */
/*==============================================================*/
CREATE TABLE FINGERPRINTS (
    FINGERID             VARCHAR(10) NOT NULL COMMENT 'ID vân tay',
    USERNAME             VARCHAR(20) NOT NULL COMMENT 'Tên chủ trọ/quản lý',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    AREAPERMISSION       VARCHAR(200) COMMENT 'Quyền truy cập khu vực',
    ENROLLMENT_DATE      DATE COMMENT 'Ngày đăng ký vân tay',
    PRIMARY KEY (FINGERID)
);

/*==============================================================*/
/* Table: CONTRACT                                              */
/*==============================================================*/
CREATE TABLE CONTRACT (
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    ROOMID              VARCHAR(10) NOT NULL COMMENT 'ID nhà',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
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
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    TYPE                 VARCHAR(50) COMMENT 'Loại phản hồi',
    CONTENT              VARCHAR(200) COMMENT 'Nội dung',
    STATUS               ENUM('PENDING', 'RESOLVED') DEFAULT 'PENDING' COMMENT 'Trạng thái xử lý',
    RESOLVED_BY          VARCHAR(20) COMMENT 'Người xử lý',
    PRIMARY KEY (FEEDBACKID)
);

/*==============================================================*/
/* Table: BUILDING                                                 */
/*==============================================================*/
CREATE TABLE BUILDING (
    BUILDINGID              VARCHAR(10) NOT NULL COMMENT 'ID tòa nhà',
    USERNAME             VARCHAR(20) NOT NULL COMMENT 'Tên người dùng',
    ADDRESS                 VARCHAR(100) COMMENT 'Địa chỉ',
    NUMOFFLOORS             INT COMMENT 'Số lượng tầng',
    NUMOFROOMS              INT COMMENT 'Số lượng phòng',
    PRIMARY KEY (BUILDINGID)
);

/*==============================================================*/
/* Table: ROOM                                                 */
/*==============================================================*/
CREATE TABLE ROOM (
    ROOMID              VARCHAR(10) NOT NULL COMMENT 'ID nhà',
    BUILDINGID           VARCHAR(10) NOT NULL COMMENT 'ID tòa nhà',
    TYPE                 VARCHAR(50) COMMENT 'Loại nhà',
    CONVENIENT           VARCHAR(200) COMMENT 'Tiện ích',
    AREA                 FLOAT COMMENT 'Diện tích',
    PRICE                FLOAT COMMENT 'Giá',
    STATUS               VARCHAR(50) COMMENT 'Trạng thái',
    LAST_MAINTENANCE_DATE DATE COMMENT 'Ngày bảo trì gần nhất',
    PRIMARY KEY (ROOMID)
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
/* Table: PET                                                   */
/*==============================================================*/
CREATE TABLE PET (
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    TYPEOFANIMAL         VARCHAR(20) COMMENT 'Loại động vật',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: RELATIONSHIP                                          */
/*==============================================================*/
CREATE TABLE TENANTRELATIVES (
    RELATIVEID       	 VARCHAR(10) NOT NULL COMMENT 'ID mối quan hệ',
    FULLNAME             VARCHAR(50) COMMENT 'Họ và tên',
    BIRTH                DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PRIMARY KEY (RELATIVEID)
);

/*==============================================================*/
/* Table: RELATIVE                                              */
/*==============================================================*/
CREATE TABLE RELATIVE (
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    RELATIVEID       	 VARCHAR(10) NOT NULL COMMENT 'ID mối quan hệ',
    RELATIONSHIP         VARCHAR(50) COMMENT 'Mối quan hệ',
    PRIMARY KEY (TENANTID, RELATIVEID)
);

/*==============================================================*/
/* Table: RENTALHISTORY                                         */
/*==============================================================*/
CREATE TABLE RENTALHISTORY (
    ROOMID               VARCHAR(10) NOT NULL COMMENT 'ID nhà',
    OLDTENANTID          VARCHAR(10) NOT NULL COMMENT 'ID người thuê cũ',
    ADDRESS            	 VARCHAR(100) COMMENT 'Tên nhà',
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
    PRIMARY KEY (ROOMID, OLDTENANTID)
);

/*==============================================================*/
/* Table: TEMPORARY_RESIDENCE                                   */
/*==============================================================*/
CREATE TABLE TEMPORARY_RESIDENCE (
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
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
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
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
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
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
/* Table: VEHICLE                                               */
/*==============================================================*/
CREATE TABLE VEHICLE (
    VEHICLEID            VARCHAR(10) NOT NULL COMMENT 'ID phương tiện',
    SERVICEID            VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
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
    FIGUREID             VARCHAR(10) NOT NULL COMMENT 'ID chỉ số',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    SERVICEID			 VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    OLDFIGURE            FLOAT COMMENT 'Chỉ số cũ',
    NEWFIGURE            FLOAT COMMENT 'Chỉ số mới',
    UNIT                 VARCHAR(10) COMMENT 'Đơn vị tính',
    RECORD_DATE          DATE COMMENT 'Ngày ghi chỉ số',
    TYPE                 ENUM('ELECTRICITY', 'WATER') NOT NULL COMMENT 'Loại chỉ số (điện/nước)',
    PRIMARY KEY (FIGUREID)
);

/*==============================================================*/
/* Table: CONTRACT_NOTIFICATION                                 */
/*==============================================================*/
CREATE TABLE CONTRACT_NOTIFICATION (
    NOTIFICATIONID       VARCHAR(10) NOT NULL COMMENT 'ID thông báo',
    CONTRACTID           VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    NOTIFICATION_DATE    DATE COMMENT 'Ngày gửi thông báo',
    STATUS               ENUM('SENT', 'PENDING') DEFAULT 'PENDING' COMMENT 'Trạng thái thông báo',
    PRIMARY KEY (NOTIFICATIONID),
    FOREIGN KEY (CONTRACTID) REFERENCES CONTRACT(CONTRACTID)
);

/*==============================================================*/
/* Foreign Key Constraints                                      */
/*==============================================================*/
ALTER TABLE BILL
ADD CONSTRAINT FK_BILL_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID),
ADD CONSTRAINT FK_BILL_CONTRACT FOREIGN KEY (CONTRACTID) REFERENCES CONTRACT(CONTRACTID);

ALTER TABLE BILLDETAIL
ADD CONSTRAINT FK_BILLDETAIL_BILL FOREIGN KEY (BILLID) REFERENCES BILL(BILLID),
ADD CONSTRAINT FK_BILLDETAIL_SERVICE FOREIGN KEY (SERVICEID) REFERENCES SERVICE(SERVICEID);

ALTER TABLE PAYMENT
ADD CONSTRAINT FK_PAYMENT_BILL FOREIGN KEY (BILLID) REFERENCES BILL(BILLID);

ALTER TABLE FINGERPRINTS
ADD CONSTRAINT FK_FINGERPRINTS_USER FOREIGN KEY (USERNAME) REFERENCES USER(USERNAME),
ADD CONSTRAINT FK_FINGERPRINTS_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);

ALTER TABLE CONTRACT
ADD CONSTRAINT FK_CONTRACT_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID),
ADD CONSTRAINT FK_CONTRACT_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);
      
ALTER TABLE ROOM
ADD CONSTRAINT FK_ROOM_BUILDING FOREIGN KEY (BUILDINGID) REFERENCES BUILDING(BUILDINGID);
      
ALTER TABLE BUILDING
ADD CONSTRAINT FK_BUILDING_USER FOREIGN KEY (USERNAME) REFERENCES USER(USERNAME);

ALTER TABLE FEEDBACK
ADD CONSTRAINT FK_FEEDBACK_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);

ALTER TABLE PET
ADD CONSTRAINT FK_PET_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);

ALTER TABLE RELATIVE
ADD CONSTRAINT FK_RELATIVE_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID),
ADD CONSTRAINT FK_RELATIVE_TENANTRELATIVES FOREIGN KEY (RELATIVEID) REFERENCES TENANTRELATIVES(RELATIVEID);

ALTER TABLE RENTALHISTORY
ADD CONSTRAINT FK_RENTALHISTORY_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID);

ALTER TABLE TEMPORARY_RESIDENCE
ADD CONSTRAINT FK_TEMPORARY_RESIDENCE_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);

ALTER TABLE TENANTHISTORY
ADD CONSTRAINT FK_TENANTHISTORY_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID);

ALTER TABLE VEHICLE
ADD CONSTRAINT FK_VEHICLE_SERVICE FOREIGN KEY (SERVICEID) REFERENCES SERVICE(SERVICEID),
ADD CONSTRAINT FK_VEHICLE_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID),
ADD CONSTRAINT FK_VEHICLE_PARKINGMANAGEMENT FOREIGN KEY (PARKINGID) REFERENCES PARKINGMANAGEMENT(PARKINGID);

ALTER TABLE WATERELECTRICITY 
ADD CONSTRAINT FK_WATERELECTRICITY_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT (TENANTID),
ADD CONSTRAINT FK_WATERELECTRICITY_SERVICE FOREIGN KEY (SERVICEID) REFERENCES SERVICE (SERVICEID);