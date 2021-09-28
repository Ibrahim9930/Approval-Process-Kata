using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AuthDb
{
    public partial class seeded_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f5c24019-98da-4ee0-94fe-b4c0bab4d89f", "12bb292a-ca4d-41af-bc14-8bbd6027b956", "User", "USER" },
                    { "bf4aea3c-2b01-43fc-b871-13596457e8f1", "0a67c036-ff13-4c17-acb3-28a8b6f1af2f", "Approver", "APPROVER" },
                    { "4d70e870-d9e5-4834-ab07-355f9629228e", "f5d0111c-f5f8-416c-84bf-9a21ed4510cb", "Auditor", "AUDITOR" },
                    { "366b3296-2c88-48b0-a831-c5a3aa328df8", "e3a9d500-7723-44f0-abe0-7e3653e19488", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bc952842-3f0d-4f85-a950-11ad230572e1", 0, "6cccb872-7407-46a5-9eaa-97222893d699", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIv3KNsmIrbqifqvKLHWrE9ClxlZ/kUl0BkPn09hK5hLJ5yLCbhuei4vHkxtTuDsjQ==", null, false, "afe8bc58-8c15-4f0b-a8ef-da1ed5e8b17f", false, "admin" },
                    { "9063ba71-9fda-4374-b678-cdcc3eade8f6", 0, "0798488d-7c4c-4ba2-bfd7-8661dd54cbda", null, false, false, null, null, "TESTING-USER", "AQAAAAEAACcQAAAAELoh74oFCzT4FMYHJglYN0axhM/SjOyVGeyfSggNiPFbO46Mvf/+4X5kI04aZ6pbNg==", null, false, "0b9efaa7-ea88-47d4-baba-8639da808847", false, "testing-user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "366b3296-2c88-48b0-a831-c5a3aa328df8", "bc952842-3f0d-4f85-a950-11ad230572e1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f5c24019-98da-4ee0-94fe-b4c0bab4d89f", "9063ba71-9fda-4374-b678-cdcc3eade8f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d70e870-d9e5-4834-ab07-355f9629228e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4aea3c-2b01-43fc-b871-13596457e8f1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f5c24019-98da-4ee0-94fe-b4c0bab4d89f", "9063ba71-9fda-4374-b678-cdcc3eade8f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "366b3296-2c88-48b0-a831-c5a3aa328df8", "bc952842-3f0d-4f85-a950-11ad230572e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366b3296-2c88-48b0-a831-c5a3aa328df8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5c24019-98da-4ee0-94fe-b4c0bab4d89f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9063ba71-9fda-4374-b678-cdcc3eade8f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc952842-3f0d-4f85-a950-11ad230572e1");
        }
    }
}
