namespace TimeOffManager.Infrastructure.Common.Persistence.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RequestModelsUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_Options_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_Options_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes");

            migrationBuilder.DropColumn(
                name: "Options_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Till",
                table: "Requests");

            migrationBuilder.RenameTable(
                name: "RequestTypes",
                newName: "RequestDates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RequestDates",
                newName: "RequestType_Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "RequestDates",
                newName: "RequestType_Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeRange_End",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeRange_Start",
                table: "Requests",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestType_Name",
                table: "RequestDates",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RequestType_Description",
                table: "RequestDates",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RequestDates",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hours",
                table: "RequestDates",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "RequestDates",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestDates",
                table: "RequestDates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "NationalHolidays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalHolidays", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDates_RequestId",
                table: "RequestDates",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDates_Requests_RequestId",
                table: "RequestDates",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDates_Requests_RequestId",
                table: "RequestDates");

            migrationBuilder.DropTable(
                name: "NationalHolidays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestDates",
                table: "RequestDates");

            migrationBuilder.DropIndex(
                name: "IX_RequestDates_RequestId",
                table: "RequestDates");

            migrationBuilder.DropColumn(
                name: "DateTimeRange_End",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DateTimeRange_Start",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RequestDates");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "RequestDates");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "RequestDates");

            migrationBuilder.RenameTable(
                name: "RequestDates",
                newName: "RequestTypes");

            migrationBuilder.RenameColumn(
                name: "RequestType_Name",
                table: "RequestTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RequestType_Description",
                table: "RequestTypes",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Options_RequestTypeId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hours",
                table: "Requests",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "Till",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RequestTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RequestTypes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestTypes",
                table: "RequestTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_Options_RequestTypeId",
                table: "Requests",
                column: "Options_RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_Options_RequestTypeId",
                table: "Requests",
                column: "Options_RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
