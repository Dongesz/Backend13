using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RendszerKez.Dtos;
using RendszerKez.Services.Interfaces;

namespace RendszerKez.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User not found");

            var userId = user.Id;

            await _orderService.CreateOrderAsync(userId, dto);
            return Ok("Order created successfully");
        }

        [Authorize]
        [HttpGet("my")]
        public async Task<IActionResult> MyOrders()
        {
            var user = await _userService.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User not found");

            var result = await _orderService.GetMyOrdersAsync(user.Id);
            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            var result = await _orderService.GetSummaryAsync();
            return Ok(result);
        }
    }
}