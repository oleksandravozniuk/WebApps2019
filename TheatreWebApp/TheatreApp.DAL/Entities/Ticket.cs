using System;
using System.Collections.Generic;
using System.Text;

namespace TheatreApp.DAL.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
