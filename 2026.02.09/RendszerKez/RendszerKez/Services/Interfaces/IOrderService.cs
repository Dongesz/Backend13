using RendszerKez.Dtos;

namespace RendszerKez.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int userId, CreateOrderDto dto);
        Task<List<OrderSummaryDto>> GetMyOrdersAsync(int userId);
        Task<List<OrderSummaryDto>> GetSummaryAsync();
    }
}
