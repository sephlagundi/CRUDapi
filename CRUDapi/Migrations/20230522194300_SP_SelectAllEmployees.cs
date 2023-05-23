using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDapi.Migrations
{
    public partial class SP_SelectAllEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE SelectAllEmployees
            AS
            BEGIN
                select * from Employees;
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
