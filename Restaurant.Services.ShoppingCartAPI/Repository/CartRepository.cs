using Restaurant.Services.ShoppingCartAPI.Models.Dto;

namespace Restaurant.Services.ShoppingCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        public Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> CreateUpdateCart(CartDto cartDto)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCart(Guid cartDetailsId)
        {
            throw new NotImplementedException();
        }
    }
}
