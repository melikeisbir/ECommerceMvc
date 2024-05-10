using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMvc.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Yetki",
                table: "Admins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Yetki",
                table: "Admins",
                type: "Char(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }
    }
}
