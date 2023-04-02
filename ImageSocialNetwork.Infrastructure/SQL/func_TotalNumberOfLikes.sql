if(exists(select * from sys.objects where name = N'func_TotalNumberOfLikes'))
drop function func_TotalNumberOfLikes
go

create function func_TotalNumberOfLikes(@PostID int)
returns int
as
begin
	declare @Sum int

	set @Sum = -1;
	-- PostID is invalid error
	if(not exists(select * from Posts as p where p.PostID = @PostID))
	begin
		return @Sum;
	end

	-- Count
	set @Sum = (select count(l.LikeID) from Posts as p join Likes as l on p.PostID = l.PostID
				where p.PostID = @PostID)
	
	return @Sum;
end
go
-- Test
select dbo.func_TotalNumberOfLikes(1) as N'Number of likes'


