using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class AddMimeTypeToFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                schema: "workers_wages",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MimeType",
                schema: "workers_wages",
                table: "Files");

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 16, 22, 8, 38, 547, DateTimeKind.Unspecified).AddTicks(2900), new TimeSpan(0, 4, 0, 0, 0)) });
        }
    }
}
