using Microsoft.EntityFrameworkCore;

namespace CodeFirstExample.Models
{
    public class ActsJune23CodeFirstContext :DbContext
    {
        public ActsJune23CodeFirstContext()
        {
        }

        public ActsJune23CodeFirstContext(DbContextOptions<ActsJune23CodeFirstContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
