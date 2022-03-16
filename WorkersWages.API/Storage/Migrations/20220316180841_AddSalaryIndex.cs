using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersWages.API.Storage.Migrations
{
    public partial class AddSalaryIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salaries_ProfessionId",
                schema: "workers_wages",
                table: "Salaries");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ProfessionId_Rank",
                schema: "workers_wages",
                table: "Salaries",
                columns: new[] { "ProfessionId", "Rank" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salaries_ProfessionId_Rank",
                schema: "workers_wages",
                table: "Salaries");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_ProfessionId",
                schema: "workers_wages",
                table: "Salaries",
                column: "ProfessionId");
        }
    }
}
