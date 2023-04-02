if(exists (select * from sys.objects where name = 'proc_DeletePost') )
drop proc proc_DeletePost
go
create proc proc_DeletePost
	@PostID int
as
begin
	-- Invalid PostID
	if(not exists (select * from Posts where PostID = @PostID))
	begin
		return;
	end;

	-- Delete Post and Images
	-- Delete Images
	delete from Images
	where PostID = @PostID
	-- Delete Post
	delete from Posts
	where PostID = @PostID
end
go
-- TEST
exec proc_DeletePost
	@PostID = 2
go
select * from Posts
select * from Images