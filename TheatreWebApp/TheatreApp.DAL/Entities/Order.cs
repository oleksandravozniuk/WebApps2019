using System;
using System.Collections.Generic;
using System.Text;

namespace TheatreApp.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public bool Bought { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime Date { get; set; }
    }
}
