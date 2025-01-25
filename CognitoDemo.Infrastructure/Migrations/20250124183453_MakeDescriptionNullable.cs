using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CognitoDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeDescriptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(999)",
                maxLength: 999,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(999)",
                oldMaxLength: 999);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(999)",
                maxLength: 999,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(999)",
                oldMaxLength: 999,
                oldNullable: true);
        }
    }
}
