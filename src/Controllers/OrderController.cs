using EventSourcingAndOutbox.Models.Request;
using EventSourcingAndOutbox.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingAndOutbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly OrderService _orderService;
        public OrderController(ILogger<OrderController> logger, OrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpGet("GetOrder")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_orderService.GetById(id));
        }

        [HttpPost("CreateOrder")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult CreateOrder([FromBody] CreateOrderRequest request)
        {
            Guid id = Guid.NewGuid();
            _orderService.CreateOrder(id, request.Product, request.Quantity);
            return Ok(new { Message = "Order Created", Status = true, Id = id });
        }
    }
}
