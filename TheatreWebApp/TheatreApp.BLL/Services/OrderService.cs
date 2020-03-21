using System;
using System.Collections.Generic;
using System.Text;
using TheatreApp.BLL.DTO;
using TheatreApp.DAL.Entities;
using TheatreApp.DAL.Interfaces;
using TheatreApp.BLL.Infrastructure;
using TheatreApp.BLL.Interfaces;
using AutoMapper;

namespace TheatreApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(OrderDTO orderDto)
        {
            Ticket ticket = Database.Tickets.Get(orderDto.TicketId);

            // валидация
            if (ticket == null)
                throw new ValidationException("Билет не найден", "");
            
            Order order = new Order
            {
                Date = DateTime.Now,
                TicketId = ticket.Id,
                Bought = orderDto.Bought
            };
            Database.Orders.Create(order);
            Database.Tickets.Get(orderDto.TicketId).Number--;
            Database.Save();
        }

        public IEnumerable<TicketDTO> GetTickets()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.GetAll());
        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id билета", "");
            var ticket = Database.Tickets.Get(id.Value);
            if (ticket == null)
                throw new ValidationException("Билет не найден", "");

            return new TicketDTO { Author = ticket.Author , Id = ticket.Id, Name = ticket.Name, Price = ticket.Price, Genre=ticket.Genre, Type=ticket.Type, Number=ticket.Number };
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }

        public OrderDTO GetOrder(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id билета", "");
            var order = Database.Orders.Get(id.Value);
            if (order == null)
                throw new ValidationException("Билет не найден", "");

            return new OrderDTO {Id = order.Id, Bought = order.Bought, Date = order.Date};
        }

        public void EditOrder(OrderDTO orderDTO)
        {
            var order = Database.Orders.Get(orderDTO.Id);
            Database.Orders.Get(orderDTO.Id).Bought = true; 
           // Database.Orders.Update(order);
            Database.Save();
        }

        public IEnumerable<TicketDTO> GetTicketsByGenre(string genre)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.Find(p => p.Genre == genre));
        }

        public IEnumerable<TicketDTO> GetTicketsByName(string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.Find(p => p.Name == name));
        }

        public IEnumerable<TicketDTO> GetTicketsByAuthor(string author)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.Find(p => p.Author == author));
        }

        public IEnumerable<TicketDTO> GetTicketsByDate(string date)
        {
            DateTime dt = DateTime.Parse(date); 
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Ticket, TicketDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.Tickets.Find(p => p.Date.Date == dt));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
