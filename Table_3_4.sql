drop database if exists rentease;
CREATE DATABASE rentease DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE rentease;

Create table keyManager(
	usern varchar(20),
    keybuilding varchar(20)
);

/*==============================================================*/
/* Table: TENANT                                                */
/*==============================================================*/
CREATE TABLE TENANT (
	USERNAME			 VARCHAR(20) NOT NULL COMMENT 'ID chủ nhà',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    FIRSTNAME            VARCHAR(50) COMMENT 'Tên',
    LASTNAME             VARCHAR(50) COMMENT 'Họ',
    BIRTHDAY             DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    PHONENUMBER          VARCHAR(20) COMMENT 'Số điện thoại',
    EMAIL                VARCHAR(50) COMMENT 'Email',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (TENANTID)
);

/*==============================================================*/
/* Table: BILL                                                  */
/*==============================================================*/
CREATE TABLE BILL (
    BILLID               VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    TOTAL                FLOAT COMMENT 'Tổng số tiền',
    START_DATE           DATETIME COMMENT 'Thời gian bắt đầu thanh toán',
    END_DATE          	 DATETIME COMMENT 'Thời gian kết thúc thanh toán',
    NOTIFICATION_SENT    BOOLEAN DEFAULT FALSE COMMENT 'Đánh dấu thông báo nhắc nợ đã được gửi',
    REFUND_AMOUNT        FLOAT COMMENT 'Số tiền hoàn trả',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (BILLID)
);

/*==============================================================*/
/* Table: SERVICE                                                  */
/*==============================================================*/
CREATE TABLE SERVICE (
    SERVICEID               VARCHAR(10) NOT NULL COMMENT 'ID dịch vụ',
    SERVICENAME             VARCHAR(100) NOT NULL COMMENT 'Tên dịch vụ',
    UNITPRICE           	FLOAT NOT NULL COMMENT 'Đơn giá',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (SERVICEID)
);

/*==============================================================*/
/* Table: BILLDETAIL                                                  */
/*==============================================================*/
CREATE TABLE BILLDETAIL (
	BILLDETAIL_ID			VARCHAR(10) NOT NULL COMMENT 'ID chi tiết hóa đơn',
	BILLID               	VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    ID						VARCHAR(10) NOT NULL COMMENT 'ID',
    AMOUNT           		FLOAT NOT NULL COMMENT 'Thành tiền',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY(BILLDETAIL_ID)
);

/*==============================================================*/
/* Table: PAYMENT                                                  */
/*==============================================================*/
CREATE TABLE PAYMENT (
	PAYMENTID               VARCHAR(10) NOT NULL COMMENT 'ID thanh toán',
    BILLID               	VARCHAR(10) NOT NULL COMMENT 'ID hóa đơn',
    METHOD               	VARCHAR(50) NOT NULL COMMENT 'Phương thức',
    TOTAL             		FLOAT NOT NULL COMMENT 'Tổng tiền',
    PAYMENTTIME           	FLOAT NOT NULL COMMENT 'Thời gian thanh toán',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
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
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
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
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
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
    DATESEND			 DATE COMMENT 'Ngày gửi',
    STATUS               ENUM('PENDING', 'RESOLVED') DEFAULT 'PENDING' COMMENT 'Trạng thái xử lý',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (FEEDBACKID)
);

/*==============================================================*/
/* Table: BUILDING                                                 */
/*==============================================================*/
CREATE TABLE BUILDING (
    BUILDINGID              VARCHAR(10) NOT NULL COMMENT 'ID tòa nhà',
    BUILDING_KEY			VARCHAR(10),
    USERNAME             	VARCHAR(20) NOT NULL COMMENT 'Tên người dùng',
    ADDRESS                 VARCHAR(100) COMMENT 'Địa chỉ',
    NUMOFFLOORS             INT COMMENT 'Số lượng tầng',
    NUMOFROOMS              INT COMMENT 'Số lượng phòng',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (BUILDINGID)
);

/*==============================================================*/
/* Table: ROOM                                                 */
/*==============================================================*/
CREATE TABLE ROOM (
    ROOMID              VARCHAR(10) NOT NULL COMMENT 'ID nhà',
    ROOMNAME			VARCHAR(10) NOT NULL COMMENT 'Tên nhà',
    BUILDINGID           VARCHAR(10) NOT NULL COMMENT 'ID tòa nhà',
    TYPE                 VARCHAR(50) COMMENT 'Loại nhà',
    FLOOR				INT COMMENT 'Tầng nhà',
    CONVENIENT           VARCHAR(200) COMMENT 'Tiện ích',
    AREA                 FLOAT COMMENT 'Diện tích',
    PRICE                FLOAT COMMENT 'Giá',
    STATUS               VARCHAR(50) COMMENT 'Trạng thái',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (ROOMID)
);

