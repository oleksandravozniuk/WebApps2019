using System;
using System.Collections.Generic;
using System.Text;
using TheatreApp.BLL.DTO;

namespace TheatreApp.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        TicketDTO GetTicket(int? id);
        IEnumerable<TicketDTO> GetTickets();
        IEnumerable<TicketDTO> GetTicketsByGenre(string genre);
        IEnumerable<TicketDTO> GetTicketsByName(string name);
        IEnumerable<TicketDTO> GetTicketsByAuthor(string author);
        IEnumerable<TicketDTO> GetTicketsByDate(string date);

        void EditOrder(OrderDTO orderDto);
        OrderDTO GetOrder(int? id);
        IEnumerable<OrderDTO> GetOrders();
        void Dispose();
    }
}
