using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeBuddy.Business.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class delfeilds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursOfOperation",
                table: "Businesses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoursOfOperation",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
