using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class AddAspNetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "workers_wages",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "workers_wages",
                newName: "AspNetUsers",
                newSchema: "workers_wages");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "workers_wages",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "workers_wages",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "workers_wages",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "workers_wages",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "workers_wages",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "workers_wages",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "workers_wages",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "workers_wages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "workers_wages",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "workers_wages",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Manufactories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "workers_wages",
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 14, 20, 12, 21, 498, DateTimeKind.Unspecified).AddTicks(9486), new TimeSpan(0, 4, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "workers_wages",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "workers_wages",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "workers_wages",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "workers_wages",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "workers_wages",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "workers_wages",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "workers_wages",
                table: "AspNetUserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "workers_wages");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "workers_wages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                schema: "workers_wages",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "workers_wages",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "workers_wages",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "workers_wages",
                newName: "Users",
                newSchema: "workers_wages");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "workers_wages",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                schema: "workers_wages",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                schema: "workers_wages",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "workers_wages",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "workers_wages",
                table: "Users",
                column: "Id");

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
        }
    }
}
