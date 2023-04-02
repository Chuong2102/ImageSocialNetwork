if(exists(select * from sys.objects where name = 'proc_AddPost'))
drop procedure proc_AddPost
go
create proc proc_AddPost
	@UserID int,
	@Caption nvarchar(max),
	@PostID int output
as
begin
	-- Invalid UserID
	if(not exists (select * from Users as u where u.UserID = UserID))
	begin
		return;
	end
	-- Create new Post
	insert into Posts(Caption, UserID, CreationDate) values (@Caption, @UserID, getdate());
	set @PostID = @@Identity;

end