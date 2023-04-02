drop trigger trg_Likes_instert
go
create trigger trg_Likes_instert
on Likes
for insert
as
begin
	update Posts
	set TotalLikes = (select count(l.LikeID) from Likes as l 
						join Posts as p on l.PostID = p.PostID
					 )
	where PostID in (select i.PostID from inserted as i)
end
go
insert into Likes(UserID, PostID) values (4, 1)
go
select * from Likes
select * from Posts

select count(l.LikeID) from Likes as l join Posts as p on l.PostID = p.PostID