using Microsoft.Data.Entity;

namespace TimeTracker.Model
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext()
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
        public DbSet<TimeLog> TimeLogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}