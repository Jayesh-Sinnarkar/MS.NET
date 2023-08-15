using Microsoft.EntityFrameworkCore;

namespace CodeFirstEMS.Models
{
    public class EMSContext: DbContext
    {
        public EMSContext() { }
        public EMSContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departmet> Departmets { get; set;}


    }
}
