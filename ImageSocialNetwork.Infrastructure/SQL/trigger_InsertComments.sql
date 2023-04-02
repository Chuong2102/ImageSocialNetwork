drop trigger trg_Comments_instert
go
create trigger trg_Comments_instert
on Comments
for insert
as
begin
	update Posts
	set TotalComments = (select count(c.CommentID) from Comments as c
						join Posts as p on c.PostID = p.PostID
					 )
	where PostID in (select i.PostID from inserted as i)
end
go
insert into Comments(UserID, PostID) values (2, 1)
go
select * from Comments
select * from Posts

