namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PTOBalanceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Current",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Initial",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Updated",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LeaveDate",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Current",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Initial",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Updated",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Current",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Initial",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Updated",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeaveDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Current",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Initial",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PTOBalance_Updated",
                table: "Employees");
        }
    }
}