/*==============================================================*/
/* Table: ASSETS                                                 */
/*==============================================================*/
CREATE TABLE ASSETS (
    ASSETID              	VARCHAR(10) NOT NULL COMMENT 'ID tài sản',
    ROOMID           		VARCHAR(10) NOT NULL COMMENT 'ID phòng',
    ASSETNAME               VARCHAR(50) COMMENT 'Tên tài sản',
    PRICE                	FLOAT COMMENT 'Giá',
    STATUS               	VARCHAR(50) COMMENT 'Trạng thái',
    USE_DATE 				DATE COMMENT 'Ngày đưa vào sử dụng',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (ASSETID)
);

/* Table: MAINTENANCE                                                 */
/*==============================================================*/
CREATE TABLE MAINTENANCE (
	MAINTENANCEID           VARCHAR(10) NOT NULL COMMENT 'ID tài sản',
    ASSETID              	VARCHAR(10) NOT NULL COMMENT 'ID tài sản',
    MAINTENANCE_DATE 		DATE COMMENT 'Ngày bảo trì',
    DESCRIPTION				TEXT COMMENT 'Mô tả công việc bảo trì',
    STATUS               	VARCHAR(50) COMMENT 'Trạng thái',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (MAINTENANCEID)
);

/*==============================================================*/
/* Table: REPAIR_REQUEST                                                 */
/*==============================================================*/
CREATE TABLE REPAIR_REQUEST (
	REQUESTID              	VARCHAR(10) NOT NULL COMMENT 'ID yêu cầu',
    ASSETID              	VARCHAR(10) NOT NULL COMMENT 'ID tài sản',
    TENANTID           		VARCHAR(10) NOT NULL COMMENT 'ID khách thuê',
    REQUEST_DATE 			DATE COMMENT 'Ngày yêu cầu',
    DESCRIPTION				TEXT COMMENT 'Mô tả yêu cầu',
    STATUS               	VARCHAR(50) COMMENT 'Trạng thái',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (REQUESTID)
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
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (USERNAME)
);

/*==============================================================*/
/* Table: PARKINGMANAGEMENT                                     */
/*==============================================================*/
CREATE TABLE PARKINGAREA (
    AREAID            		VARCHAR(10) NOT NULL COMMENT 'ID bãi đậu xe',
    BUILDINGID				VARCHAR(10) NOT NULL COMMENT 'ID tòa nhà',
    ADDRESS              	VARCHAR(100) COMMENT 'Địa chỉ',
    TYPE             	    VARCHAR(50) COMMENT 'Loại bãi đậu xe',
    CAPACITY           		INT COMMENT 'Sức chứa',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (AREAID)
);

/*==============================================================*/
/* Table: PARKING                                     */
/*==============================================================*/
CREATE TABLE PARKING (
    PARKINGID            		VARCHAR(10) NOT NULL COMMENT 'ID chỗ đậu xe',
    AREAID						VARCHAR(10) NOT NULL COMMENT 'ID bãi đậu xe',
    VEHICLEID              		VARCHAR(10) COMMENT 'ID xe',
    STATUS						VARCHAR(20) COMMENT 'Tình trạng',
    ISDELETED			 		INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 		DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (PARKINGID)
);

/*==============================================================*/
/* Table: PET                                                   */
/*==============================================================*/
CREATE TABLE PET (
	PETID					VARCHAR(10) NOT NULL COMMENT 'ID thú cưng',
    TENANTID             	VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    TYPE		    	    VARCHAR(20) COMMENT 'Loại động vật',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (PETID)
);

/*==============================================================*/
/* Table: RELATIONSHIP                                          */
/*==============================================================*/
CREATE TABLE RELATIVES (
    RELATIVEID       	 VARCHAR(10) NOT NULL COMMENT 'ID mối quan hệ',
    FULLNAME             VARCHAR(50) COMMENT 'Họ và tên',
    BIRTH                DATE COMMENT 'Ngày sinh',
    GENDER               VARCHAR(10) COMMENT 'Giới tính',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (RELATIVEID)
);

