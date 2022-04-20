using Microsoft.EntityFrameworkCore;

namespace StudentAdmission.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<StudentAddmission> StudentAddmissions { get; set; }

    }
}
