using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageSocialNetwork.Infrastructure.Migrations
{
    public partial class ISN_Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FullName", "Gender", "LasLogin", "Phone", "ToltalFollower", "TotalFollowing", "TotalPost", "UserName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, 0, 0, "admin" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AcountID", "Password", "Role", "UserId", "Username" },
                values: new object[] { 1, "admin", "Admin", 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AcountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);
        }
    }
}