/*==============================================================*/
/* Table: RELATIVE                                              */
/*==============================================================*/
CREATE TABLE RELATIONSHIP (
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    RELATIVEID       	 VARCHAR(10) NOT NULL COMMENT 'ID mối quan hệ',
    RELATIONSHIP         VARCHAR(50) COMMENT 'Mối quan hệ',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (TENANTID, RELATIVEID)
);

/*==============================================================*/
/* Table: RENTAL_HISTORY                                         */
/*==============================================================*/
CREATE TABLE RENTAL_HISTORY (
    CONTRACTID              VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    ROOMID          		VARCHAR(10) NOT NULL COMMENT 'ID phòng',
    TENANTID            	VARCHAR(100) NOT NULL COMMENT 'ID khách thuê',
    STARTDATE            	DATETIME COMMENT 'Ngày bắt đầu',
    ENDDATE              	DATETIME COMMENT 'Ngày kết thúc',
    REASON_FOR_LEAVING   	VARCHAR(200) COMMENT 'Lý do rời đi',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (CONTRACTID)
);

/*==============================================================*/
/* Table: TEMPORARY_RESIDENCE                                   */
/*==============================================================*/
CREATE TABLE TEMPORARY_REGISTRATION (
	REGISTRATIONID		VARCHAR(10) NOT NULL COMMENT 'ID bản đăng ký',
    TENANTID            VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
	ROOMID				VARCHAR(10) NOT NULL COMMENT 'ID phòng đăng ký tạm trú',
	REGISTRATION_DATE  	DATETIME COMMENT 'Ngày đăng ký ở',
    EXPIRATION_DATE		DATETIME COMMENT 'Ngày hết hạn',
    STATUS				VARCHAR(50) COMMENT 'Trạng thái bản đăng ký',
    CREATE_DATE			DATETIME COMMENT 'Ngày tạo bản đăng ký',
    UPDATE_DATE			DATETIME COMMENT 'Ngày cập nhật',
    ISDELETED			INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (REGISTRATIONID)
);

/*==============================================================*/
/* Table: USE_SERVICE                                               */
/*==============================================================*/
CREATE TABLE USE_SERVICE (
    TENANTID            VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
	SERVICEID			VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    START_DATE          DATE COMMENT 'Ngày bắt đầu sử dụng',
    END_DATE            DATE COMMENT 'Ngày kết thúc sử dụng',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (TENANTID, SERVICEID)
);
 
/*==============================================================*/
/* Table: TENANTHISTORY                                         */
/*==============================================================*/
CREATE TABLE TENANT_HISTORY (
	HISTORYID			VARCHAR(10) NOT NULL COMMENT 'ID lịch sử thuê',
    CONTRACTID			VARCHAR(10) NOT NULL COMMENT 'ID hợp đồng',
    TENANTID            VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    ROOMID              VARCHAR(100) COMMENT 'ID phòng',
    STARTDATE            DATETIME COMMENT 'Ngày bắt đầu',
    ENDDATE				DATETIME COMMENT 'Ngày kết thúc',
    NOTES                VARCHAR(200) COMMENT 'Ghi chú',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (HISTORYID)
);


/*==============================================================*/
/* Table: VEHICLE                                               */
/*==============================================================*/
CREATE TABLE VEHICLE (
    VEHICLEID            	VARCHAR(10) NOT NULL COMMENT 'ID phương tiện',
    TENANTID             	VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    VEHICLE_UNITPRICE_ID	VARCHAR(10) NOT NULL COMMENT 'ID đơn giá phương tiện',
    TYPE                 	VARCHAR(50) COMMENT 'Loại phương tiện',
    LICENSEPLATE         	VARCHAR(20) COMMENT 'Biển số xe',
    ISDELETED			 	INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 	DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (VEHICLEID)
);

/*==============================================================*/
/* Table: VEHICLE_UNITPRICE                                               */
/*==============================================================*/
CREATE TABLE VEHICLE_UNITPRICE (
    VEHICLE_UNITPRICE_ID            VARCHAR(10) NOT NULL COMMENT 'ID đơn giá phương tiện',
    UNITPRICE         				FLOAT COMMENT 'Đơn giá',
    TYPE							VARCHAR(50) COMMENT 'phân loại phương tiện',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (VEHICLE_UNITPRICE_ID)
);

