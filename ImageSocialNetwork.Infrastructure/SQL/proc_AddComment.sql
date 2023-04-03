if(exists(select * from sys.objects where name = 'proc_AddComment'))
drop procedure proc_AddComment
go

create proc proc_AddComment 
	@UserID int,
	@PostID int,
	@Text nvarchar(max),
	@Result int output
as
begin
	-- UserID invalid
	if(not exists (select * from Users as u where u.UserID = @UserID))
	begin
		set @Result = -1
		return;
	end;

	-- PostID invalid
	if(not exists (select * from Posts as p where p.PostID = @PostID))
	begin
		set @Result = -1
		return;
	end;

	-- coincide comment
	if(exists (select * from Comments as c where c.UserID = @UserID 
		and c.PostID = @PostID and c.Text = @Text))
	begin
		set @Result = -2
		return;
	end

	-- Insert into Followers table
	insert into Comments(UserID, PostID, Text) values (@UserID, @PostID, @Text)

	set @Result = @PostID
end
go

-- TEST 
declare @Result int
exec proc_AddComment
	@UserID = 1,
	@PostID = 1,
	@Text = N'haaha',
	@Result = @Result output
select @Result
select * from Comments