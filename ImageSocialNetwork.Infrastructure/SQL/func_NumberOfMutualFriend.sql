if(exists (select * from sys.objects where name = 'func_NumberOfMutualFriend'))
drop function func_NumberOfMutualFriend
go
create function func_NumberOfMutualFriend(@UserID int, @OtherUserID int)
returns @tblMutualFriend table
(
	UserID int
)
as
begin
	if(not exists (select * from Users as u where u.UserID = @UserID))
	begin
		return null;
	end

	insert into @tblMutualFriend
	select fling.FollowingUserID from Followings as fling join Users as u on u.UserID = fling.UserID 
	where u.UserID = @UserID and u.UserID = @OtherUserID
end