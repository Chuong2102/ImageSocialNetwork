if(exists(select * from sys.objects where name = 'func_NumberFollower'))
drop function func_NumberFollower
go
create function func_NumberFollower(@UserID int)
returns int
as
begin
	declare @sum int

	--
	if(not exists(select * from Users as u where u.UserID = @UserID))
	begin
		set @sum = -1
		return @sum
	end

	--
	set @sum = (select count(ISNULL(f.FollowerUserID, 0)) from Users as u join Followers as f 
				on u.UserID = f.UserID
				where u.UserID = @UserID
				)
	return @sum
end
go
-- Test
select dbo.func_NumberFollower(4)
go
select * from Users