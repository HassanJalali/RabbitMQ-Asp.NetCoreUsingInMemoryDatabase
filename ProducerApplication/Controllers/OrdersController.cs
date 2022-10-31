using Microsoft.AspNetCore.Mvc;
using ProducerApplication.Data;
using ProducerApplication.Models;
using ProducerApplication.Models.Dtos;
using ProducerApplication.Services;

namespace ProducerApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderDbContext _context;
        private readonly IMessageProducer _messageProducer;

        public OrdersController(IOrderDbContext context, IMessageProducer messageProducer)
        {
            _context = context;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderDto)
        {
            Order order = new Order()
            {
                ProductName = orderDto.ProductName,
                Quantity = orderDto.Quantity,
                Price = orderDto.Price,
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            _messageProducer.SendMessage(order);

            return Ok(new { id = order.Id });
        }
    }
}
