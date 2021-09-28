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
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "fe964f6a-0dba-4c42-823e-2671f98c5044", "User", "USER" },
                    { "f0b495e7-68e7-4b9b-bd53-81316f22d5c6", "05fdac14-f1c3-4498-a22f-46d2a108ad2b", "Approver", "APPROVER" },
                    { "43de098c-8ca7-42ae-8d78-ed6d04b645f3", "7bb5a863-8f5d-461b-a71c-78d25d974b34", "Auditor", "AUDITOR" },
                    { "5c362182-4c69-441a-b5dc-3f3d1951e7bf", "a272b761-d8d6-4560-be7e-875480cf6685", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3293219c-2e66-4bb6-961a-4cef432ef1f5", 0, "a45c5347-7d4e-47d8-9c6e-c61220137525", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAENn2S779wkCgOf0AEHt2mcb4bXeh7f9EjplYcl4zVz3FGsEaYRAVwKT9lcVycBTW4w==", null, false, "a1ff3be5-4a95-46d2-aaba-041f46a6f49a", false, "admin" },
                    { "aa3bf53f-0483-4c36-b25e-a5e1c128382f", 0, "5a39ddf3-26bd-44e4-823f-9d53d5add85b", null, false, false, null, null, "TESTING-USER", "AQAAAAEAACcQAAAAEEoB2a8jK/u2OLvCVDIogRehj3b7cI5Lhti3HmMs+F0kF5c000Maq/fEZHuYgPp16Q==", null, false, "d98eb0a1-c515-48f1-bc9c-d02fe2a45e08", false, "testing-user" },
                    { "4e4ff383-a8a3-4cfc-ae71-aca8724ef2e2", 0, "644a3c71-1020-4b97-9bf5-91c072f8fadc", null, false, false, null, null, "REDACTED-USER", "AQAAAAEAACcQAAAAEBNRMbZa0mawrZfJ3piRj6nK644K5YGE48szaoDhrqFme0fuLrRFVwJxkWZrYiDrQw==", null, false, "eaf6497e-52fa-4aa1-b9c1-d42ab885bdc9", false, "redacted-user" },
                    { "49ec4425-d734-439f-9126-6ac343161306", 0, "66556573-9ad4-4242-b961-5b6f79e37d9f", null, false, false, null, null, "PARTIAL-USER", "AQAAAAEAACcQAAAAEDjb90TvKs7YolDb1oNTEiRNFcv3sYyagm1RDHbDAmBfKuFq09pO/U9WLIiWKpZwew==", null, false, "0b1d2a75-e72c-4db8-bfca-239f563e8f87", false, "partial-user" },
                    { "7765e6a1-b018-4f50-922f-146d324f7e57", 0, "a43066b4-2536-42fa-981a-9c2069f3a3ea", null, false, false, null, null, "MODIFY-USER", "AQAAAAEAACcQAAAAEHr5v2BTQx4iO5CHA3ISllFdQz32mXhhxT5Qaa/RECCJKZoFDZ689XvCyemoUdoe0g==", null, false, "0011d0d4-e205-4f88-bfd3-6737c5587685", false, "modify-user" },
                    { "9f1293c7-8e8e-41ac-877e-e21b37eceec6", 0, "af7db58e-eda0-4a9f-bdbd-962a3f657be3", null, false, false, null, null, "NO-ACCESS-USER", "AQAAAAEAACcQAAAAEJ8eCKM5QGh4s0adQmJP20+SU2KPl/JlXO//CTtWPirzvtEZL1z/Sfzb62rIgkflRw==", null, false, "6e44023d-62b8-434b-afa7-116e327e86a7", false, "no-access-user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5c362182-4c69-441a-b5dc-3f3d1951e7bf", "3293219c-2e66-4bb6-961a-4cef432ef1f5" },
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "aa3bf53f-0483-4c36-b25e-a5e1c128382f" },
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "4e4ff383-a8a3-4cfc-ae71-aca8724ef2e2" },
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "49ec4425-d734-439f-9126-6ac343161306" },
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "7765e6a1-b018-4f50-922f-146d324f7e57" },
                    { "6ebb48da-c685-4021-a02d-7e126616a7b5", "9f1293c7-8e8e-41ac-877e-e21b37eceec6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43de098c-8ca7-42ae-8d78-ed6d04b645f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b495e7-68e7-4b9b-bd53-81316f22d5c6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c362182-4c69-441a-b5dc-3f3d1951e7bf", "3293219c-2e66-4bb6-961a-4cef432ef1f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ebb48da-c685-4021-a02d-7e126616a7b5", "49ec4425-d734-439f-9126-6ac343161306" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ebb48da-c685-4021-a02d-7e126616a7b5", "4e4ff383-a8a3-4cfc-ae71-aca8724ef2e2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ebb48da-c685-4021-a02d-7e126616a7b5", "7765e6a1-b018-4f50-922f-146d324f7e57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ebb48da-c685-4021-a02d-7e126616a7b5", "9f1293c7-8e8e-41ac-877e-e21b37eceec6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ebb48da-c685-4021-a02d-7e126616a7b5", "aa3bf53f-0483-4c36-b25e-a5e1c128382f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c362182-4c69-441a-b5dc-3f3d1951e7bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ebb48da-c685-4021-a02d-7e126616a7b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3293219c-2e66-4bb6-961a-4cef432ef1f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "49ec4425-d734-439f-9126-6ac343161306");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4e4ff383-a8a3-4cfc-ae71-aca8724ef2e2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7765e6a1-b018-4f50-922f-146d324f7e57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f1293c7-8e8e-41ac-877e-e21b37eceec6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa3bf53f-0483-4c36-b25e-a5e1c128382f");
        }
    }
}
