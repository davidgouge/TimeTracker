using System;

namespace TimeTracker.Model
{
    public class TimeLog : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public Client Client { get; set; }
        public User User { get; set; }
    }
}