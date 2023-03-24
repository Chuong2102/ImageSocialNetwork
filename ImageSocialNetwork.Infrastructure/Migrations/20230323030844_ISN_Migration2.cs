using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageSocialNetwork.Infrastructure.Migrations
{
    public partial class ISN_Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPost",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalLikes",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToltalFollowing",
                table: "Followings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFollower",
                table: "Followers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalComment",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPost",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TotalLikes",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ToltalFollowing",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "TotalFollower",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "TotalComment",
                table: "Comments");
        }
    }
}
