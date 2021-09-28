using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "EndTime", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 100, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 101, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "testing-user" },
                    { 102, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 103, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 104, 2, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
