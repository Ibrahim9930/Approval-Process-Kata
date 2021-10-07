using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    public partial class new_logging_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 2000);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AccessRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AccessRequests",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AccessRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AccessRequests",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccessRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AccessRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AccessRequests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AccessRequests");

            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "EndTime", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 1000, 4, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin" },
                    { 1001, 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "redacted-user" },
                    { 1002, 2, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "partial-user" },
                    { 1003, 4, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "modify-user" },
                    { 1004, 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "approve-user" },
                    { 100, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 101, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "testing-user" },
                    { 102, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 103, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 104, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 2000, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "approved-user" }
                });
        }
    }
}
