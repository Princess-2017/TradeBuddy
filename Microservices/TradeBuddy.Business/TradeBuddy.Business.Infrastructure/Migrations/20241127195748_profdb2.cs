using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeBuddy.Business.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class profdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessHours_Businesses_BusinessId1",
                table: "BusinessHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursBusinessId",
                table: "TimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_BusinessHoursBusinessId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_BusinessHours_BusinessId1",
                table: "BusinessHours");

            migrationBuilder.DropColumn(
                name: "BusinessHoursBusinessId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "BusinessId1",
                table: "BusinessHours");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessHoursId",
                table: "TimeSlots",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "TimeSlots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeleteBy",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "TimeSlots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "TimeSlots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_BusinessHoursId",
                table: "TimeSlots",
                column: "BusinessHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessHours_Businesses_BusinessId",
                table: "BusinessHours",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessHours_Businesses_BusinessId",
                table: "BusinessHours");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursId",
                table: "TimeSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_BusinessHoursId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "BusinessHoursId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "TimeSlots");

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessHoursBusinessId",
                table: "TimeSlots",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId1",
                table: "BusinessHours",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_BusinessHoursBusinessId",
                table: "TimeSlots",
                column: "BusinessHoursBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_BusinessId1",
                table: "BusinessHours",
                column: "BusinessId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessHours_Businesses_BusinessId1",
                table: "BusinessHours",
                column: "BusinessId1",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_BusinessHours_BusinessHoursBusinessId",
                table: "TimeSlots",
                column: "BusinessHoursBusinessId",
                principalTable: "BusinessHours",
                principalColumn: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_BusinessHours_BusinessId",
                table: "WorkingDays",
                column: "BusinessId",
                principalTable: "BusinessHours",
                principalColumn: "BusinessId");
        }
    }
}
