using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDapi.Migrations
{
    public partial class SP_SelectEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE SelectEmployee
            @Id int


            AS
            BEGIN
                SET NOCOUNT ON;
                select * from Employees WHERE id = @Id
            END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
