using System;

namespace TimeTracker.Model
{
    public class Invoice : Entity
    {
        public Client Client { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Paid { get; set; }
    }
}