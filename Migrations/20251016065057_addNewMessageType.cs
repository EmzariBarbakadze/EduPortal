using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPortal.Migrations
{
    /// <inheritdoc />
    public partial class addNewMessageType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JwtId",
                table: "UserTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Inf_NotificationTypes",
                columns: new[] { "NotificationTypeId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[] { 9, "Your account is locked", "თქვენი ანგარიში დაილოქა", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inf_NotificationTypes",
                keyColumn: "NotificationTypeId",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "JwtId",
                table: "UserTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
