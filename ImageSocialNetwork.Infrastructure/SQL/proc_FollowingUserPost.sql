select p.PostID as N'PostID', p.Caption as N'Caption', p.CreationDate as N'Date'
from Users as u 
join Followings as f on u.UserID = f.UserID
join Posts as p on p.UserID = f.FollowingUserID
where u.UserID = 1
group by p.PostID, p.Caption, p.CreationDate
order by p.CreationDate

if(exists (select * from sys.objects where name = N'proc_FollowingPost'))
drop proc proc_FollowingPost
go
create proc proc_FollowingPost
	@UserID int
as
begin
	-- Invalid UserID
	if(not exists (select * from Users where UserID = @UserID))
	begin
		return;
	end

	select p.PostID, p.Caption, p.UserID, p.CreationDate, p.TotalLikes, p.TotalComments
	from Users as u 
	join Followings as f on u.UserID = f.UserID
	join Posts as p on p.UserID = f.FollowingUserID
	where u.UserID = @UserID
	group by p.PostID, p.Caption, p.CreationDate, p.UserID, p.TotalLikes, p.TotalComments
	order by p.CreationDate
end
go
exec proc_FollowingPost
	@UserId = 2

select * from Posts
select * from Followings
