using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class AddLinksBetweenModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoId",
                schema: "workers_wages",
                table: "Manufactories",
                newName: "HeadPhotoId");

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 10, 12, 55, 19, 689, DateTimeKind.Unspecified).AddTicks(2726), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Wages_ManufactoryId",
                schema: "workers_wages",
                table: "Wages",
                column: "ManufactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wages_ProfessionId",
                schema: "workers_wages",
                table: "Wages",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ProfessionId",
                schema: "workers_wages",
                table: "Salaries",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufactories_HeadPhotoId",
                schema: "workers_wages",
                table: "Manufactories",
                column: "HeadPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Allowances_WageId",
                schema: "workers_wages",
                table: "Allowances",
                column: "WageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Allowances_Wages_WageId",
                schema: "workers_wages",
                table: "Allowances",
                column: "WageId",
                principalSchema: "workers_wages",
                principalTable: "Wages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manufactories_Files_HeadPhotoId",
                schema: "workers_wages",
                table: "Manufactories",
                column: "HeadPhotoId",
                principalSchema: "workers_wages",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Professions_ProfessionId",
                schema: "workers_wages",
                table: "Salaries",
                column: "ProfessionId",
                principalSchema: "workers_wages",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Manufactories_ManufactoryId",
                schema: "workers_wages",
                table: "Schedules",
                column: "ManufactoryId",
                principalSchema: "workers_wages",
                principalTable: "Manufactories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Manufactories_ManufactoryId",
                schema: "workers_wages",
                table: "Wages",
                column: "ManufactoryId",
                principalSchema: "workers_wages",
                principalTable: "Manufactories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wages_Professions_ProfessionId",
                schema: "workers_wages",
                table: "Wages",
                column: "ProfessionId",
                principalSchema: "workers_wages",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Allowances_Wages_WageId",
                schema: "workers_wages",
                table: "Allowances");

            migrationBuilder.DropForeignKey(
                name: "FK_Manufactories_Files_HeadPhotoId",
                schema: "workers_wages",
                table: "Manufactories");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Professions_ProfessionId",
                schema: "workers_wages",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Manufactories_ManufactoryId",
                schema: "workers_wages",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Manufactories_ManufactoryId",
                schema: "workers_wages",
                table: "Wages");

            migrationBuilder.DropForeignKey(
                name: "FK_Wages_Professions_ProfessionId",
                schema: "workers_wages",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_ManufactoryId",
                schema: "workers_wages",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Wages_ProfessionId",
                schema: "workers_wages",
                table: "Wages");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_ProfessionId",
                schema: "workers_wages",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Manufactories_HeadPhotoId",
                schema: "workers_wages",
                table: "Manufactories");

            migrationBuilder.DropIndex(
                name: "IX_Allowances_WageId",
                schema: "workers_wages",
                table: "Allowances");

            migrationBuilder.RenameColumn(
                name: "HeadPhotoId",
                schema: "workers_wages",
                table: "Manufactories",
                newName: "PhotoId");

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });
        }
    }
}
