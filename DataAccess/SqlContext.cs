using WebService.Models;
using Microsoft.EntityFrameworkCore;



namespace WebService.DataAccess
{
    public class SqlContext : DbContext
    {
        public DbSet<catalumno> catalumno { get; set; }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
