using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDapi.Migrations
{
    public partial class SP_DeleteEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE DeleteEmployee
            @Id int
            AS
            BEGIN
                DELETE FROM Employees WHERE id = @Id
            END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
