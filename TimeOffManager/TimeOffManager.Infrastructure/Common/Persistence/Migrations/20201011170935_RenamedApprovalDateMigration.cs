namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenamedApprovalDateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "Requests");

            migrationBuilder.AddColumn<DateTime>(
                name: "RevisedOn",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RevisedOn",
                table: "Requests");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "Requests",
                type: "datetime2",
                nullable: true);
        }
    }
}
