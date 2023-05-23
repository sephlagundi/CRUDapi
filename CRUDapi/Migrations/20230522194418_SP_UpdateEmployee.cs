using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDapi.Migrations
{
    public partial class SP_UpdateEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var sp = @"CREATE OR ALTER PROCEDURE UpdateEmployee
            @Id int, @Name varchar(50)


            AS
            BEGIN
                UPDATE Employees SET Name = @Name WHERE id =@Id
            END";
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
