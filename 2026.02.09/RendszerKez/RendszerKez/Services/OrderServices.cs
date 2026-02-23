
    using System;
    using Microsoft.EntityFrameworkCore;
    using RendszerKez.Dtos;
    using RendszerKez.Models;
    using RendszerKez.Services.Interfaces;

    public class OrderService : IOrderService
    {
        private readonly RendszerkezContext _context;

        public OrderService(RendszerkezContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(int userId, CreateOrderDto dto)
        {
            var order = new Order
            {
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UserId = userId
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderSummaryDto>> GetMyOrdersAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId).Select(o => new OrderSummaryDto
                {
                    Username = o.User.Username,
                    ProductName = o.ProductName,
                    Quantity = o.Quantity
                })
                .ToListAsync();
        }

        public async Task<List<OrderSummaryDto>> GetSummaryAsync()
        {
            return await _context.Orders
                .Include(o => o.User).Select(o => new OrderSummaryDto
                {
                    Username = o.User.Username,
                    ProductName = o.ProductName,
                    Quantity = o.Quantity
                })
                .ToListAsync();
        }
    }
