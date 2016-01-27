using Microsoft.Data.Entity;

namespace TimeTracker.Model
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Config["Data:ConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}