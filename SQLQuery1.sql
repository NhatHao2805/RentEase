
USE rentease;
CREATE TABLE Account (
    taikhoan VARCHAR(100) PRIMARY KEY,
    matkhau VARCHAR(20) NOT NULL
);

INSERT INTO Account VALUES
('admin', 'admin'),
('user1', '1234');

-- Stored Procedure: proc_login
DELIMITER //
CREATE PROCEDURE proc_login (
    IN user VARCHAR(100),
    IN pass VARCHAR(20)
)
BEGIN
    SELECT * FROM Account WHERE taikhoan = user AND matkhau = pass;
END;
//
DELIMITER ;

-- Stored Procedure: proc_addAccount
DELIMITER //
CREATE PROCEDURE proc_addAccount (
    IN user VARCHAR(100),
    IN pass VARCHAR(20)
)
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Account WHERE taikhoan = user) THEN
        INSERT INTO Account (taikhoan, matkhau) VALUES (user, pass);
    END IF;
END;
//
DELIMITER ;

-- Function: check_account
DELIMITER //
CREATE FUNCTION check_account(user VARCHAR(100)) RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE account_exists INT;
    
    SELECT COUNT(*) INTO account_exists FROM Account WHERE taikhoan = user;
    
    IF account_exists = 0 THEN
        RETURN 1;
    ELSE
        RETURN 0;
    END IF;
END;
//
DELIMITER ;
