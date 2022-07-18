using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mc2.CrudTest.Presentation.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "customer");

            migrationBuilder.CreateSequence(
                name: "customerseq",
                schema: "customer",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdentityGuid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_DateOfBirth_Firstname_Lastname",
                schema: "customer",
                table: "customers",
                columns: new[] { "DateOfBirth", "Firstname", "Lastname" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_Email",
                schema: "customer",
                table: "customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_IdentityGuid",
                schema: "customer",
                table: "customers",
                column: "IdentityGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers",
                schema: "customer");

            migrationBuilder.DropSequence(
                name: "customerseq",
                schema: "customer");
        }
    }
}
