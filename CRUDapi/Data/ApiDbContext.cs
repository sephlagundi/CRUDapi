using CRUDapi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDapi.Data
{
    public class ApiDbContext : DbContext
    {
        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=RestApiDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }*/


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }


        public virtual DbSet<Employee> Employees { get; set; }





    }
}
