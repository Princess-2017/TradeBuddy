using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeBuddy.Business.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class profdb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursId",
                table: "TimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessHours",
                table: "BusinessHours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessHours",
                table: "BusinessHours",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_BusinessId",
                table: "BusinessHours",
                column: "BusinessId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursId",
                table: "TimeSlots",
                column: "BusinessHoursId",
                principalTable: "BusinessHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays",
                column: "BusinessId",
                principalTable: "BusinessHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursId",
                table: "TimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessHours",
                table: "BusinessHours");

            migrationBuilder.DropIndex(
                name: "IX_BusinessHours_BusinessId",
                table: "BusinessHours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessHours",
                table: "BusinessHours",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursId",
                table: "TimeSlots",
                column: "BusinessHoursId",
                principalTable: "BusinessHours",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays",
                column: "BusinessId",
                principalTable: "BusinessHours",
                principalColumn: "BusinessId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
