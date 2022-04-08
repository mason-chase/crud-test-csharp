using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Database.Migrations
{
    public partial class CrudTst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customer");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 300, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Customer",
                table: "Customer",
                columns: new[] { "Id", "BankAccountNumber", "PhoneNumber", "Email", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1L, "6037997435104287", "0913906453", "karimy.ehsan@gmail.com", new DateTime(1987, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ehsan", "karimi" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Email",
                schema: "Customer",
                table: "Customer",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_FirstName_LastName_DateOfBirth",
                schema: "Customer",
                table: "Customer",
                columns: new[] { "FirstName", "LastName", "DateOfBirth" },
                unique: true,
                filter: "[FirstName] IS NOT NULL AND [LastName] IS NOT NULL AND [DateOfBirth] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Customer");
        }
    }
}
