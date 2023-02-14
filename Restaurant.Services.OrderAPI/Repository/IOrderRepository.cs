using Restaurant.Services.OrderAPI.Models;

namespace Restaurant.Services.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader orderHeader);
        Task UpdateOrderPaymentStatus(Guid orderHeaerId, bool paid);
    }
}
