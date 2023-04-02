if(exists(select * from sys.objects where name = 'proc_AddImage'))
drop procedure proc_AddImage
go
create proc proc_AddImage
	@PostID int,
	@ImagePath nvarchar(max),
	@Name nvarchar(10),
	@Result int output
as
begin
	-- Invalid PostID
	if(not exists (select * from Posts as p where p.PostID = @PostID))
	begin
		set @Result = -1
		return;
	end;
	-- Add new Image
	insert into Images(Name, PostID, ImagePath) values (@Name, @PostID, @ImagePath);
	set @Result = 1;

end