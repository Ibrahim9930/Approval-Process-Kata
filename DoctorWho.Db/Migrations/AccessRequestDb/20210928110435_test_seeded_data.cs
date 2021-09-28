using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    public partial class test_seeded_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "EndTime", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 1000, 4, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin" },
                    { 1001, 1, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "redacted-user" },
                    { 1002, 2, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "partial-user" },
                    { 1003, 4, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "modify-user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
