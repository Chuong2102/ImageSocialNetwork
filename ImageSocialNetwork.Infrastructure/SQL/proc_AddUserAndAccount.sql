if(exists(select * from sys.objects where name = 'proc_AddUserAndAccount'))
drop procedure proc_AddUserAndAccount
go
create procedure proc_AddUserAndAccount
	@Username nvarchar(max),
	@Fullname nvarchar(max),
	@Email nvarchar(max),
	@Phone nvarchar(50),
	@Gender bit,
	@DateOfBirth datetime,
	@Password nvarchar(50)
as
begin

	set nocount on;

-- Same Username error
	if(exists(select * from Users as u where u.UserName = @Username))
	begin
		return;
	end;
-- Same Username error
	if(exists(select * from Accounts as a where a.UserName = @Username))
	begin
		return;
	end;
-- Same Pass error
	if(exists(select * from Accounts as a where a.Password = @Password))
	begin
		return;
	end;
-- Same Email error
	if(exists(select * from Users as u where u.Email = @Email))
	begin
		return;
	end;
-- Same Phone error
	if(exists(select * from Users as u where u.Phone = @Phone))
	begin
		return;
	end;

-- Add

	declare @UserID int;

	insert into Users(UserName, FullName, Email, Phone, Gender, DateOfBirth)
	values (@Username, @Fullname, @Email, @Phone, @Gender, @DateOfBirth)

	set @UserID = @@IDENTITY

	insert into Accounts(Username, Password, Role, UserId)
	values(@Username, @Password, N'User', @UserID)

end
go
-- Test
exec proc_AddUserAndAccount
	@Username = N'arsvodich',
	@Fullname = N'Nguyen Thi Trung Cut',
	@Email = N'trungcut@gmail.com',
	@Phone = N'0289195503',
	@Gender = 1,
	@DateOfBirth = '1998-02-21',
	@Password = 'huhu'
go
select * from Users
select * from Accounts

