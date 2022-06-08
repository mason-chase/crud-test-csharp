using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Domain.Migrations;

public partial class InitialCommit : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Firstname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                Lastname = table.Column<string>(type: "nvarchar(450)", nullable: false),
                DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                BankAccountNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Customers", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Customers_DateOfBirth",
            table: "Customers",
            column: "DateOfBirth",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Customers_Email",
            table: "Customers",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Customers_Firstname",
            table: "Customers",
            column: "Firstname",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Customers_Lastname",
            table: "Customers",
            column: "Lastname",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Customers");
    }
}
