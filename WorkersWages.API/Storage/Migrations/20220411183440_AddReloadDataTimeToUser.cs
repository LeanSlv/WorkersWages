using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class AddReloadDataTimeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReloadDataTime",
                schema: "workers_wages",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 11, 22, 34, 38, 964, DateTimeKind.Unspecified).AddTicks(359), new TimeSpan(0, 4, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReloadDataTime",
                schema: "workers_wages",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 4, 9, 22, 16, 38, 844, DateTimeKind.Unspecified).AddTicks(5934), new TimeSpan(0, 4, 0, 0, 0)) });
        }
    }
}
