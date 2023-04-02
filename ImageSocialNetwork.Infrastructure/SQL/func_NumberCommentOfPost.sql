if(exists (select * from sys.objects where name = 'func_NumberCommentOfPost'))
drop function func_NumberCommentOfPost
go
create function func_NumberCommentOfPost(@PostID int)
returns int
as
begin
	declare @Sum int;
	set @Sum = -1;

	-- Invalid PostID
	if(not exists(select * from Posts as p where p.PostID = @PostID))
	begin
		return @Sum;
	end

	-- 
	set @Sum = (select count(c.CommentID) from Posts as p join Comments as c 
	on p.PostID = c.PostID
	where p.PostID = @PostID
	)

	return @Sum;
end