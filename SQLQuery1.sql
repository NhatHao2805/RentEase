create database QuanLyThueNha;
go
use QuanLyThueNha;
go

create table Account(
	taikhoan varchar(100) primary key,
	matkhau varchar(20) not null
);

insert into Account values
('admin','admin'),
('user1','1234');

create proc proc_login 
@user varchar(100),
@pass varchar(20)
as
begin
	SELECT * FROM Account WHERE taikhoan = @user AND matkhau = @pass
end

create proc proc_addAccount 
@user varchar(100),
@pass varchar(20)
as
begin
	
		IF NOT EXISTS (SELECT 1 FROM Account WHERE taikhoan = @user)
        BEGIN
            insert into Account values 
			(@user,@pass)
        END
end
go

create function dbo.check_account(@user varchar(100))
returns int
as
begin	
	IF NOT EXISTS (SELECT 1 FROM Account WHERE taikhoan = @user)
	begin
		return 1
	end
	return 0 
		
end

