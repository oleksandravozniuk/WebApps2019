using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreApp.WEB.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }
}