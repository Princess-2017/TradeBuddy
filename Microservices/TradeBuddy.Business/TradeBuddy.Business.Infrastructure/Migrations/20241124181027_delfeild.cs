using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeBuddy.Business.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class delfeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Businesses");

            migrationBuilder.RenameColumn(
                name: "AddressLine2",
                table: "Businesses",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Businesses",
                newName: "AddressLine2");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
