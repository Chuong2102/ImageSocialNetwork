select * from dbo.Certificates
select * from dbo.Examinees
select * from dbo.Registrations

-- 1. proc_AddRegistration
if (exists(select * from sys.objects where name ='proc_AddRegistration')) 
drop procedure proc_AddRegistration
go
create proc proc_AddRegistration
	@CertificateId int,
	@ExamineeId int,
	@Result nvarchar(50) output
as
begin
	if (not exists (select * from Certificates as c where c.CertificateId = @CertificateId))
	begin
		set @Result = 'CertificateId khong hop le';
		return;
	end;

	if (not exists (select * from Examinees as e where e.ExamineeId = @ExamineeId))
	begin
		set @Result = 'ExamineeId khong hop le'
		return;
	end;
	insert into Registrations(CertificateId, ExamineeId) values (@CertificateId, @ExamineeId)
	set @Result = 'Thanh cong'
end
go
-- TEST
declare @Result nvarchar(50)
exec proc_AddRegistration
	@CertificateId = 2,
	@ExamineeId = 3,
	@Result = @Result output

select @Result
go
select * from Registrations
go

-- 2.a
go
drop trigger trg_Registrations_Insert
go
create trigger trg_Registrations_Insert 
on Registrations
for insert
as
begin
	update Examinees
	set CountOfRegistered = (select count(r.ExamineeId) from inserted as i join Registrations as r 
	on i.ExamineeId = r.ExamineeId)
	where ExamineeId in (select i.ExamineeId from inserted as i) 
end
go
-- TEST
insert into Registrations(CertificateId, ExamineeId) values (3, 1)
go
select * from Examinees
select * from Registrations
go
-- 3.a
if(exists (select * from sys.objects where name ='func_CountRegistered'))
drop function func_CountRegistered
go
create function func_CountRegistered(@DateFrom date, @DateTo date)
returns int
as
begin
	declare @sum int
	set @sum = (select count(r.CertificateId) from Registrations as r 
	where r.RegisterTime between @DateFrom and @DateTo)

	return @sum
end
go
-- TEST
select dbo.func_CountRegistered('2021-12-19','2023-03-22')
select * from Registrations