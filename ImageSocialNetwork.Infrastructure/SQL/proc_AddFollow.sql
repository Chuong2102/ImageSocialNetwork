if(exists(select * from sys.objects where name = 'proc_AddFollow'))
drop procedure proc_AddFollow
go

create proc proc_AddFollow 
	@UserID int,
	@UserFollowingID int,
	@Result int output
as
begin
	-- UserID invalid
	if(not exists (select * from Users as u where u.UserID = @UserID))
	begin
		set @Result = -1
		return;
	end;

	-- UserFollowID invalid
	if(not exists (select * from Users as u where u.UserID = @UserFollowingID))
	begin
		set @Result = -1
		return;
	end;

	-- Insert into Following table
	insert into Followings(UserID, FollowingUserID) values (@UserID, @UserFollowingID)
	-- Insert into Followers table
	insert into Followers(UserID, FollowerUserID) values (@UserFollowingID, @UserID)

	set @Result = 1
end
go

-- TEST 
declare @Result int
exec proc_AddFollow
	@UserID = 1,
	@UserFollowingID = 4,
	@Result = @Result output
select @Result