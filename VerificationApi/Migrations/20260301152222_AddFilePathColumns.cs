using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerificationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelfieUrl",
                table: "VerificationRequests");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "VerificationRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "VerificationRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfiePath",
                table: "VerificationRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "VerificationRequests");

            migrationBuilder.DropColumn(
                name: "SelfiePath",
                table: "VerificationRequests");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentNumber",
                table: "VerificationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfieUrl",
                table: "VerificationRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
