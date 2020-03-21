using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreApp.BLL.Interfaces;
using TheatreApp.BLL.DTO;
using TheatreApp.WEB.Models;
using AutoMapper;
using TheatreApp.BLL.Infrastructure;

namespace TheatreApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index(string date, string author, string genre, string searchString)
        {
            
            if(!String.IsNullOrEmpty(searchString))
            {
                IEnumerable<TicketDTO> ticketDtos = orderService.GetTicketsByName(searchString);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
                return View(tickets);
            }
            else
             if (!String.IsNullOrEmpty(genre))
            {
                IEnumerable<TicketDTO> ticketDtos = orderService.GetTicketsByGenre(genre);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
                return View(tickets);
            }
            else
             if (!String.IsNullOrEmpty(author))
            {
                IEnumerable<TicketDTO> ticketDtos = orderService.GetTicketsByAuthor(author);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
                return View(tickets);
            }
            else
             if (!String.IsNullOrEmpty(date))
            {
                IEnumerable<TicketDTO> ticketDtos = orderService.GetTicketsByDate(date);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
                return View(tickets);
            }
            else
            {
               IEnumerable<TicketDTO> ticketDtos = orderService.GetTickets();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TicketDTO, TicketViewModel>()).CreateMapper();
                var tickets = mapper.Map<IEnumerable<TicketDTO>, List<TicketViewModel>>(ticketDtos);
                return View(tickets);
            }
          
           
        }

        public ActionResult MakeOrder(int? id)
        {
            try
            {
                TicketDTO ticket = orderService.GetTicket(id);
                var order = new OrderViewModel { TicketId = ticket.Id };

                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.Id, TicketId = order.TicketId, Bought = order.Bought, Date = order.Date, TicketAuthor = order.TicketAuthor, TicketDate=order.TicketDate, TicketGenre = order.TicketGenre, TicketName = order.TicketName, TicketPrice = order.TicketPrice, TicketType = order.TicketType };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult MyTickets()
        {
            IEnumerable<OrderDTO> orderDtos = orderService.GetOrders();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, OrderViewModel>()).CreateMapper();
            var orders = mapper.Map<IEnumerable<OrderDTO>, List<OrderViewModel>>(orderDtos);
            return View(orders);
        }

        [HttpGet]
        public ActionResult EditOrder(int? id)
        {

            OrderDTO order = orderService.GetOrder(id);
            var order2 = new OrderViewModel { Id = order.Id };

            return View(order2);

        }

        [HttpPost]
        public ActionResult EditOrder(OrderDTO order)
        {
            try
            {
                var orderDto = new OrderDTO { Id = order.Id, TicketId = order.TicketId, Bought = order.Bought };
                orderService.EditOrder(orderDto);
                return Content("< h2 >Ваш заказ успешно куплен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult SearchingByGenre()
        {
            return View();
        }

    }
}