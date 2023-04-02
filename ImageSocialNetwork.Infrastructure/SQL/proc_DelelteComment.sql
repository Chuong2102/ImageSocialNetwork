if(exists (select * from sys.objects where name = 'proc_DeleteComment') )
drop proc proc_DeleteComment
go
create proc proc_DeleteComment
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
	delete from Comments
	where PostID = @PostID and UserID = @UserID
end
go
-- TEST
exec proc_DeleteComment
	@PostID = 1,
	@UserID = 2
go
select * from Comments