/*==============================================================*/
/* Table: WATERELECTRICITY                                      */
/*==============================================================*/
CREATE TABLE WATER_ELECTRICITY (
    FIGUREID             VARCHAR(10) NOT NULL COMMENT 'ID chỉ số',
    UNITPRICEID			 VARCHAR(10) NOT NULL COMMENT 'ID đơn giá',
    TENANTID             VARCHAR(10) NOT NULL COMMENT 'ID người thuê',
    OLDFIGURE            FLOAT COMMENT 'Chỉ số cũ',
    NEWFIGURE            FLOAT COMMENT 'Chỉ số mới',
    UNIT                 VARCHAR(10) COMMENT 'Đơn vị tính',
    START_DATE           DATE COMMENT 'Ngày bắt đầu tính',
    END_DATE             DATE COMMENT 'Ngày kết thúc tính',
    RECORD_DATE          DATE COMMENT 'Ngày ghi chỉ số',
    TYPE                 ENUM('ELECTRICITY', 'WATER') NOT NULL COMMENT 'Loại chỉ số (điện/nước)',
    ISDELETED			 INT DEFAULT 0 COMMENT 'Đánh dấu đã xóa',
    DELETED_DATE 		 DATE COMMENT 'Ngày bắt đầu xóa (đếm ngược 30 ngày)',
    PRIMARY KEY (FIGUREID)
);

/*==============================================================*/
/* Table: WATER_ELEC_UNITPRICE                                      */
/*==============================================================*/
CREATE TABLE WATER_ELECT_UNITPRICE (
    UNITPRICEID          VARCHAR(20) NOT NULL COMMENT 'ID đơn giá',
    TYPE			 	 VARCHAR(20) COMMENT 'Phân loại điện/nước',
    UNITPRICE            FLOAT COMMENT 'Đơn giá',
    PRIMARY KEY (UNITPRICEID)
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

-- Bảng BILL
ALTER TABLE BILL
ADD CONSTRAINT FK_BILL_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng BILLDETAIL
ALTER TABLE BILLDETAIL
ADD CONSTRAINT FK_BILLDETAIL_BILL FOREIGN KEY (BILLID) REFERENCES BILL(BILLID) ON DELETE CASCADE;

-- Bảng PAYMENT
ALTER TABLE PAYMENT
ADD CONSTRAINT FK_PAYMENT_BILL FOREIGN KEY (BILLID) REFERENCES BILL(BILLID) ON DELETE CASCADE;

-- Bảng FINGERPRINTS
ALTER TABLE FINGERPRINTS
ADD CONSTRAINT FK_FINGERPRINTS_USER FOREIGN KEY (USERNAME) REFERENCES USER(USERNAME) ON DELETE CASCADE,
ADD CONSTRAINT FK_FINGERPRINTS_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng CONTRACT
ALTER TABLE CONTRACT
ADD CONSTRAINT FK_CONTRACT_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID) ON DELETE CASCADE,
ADD CONSTRAINT FK_CONTRACT_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng ROOM
ALTER TABLE ROOM
ADD CONSTRAINT FK_ROOM_BUILDING FOREIGN KEY (BUILDINGID) REFERENCES BUILDING(BUILDINGID) ON DELETE CASCADE;

-- Bảng TENANT
ALTER TABLE TENANT
ADD CONSTRAINT FK_TENANT_USER FOREIGN KEY (USERNAME) REFERENCES USER(USERNAME) ON DELETE CASCADE;

-- Bảng ASSETS
ALTER TABLE ASSETS
ADD CONSTRAINT FK_ASSETS_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID) ON DELETE CASCADE;

-- Bảng MAINTENANCE
ALTER TABLE MAINTENANCE
ADD CONSTRAINT FK_MAINTENANCE_ASSETS FOREIGN KEY (ASSETID) REFERENCES ASSETS(ASSETID) ON DELETE CASCADE;

-- Bảng REPAIR_REQUEST
ALTER TABLE REPAIR_REQUEST
ADD CONSTRAINT FK_REPAIR_REQUEST_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_REPAIR_REQUEST_ASSETS FOREIGN KEY (ASSETID) REFERENCES ASSETS(ASSETID) ON DELETE CASCADE;

-- Bảng BUILDING
ALTER TABLE BUILDING
ADD CONSTRAINT FK_BUILDING_USER FOREIGN KEY (USERNAME) REFERENCES USER(USERNAME) ON DELETE CASCADE;

