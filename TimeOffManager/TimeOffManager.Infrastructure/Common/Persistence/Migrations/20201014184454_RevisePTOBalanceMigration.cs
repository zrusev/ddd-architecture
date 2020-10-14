namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RevisePTOBalanceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PTOBalance_Updated",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Current",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Initial",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Updated",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PTOBalance_Updated",
                table: "Employees",
                type: "int",
                nullable: true);
        }
    }
}
