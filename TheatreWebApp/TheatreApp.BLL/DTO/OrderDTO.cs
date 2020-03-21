using System;
using System.Collections.Generic;
using System.Text;

namespace TheatreApp.BLL.DTO
{
    public class OrderDTO
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
