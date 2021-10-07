using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class dto_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EpisodeEnemy");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EpisodeEnemy");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EpisodeEnemy");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "EpisodeEnemy");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EpisodeCompanion");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EpisodeCompanion");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EpisodeCompanion");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "EpisodeCompanion");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Episodes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Episodes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Enemies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Enemies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Companions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Episodes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Episodes",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EpisodeEnemy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EpisodeEnemy",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EpisodeEnemy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "EpisodeEnemy",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EpisodeCompanion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EpisodeCompanion",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EpisodeCompanion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "EpisodeCompanion",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Enemies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Enemies",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Doctors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Companions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Authors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2021, 1, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "modify-user", new DateTime(2021, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2019, 11, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "modify-user", new DateTime(2020, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2008, 11, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "modify-user", new DateTime(2020, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2015, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2018, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2003, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2015, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2020, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2021, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2020, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 10,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2003, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2004, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2019, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2000, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2002, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2003, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2010, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2020, 9, 2, 16, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2001, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 7,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2013, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 8,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2015, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2015, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 9,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "admin", new DateTime(2013, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "modify-user", new DateTime(2018, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 10,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { "modify-user", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "admin", new DateTime(2013, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) });
        }
    }
}
