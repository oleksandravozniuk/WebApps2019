using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreApp.WEB.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public bool Bought { get; set; }
        public int TicketId { get; set; }
        public string TicketName { get; set; }
        public string TicketAuthor { get; set; }
        public string TicketGenre { get; set; }
        public string TicketType { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime TicketDate { get; set; }
        public DateTime Date { get; set; }
    }
}