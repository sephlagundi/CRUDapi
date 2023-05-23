using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDapi.Migrations
{
    public partial class SP_CreateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE OR ALTER PROCEDURE CreateEmployee
            @Name VARCHAR(50)
            AS
            BEGIN
                 INSERT INTO Employees (Name)
                 VALUES (@Name);
            END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
