using System;
using System.Collections.Generic;
using System.Text;
using TheatreApp.DAL.Entities;
using TheatreApp.DAL.EF;
using TheatreApp.DAL.Interfaces;

namespace TheatreApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private TheatreContext db;
        private TicketRepository ticketRepository;
        private OrderRepository orderRepository;


        public EFUnitOfWork(string connectionString)
        {
            db = new TheatreContext(connectionString);
        }
        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository(db);
                return ticketRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

 

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
