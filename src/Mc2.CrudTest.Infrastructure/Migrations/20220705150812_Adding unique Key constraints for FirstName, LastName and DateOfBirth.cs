using Microsoft.EntityFrameworkCore.Migrations;

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    public partial class AddinguniqueKeyconstraintsforFirstNameLastNameandDateOfBirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName_Lastname_DateOfBirth",
                table: "Customers",
                columns: new[] { "FirstName", "Lastname", "DateOfBirth" },
                unique: true,
                filter: "[FirstName] IS NOT NULL AND [Lastname] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_FirstName_Lastname_DateOfBirth",
                table: "Customers");
        }
    }
}
