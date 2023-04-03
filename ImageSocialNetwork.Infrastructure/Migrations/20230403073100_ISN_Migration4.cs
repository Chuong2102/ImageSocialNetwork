using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageSocialNetwork.Infrastructure.Migrations
{
    public partial class ISN_Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepliedCommentID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepliedCommentID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Comments");
        }
    }
}
