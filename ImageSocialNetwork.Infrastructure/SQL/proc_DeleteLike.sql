if(exists (select * from sys.objects where name = 'proc_DeleteLike') )
drop proc proc_DeleteLike
go
create proc proc_DeleteLike
	@PostID int,
	@UserID int
as
begin
	-- Invalid PostID
	if(not exists (select * from Posts where PostID = @PostID))
	begin
		return;
	end;

	-- Invalid UserID
	if(not exists (select * from Users where UserID = @UserID))
	begin
		return;
	end;

	-- Delete Like
	delete from Likes
	where PostID = @PostID and UserID = @UserID
end
go
-- TEST
exec proc_DeleteLike
	@PostID = 1,
	@UserID = 2
go
select * from Likes