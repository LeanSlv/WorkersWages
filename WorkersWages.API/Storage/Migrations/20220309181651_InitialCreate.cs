using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "workers_wages");

            migrationBuilder.CreateTable(
                name: "Allowances",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WageId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allowances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufactories",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    HeadFIO = table.Column<string>(type: "text", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessionId = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ManufactoryId = table.Column<int>(type: "integer", nullable: false),
                    WeekDay = table.Column<int>(type: "integer", nullable: false),
                    WorkingStart = table.Column<TimeSpan>(type: "interval", nullable: true),
                    WorkingEnd = table.Column<TimeSpan>(type: "interval", nullable: true),
                    BreakStart = table.Column<TimeSpan>(type: "interval", nullable: true),
                    BreakEnd = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wages",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkerLastName = table.Column<string>(type: "text", nullable: false),
                    ManufactoryId = table.Column<int>(type: "integer", nullable: false),
                    ProfessionId = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wages", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "workers_wages",
                table: "Manufactories",
                columns: new[] { "Id", "Created", "HeadFIO", "Name", "Number", "PhotoId", "Updated" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), "Пупкин Арсений Викторович", "Цех #1", "1", null, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.InsertData(
                schema: "workers_wages",
                table: "Professions",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), "Слесарь", new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 2, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), "Токарь", new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 3, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), "Сварщик", new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                schema: "workers_wages",
                table: "Salaries",
                columns: new[] { "Id", "Amount", "Created", "ProfessionId", "Rank", "Updated" },
                values: new object[,]
                {
                    { 7, 300.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 3, 2, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 6, 200.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 3, 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 4, 150.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 2, 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 5, 200.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 2, 2, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 2, 200.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, 2, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 1, 100.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) },
                    { 3, 250.0, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, 3, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                schema: "workers_wages",
                table: "Schedules",
                columns: new[] { "Id", "BreakEnd", "BreakStart", "Created", "ManufactoryId", "Updated", "WeekDay", "WorkingEnd", "WorkingStart" },
                values: new object[,]
                {
                    { 6, null, null, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 5, null, null },
                    { 1, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 0, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 2, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 2, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 4, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 3, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 5, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0), new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 4, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 7, null, null, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 1, new DateTimeOffset(new DateTime(2022, 3, 9, 22, 16, 32, 52, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 4, 0, 0, 0)), 6, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactories_Number",
                schema: "workers_wages",
                table: "Manufactories",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_Name",
                schema: "workers_wages",
                table: "Professions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ManufactoryId_WeekDay",
                schema: "workers_wages",
                table: "Schedules",
                columns: new[] { "ManufactoryId", "WeekDay" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wages_WorkerLastName",
                schema: "workers_wages",
                table: "Wages",
                column: "WorkerLastName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allowances",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Manufactories",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Professions",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Salaries",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Schedules",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "Wages",
                schema: "workers_wages");
        }
    }
}
