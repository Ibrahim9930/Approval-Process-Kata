using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AccessRequestDb
{
    public partial class seed_data_with_metadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccessRequests",
                columns: new[] { "RequestId", "AccessLevel", "CreatedBy", "CreatedOn", "EndTime", "ModifiedBy", "ModifiedOn", "StartTime", "Status", "UserId" },
                values: new object[,]
                {
                    { 1000, 4, "admin", new DateTime(2012, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "modify-user", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "admin" },
                    { 1001, 1, "admin", new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "modify-user", new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "redacted-user" },
                    { 1002, 2, "admin", new DateTime(2005, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "admin", new DateTime(2018, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "partial-user" },
                    { 1003, 4, "admin", new DateTime(2004, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "modify-user", new DateTime(2005, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "modify-user" },
                    { 1004, 3, "modify-user", new DateTime(2014, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), "modify-user", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "approve-user" },
                    { 100, 2, "modify-user", new DateTime(2018, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 101, 2, "admin", new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "modify-user", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "testing-user" },
                    { 102, 2, "admin", new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "modify-user", new DateTime(2006, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 103, 2, "admin", new DateTime(2017, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 104, 2, "admin", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "modify-user", new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "testing-user" },
                    { 2000, 2, "admin", new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "modify-user", new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "approved-user" }
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
        }
    }
}
