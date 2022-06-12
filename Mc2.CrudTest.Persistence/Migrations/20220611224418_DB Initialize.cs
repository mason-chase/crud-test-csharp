using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Persistence.Migrations
{
    public partial class DBInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    BankAccountNumber = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BankAccountNumber", "DateOfBirth", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "6037-9917-0000-0000", new DateTime(2022, 3, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), "taherfatta11@gmail.com", "taher 1", "fattahi 1", 989115467885m },
                    { 2, "6037-9917-0000-0000", new DateTime(2022, 9, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), "taherfatta111@gmail.com", "taher 2", "fattahi 2", 989115467886m },
                    { 3, "6037-9917-0000-0000", new DateTime(2022, 8, 17, 6, 0, 1, 0, DateTimeKind.Unspecified), "taherfatta1111@gmail.com", "taher 3", "fattahi 3", 989115467887m },
                    { 4, "6037-9917-0000-0000", new DateTime(2022, 1, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), "taherfatta11111@gmail.com", "taher 4", "fattahi 4", 989115467888m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email_FirstName_LastName_DateOfBirth",
                table: "Customers",
                columns: new[] { "Email", "FirstName", "LastName", "DateOfBirth" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
