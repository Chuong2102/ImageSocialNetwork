if(exists (select * from sys.objects where name = 'proc_AddLike') )
drop proc proc_AddLike
go
create proc proc_AddLike
	@PostID int,
	@UserID int,
	@Result int output
as
begin
	-- Invalid PostID
	if(not exists (select * from Posts where PostID = @PostID))
	begin
		set @Result = -1;
		return;
	end;

	-- Invalid UserID
	if(not exists (select * from Users where UserID = @UserID))
	begin
	set @Result = -1;
		return;
	end;

	-- coincide Like
	if(exists (select * from Likes where UserID = @UserID and PostID = @PostID))
	begin
		set @Result = -1;
		return;
	end;

	-- add like
	insert into Likes(UserID, PostID) values (@UserID, @PostID)
	set @Result = 1;
end
go
-- TEST
declare @Result int
exec proc_AddLike
	@PostID = 3,
	@UserID = 2,
	@Result = @Result output 
go
select * from Likes
select * from Posts