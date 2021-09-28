using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    public partial class new_approver_seeded_request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "EndTime", "StartTime", "Status", "UserId" },
                values: new object[] { 1004, 3, new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "approve-user" });

            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "EndTime", "StartTime", "Status", "UserId" },
                values: new object[] { 2000, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "approved-user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "AccessRequests",
                keyColumn: "RequestId",
                keyValue: 2000);
        }
    }
}