-- Bảng FEEDBACK
ALTER TABLE FEEDBACK
ADD CONSTRAINT FK_FEEDBACK_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng PET
ALTER TABLE PET
ADD CONSTRAINT FK_PET_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng RELATIONSHIP
ALTER TABLE RELATIONSHIP
ADD CONSTRAINT FK_RELATIONSHIP_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_RELATIONSHIP_RELATIVES FOREIGN KEY (RELATIVEID) REFERENCES RELATIVES(RELATIVEID) ON DELETE CASCADE;

-- Bảng RENTAL_HISTORY
ALTER TABLE RENTAL_HISTORY
ADD CONSTRAINT FK_RENTAL_HISTORY_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID) ON DELETE CASCADE,
ADD CONSTRAINT FK_RENTAL_HISTORY_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng TEMPORARY_REGISTRATION
ALTER TABLE TEMPORARY_REGISTRATION
ADD CONSTRAINT FK_TEMPORARY_REGISTRATION_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_TEMPORARY_REGISTRATION_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID) ON DELETE CASCADE;

-- Bảng TENANT_HISTORY
ALTER TABLE TENANT_HISTORY
ADD CONSTRAINT FK_TENANT_HISTORY_CONTRACT FOREIGN KEY (CONTRACTID) REFERENCES CONTRACT(CONTRACTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_TENANT_HISTORY_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_TENANT_HISTORY_ROOM FOREIGN KEY (ROOMID) REFERENCES ROOM(ROOMID) ON DELETE CASCADE;

-- Bảng VEHICLE
ALTER TABLE VEHICLE
ADD CONSTRAINT FK_VEHICLE_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng PARKING
ALTER TABLE PARKING
ADD CONSTRAINT FK_PARKING_VEHICLE FOREIGN KEY (VEHICLEID) REFERENCES VEHICLE(VEHICLEID) ON DELETE CASCADE,
ADD CONSTRAINT FK_PARKING_PARKINGAREA FOREIGN KEY (AREAID) REFERENCES PARKINGAREA(AREAID) ON DELETE CASCADE;

-- Bảng PARKINGAREA
ALTER TABLE PARKINGAREA
ADD CONSTRAINT FK_PARKINGAREA_BUILDING FOREIGN KEY (BUILDINGID) REFERENCES BUILDING(BUILDINGID) ON DELETE CASCADE;

-- Bảng WATER_ELECTRICITY
ALTER TABLE WATER_ELECTRICITY
ADD CONSTRAINT FK_WATER_ELECTRICITY_UNITPRICE FOREIGN KEY (UNITPRICEID) REFERENCES WATER_ELECT_UNITPRICE(UNITPRICEID) ON DELETE CASCADE,
ADD CONSTRAINT FK_WATER_ELECTRICITY_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE;

-- Bảng USE_SERVICE
ALTER TABLE USE_SERVICE
ADD CONSTRAINT FK_USE_SERVICE_TENANT FOREIGN KEY (TENANTID) REFERENCES TENANT(TENANTID) ON DELETE CASCADE,
ADD CONSTRAINT FK_USE_SERVICE_SERVICE FOREIGN KEY (SERVICEID) REFERENCES SERVICE(SERVICEID) ON DELETE CASCADE;

-- Bảng CONTRACT_NOTIFICATION
ALTER TABLE CONTRACT_NOTIFICATION
ADD CONSTRAINT FK_CONTRACT_NOTIFICATION_CONTRACT FOREIGN KEY (CONTRACTID) REFERENCES CONTRACT(CONTRACTID) ON DELETE CASCADE;

-- Huy new- 9/4
ALTER TABLE FINGERPRINTS
ADD FINGERPRINT_IMAGE LONGBLOB COMMENT 'Dữ liệu ảnh vân tay',
ADD IMAGE_NAME VARCHAR(100) COMMENT 'Tên file ảnh vân tay';
-- Huy new- 9/4

-- Huy New 19/4 
-- Nếu cần thêm cột EMAIL vào bảng FEEDBACK
ALTER TABLE FEEDBACK ADD COLUMN EMAIL VARCHAR(50) AFTER TENANTID;

-- Nếu cần thêm cột HAS_FEEDBACK để lưu trạng thái Có/Không
ALTER TABLE FEEDBACK ADD COLUMN HAS_FEEDBACK BOOLEAN DEFAULT TRUE AFTER EMAIL;