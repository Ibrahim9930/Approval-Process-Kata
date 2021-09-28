using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations.AuthDb
{
    public partial class new_approver_seeded_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "edff43f4-659a-4058-b510-6c08f515725c", "8037ec40-efad-4dcd-a07d-a7042756a4e5", "User", "USER" },
                    { "977ef184-f55d-4a49-bf72-8dba4f5ee567", "22ba96a0-c7a0-4958-a558-1333fd88524f", "Auditor", "AUDITOR" },
                    { "04b3983b-00da-40d6-bfe3-77614e9d591f", "6295d494-4d76-447b-894c-1329170d6345", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d62a8f6-910f-4862-ac29-6c0a8f4d73dc", 0, "0a010baf-3684-40f4-91b3-ba0e7cadce09", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEPQylZgPd1/mEWc/GoK/lbd0fseoe6Gnv/UAANH7KWYZVclEmoc7wVvnNoH3vz4nfA==", null, false, "9f24ea53-09fa-4072-866e-205f5f33148e", false, "admin" },
                    { "aad26a52-c9e0-49ca-8882-38fc1ba6d071", 0, "d629f86c-dd83-451d-89ac-a25c1816aeef", null, false, false, null, null, "TESTING-USER", "AQAAAAEAACcQAAAAEBXGiHoqYNvDRUBxZOh93X5eGmJZNXcIzHOuDsjevxNZcfKWi/w4e9LAv4AqJyTzrA==", null, false, "6039f7ad-c9b9-4bc2-8e4b-0da9d45b0a98", false, "testing-user" },
                    { "5e0d34c0-eefa-4f71-9402-42f44604fd6e", 0, "d2a204c6-6e8c-4b30-9f2f-c1d4343e4a80", null, false, false, null, null, "REDACTED-USER", "AQAAAAEAACcQAAAAECtDNastsmTgivqdKgATfyScGPx/FyGHiOdMKC+idp9GI6TBtSx+02koMGr42dJVxQ==", null, false, "4ad50586-4c9f-42a1-9bc3-057d0821673d", false, "redacted-user" },
                    { "bad9dd70-743a-4a9e-a7c5-0f8a2d8d5f50", 0, "c02c3aba-81c7-4c7f-b3c4-4f541928a72b", null, false, false, null, null, "PARTIAL-USER", "AQAAAAEAACcQAAAAEMJl09Xq+K1qo31+SBm7KKl1DuNeCn3S7wlSzEpW6v7/372TOKkr4Av6ZpUwLkUKhw==", null, false, "654823d2-ea7d-4479-b577-655c67f1a857", false, "partial-user" },
                    { "a4df0e81-7af1-49ea-83de-ea2f0de08eec", 0, "acf72589-80ec-4188-88a5-c91b01279c94", null, false, false, null, null, "MODIFY-USER", "AQAAAAEAACcQAAAAEIPaFlAjMTEQWHZg5LAqzY99ovpLZZP2qOTQxt5yFC8fdddKaoaYiMi0jiBVdeBKXA==", null, false, "055d76d9-75c9-40d4-83fd-0d52a6aaa219", false, "modify-user" },
                    { "ca68d77b-1270-4f2e-9f87-f6aee962a13e", 0, "d2746ad6-ba13-4290-a353-b500bf6d2cbc", null, false, false, null, null, "APPROVING-USER", "AQAAAAEAACcQAAAAEO/Ez67AdXKC5qj2y62ExPcea3UzS1I0w9Gsm4CmArInFtIuxXFPZvJcMBdYlAoSJQ==", null, false, "90368f60-2538-4529-8ff2-b863b0f8bfe3", false, "approving-user" },
                    { "0139cc5b-47f7-4564-a0ae-eb281e3005e5", 0, "742855ac-10cf-41b9-99ba-3a8879c4a08d", null, false, false, null, null, "APPROVED-USER", "AQAAAAEAACcQAAAAEJGf0wh+8URFbVMIXefcb25et9DMStP3Hfw8PIbULLAe+rNSHB/bqze9eT2QqnrvJw==", null, false, "2a3b3d0c-aa22-4a22-a1d1-542579f99884", false, "approved-user" },
                    { "d232752a-f83d-42b6-b28f-2960600350ba", 0, "09128a04-b17b-41c5-bfde-4d50183019a1", null, false, false, null, null, "NO-ACCESS-USER", "AQAAAAEAACcQAAAAEKi8v4ftGqojVz9tUKOvG7THNYtsAU57qeulQaDiB+2pHC0tgJ53ZXaVNr95fcjmMg==", null, false, "c6b28b7d-93cc-4e93-a99b-7f2bd48b25f9", false, "no-access-user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "04b3983b-00da-40d6-bfe3-77614e9d591f", "0d62a8f6-910f-4862-ac29-6c0a8f4d73dc" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "aad26a52-c9e0-49ca-8882-38fc1ba6d071" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "5e0d34c0-eefa-4f71-9402-42f44604fd6e" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "bad9dd70-743a-4a9e-a7c5-0f8a2d8d5f50" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "a4df0e81-7af1-49ea-83de-ea2f0de08eec" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "0139cc5b-47f7-4564-a0ae-eb281e3005e5" },
                    { "edff43f4-659a-4058-b510-6c08f515725c", "d232752a-f83d-42b6-b28f-2960600350ba" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "977ef184-f55d-4a49-bf72-8dba4f5ee567");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "0139cc5b-47f7-4564-a0ae-eb281e3005e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04b3983b-00da-40d6-bfe3-77614e9d591f", "0d62a8f6-910f-4862-ac29-6c0a8f4d73dc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "5e0d34c0-eefa-4f71-9402-42f44604fd6e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "a4df0e81-7af1-49ea-83de-ea2f0de08eec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "aad26a52-c9e0-49ca-8882-38fc1ba6d071" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "bad9dd70-743a-4a9e-a7c5-0f8a2d8d5f50" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "edff43f4-659a-4058-b510-6c08f515725c", "d232752a-f83d-42b6-b28f-2960600350ba" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca68d77b-1270-4f2e-9f87-f6aee962a13e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04b3983b-00da-40d6-bfe3-77614e9d591f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edff43f4-659a-4058-b510-6c08f515725c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0139cc5b-47f7-4564-a0ae-eb281e3005e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d62a8f6-910f-4862-ac29-6c0a8f4d73dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e0d34c0-eefa-4f71-9402-42f44604fd6e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4df0e81-7af1-49ea-83de-ea2f0de08eec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aad26a52-c9e0-49ca-8882-38fc1ba6d071");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bad9dd70-743a-4a9e-a7c5-0f8a2d8d5f50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d232752a-f83d-42b6-b28f-2960600350ba");

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
    }
}
