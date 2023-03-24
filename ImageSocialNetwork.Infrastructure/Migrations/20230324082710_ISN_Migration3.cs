using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageSocialNetwork.Infrastructure.Migrations
{
    public partial class ISN_Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_FollowingUserID",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_FollowerUserID",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "ToltalFollowing",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "TotalFollower",
                table: "Followers");

            migrationBuilder.DropColumn(
                name: "TotalComment",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TotalPost",
                table: "Posts",
                newName: "TotalLikes");

            migrationBuilder.RenameColumn(
                name: "FollowerUserID",
                table: "Followings",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_FollowerUserID",
                table: "Followings",
                newName: "IX_Followings_UserID");

            migrationBuilder.RenameColumn(
                name: "FollowingUserID",
                table: "Followers",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowingUserID",
                table: "Followers",
                newName: "IX_Followers_UserID");

            migrationBuilder.AddColumn<int>(
                name: "ToltalFollower",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFollowing",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPost",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalComments",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_UserID",
                table: "Followers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_UserID",
                table: "Followings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_UserID",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followings_Users_UserID",
                table: "Followings");

            migrationBuilder.DropColumn(
                name: "ToltalFollower",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalFollowing",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalPost",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TotalComments",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "TotalLikes",
                table: "Posts",
                newName: "TotalPost");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Followings",
                newName: "FollowerUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Followings_UserID",
                table: "Followings",
                newName: "IX_Followings_FollowerUserID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Followers",
                newName: "FollowingUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_UserID",
                table: "Followers",
                newName: "IX_Followers_FollowingUserID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_FollowingUserID",
                table: "Followers",
                column: "FollowingUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followings_Users_FollowerUserID",
                table: "Followings",
                column: "FollowerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
