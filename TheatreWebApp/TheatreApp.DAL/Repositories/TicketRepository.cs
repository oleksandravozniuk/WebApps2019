using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheatreApp.DAL.Entities;
using TheatreApp.DAL.EF;
using TheatreApp.DAL.Interfaces;
using System.Data.Entity;

namespace TheatreApp.DAL.Repositories
{
  
        public class TicketRepository : IRepository<Ticket>
        {
            private TheatreContext db;

            public TicketRepository(TheatreContext context)
            {
                this.db = context;
            }

            public IEnumerable<Ticket> GetAll()
            {
                return db.Tickets;
            }

            public Ticket Get(int id)
            {
                return db.Tickets.Find(id);
            }

            public void Create(Ticket ticket)
            {
                db.Tickets.Add(ticket);
            }

            public void Update(Ticket ticket)
            {
                db.Entry(ticket).State = EntityState.Modified;
            }

            public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
            {
                return db.Tickets.Where(predicate).ToList();
            }

            public void Delete(int id)
            {
                Ticket ticket = db.Tickets.Find(id);
                if (ticket != null)
                    db.Tickets.Remove(ticket);
            }
        }
  
}
