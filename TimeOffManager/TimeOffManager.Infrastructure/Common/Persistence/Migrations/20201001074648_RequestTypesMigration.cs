namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    
    public partial class RequestTypesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestType_Description",
                table: "RequestDates");

            migrationBuilder.DropColumn(
                name: "RequestType_Name",
                table: "RequestDates");

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "RequestDates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDates_RequestTypeId",
                table: "RequestDates",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDates_RequestTypes_RequestTypeId",
                table: "RequestDates",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDates_RequestTypes_RequestTypeId",
                table: "RequestDates");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropIndex(
                name: "IX_RequestDates_RequestTypeId",
                table: "RequestDates");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "RequestDates");

            migrationBuilder.AddColumn<string>(
                name: "RequestType_Description",
                table: "RequestDates",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestType_Name",
                table: "RequestDates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
