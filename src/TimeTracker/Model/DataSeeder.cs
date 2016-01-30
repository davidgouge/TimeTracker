using System.Linq;

namespace TimeTracker.Model
{
    public class DataSeeder
    {
        private readonly TimeTrackerContext _context;

        public DataSeeder(TimeTrackerContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Clients.Any())
            {
                _context.Clients.Add(new Client {Name = "Zoom"});
                _context.SaveChanges();
            }

            if (!_context.Users.Any())
            {
                _context.Users.Add(new User {Name = "Dave"});
                _context.SaveChanges();
            }
        }
    }
}