namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RequesterUserIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Requesters",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Requesters");
        }
    }
}
