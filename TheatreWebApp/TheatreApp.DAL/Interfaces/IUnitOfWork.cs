using System;
using System.Collections.Generic;
using System.Text;
using TheatreApp.DAL.Entities;

namespace TheatreApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Ticket> Tickets { get; }
        IRepository<Order> Orders { get;  }
        void Save();
    }
}
