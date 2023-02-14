using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using Restaurant.Services.OrderAPI.Messages;
using Restaurant.Services.OrderAPI.Models;
using Restaurant.Services.OrderAPI.Repository;
using System.Text;

namespace Restaurant.Services.OrderAPI.Messaging
{
    public class AzureServiceBusConsumer
    {
        private readonly OrderRepository _orderRepository;

        public AzureServiceBusConsumer(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        private async Task OnCheckOutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

            OrderHeader orderHeader = new()
            {
                UserId = checkoutHeaderDto.UserId,
                FirstName = checkoutHeaderDto.FirstName,
                LastName = checkoutHeaderDto.LastName,
                OrderDetails = new List<OrderDetails>(),
                CardNumber = checkoutHeaderDto.CardNumber,
                CouponCode = checkoutHeaderDto.CouponCode,
                CVV = checkoutHeaderDto.CVV,
                DiscountTotal = checkoutHeaderDto.DiscountTotal,
                Email = checkoutHeaderDto.Email,
                ExpiryMonthYear = checkoutHeaderDto.ExpiryMonthYear,
                OrderTime = DateTime.Now,
                OrderTotal = checkoutHeaderDto.OrderTotal,
                PaymentStatus = false,
                Phone = checkoutHeaderDto.Phone,
                PickupDateTime = checkoutHeaderDto.PickupDateTime
            };

            foreach (var detailsList in checkoutHeaderDto.CartDetails)
            {
                OrderDetails orderDetails = new()
                {
                    ProductId = detailsList.ProductId,
                    ProductName = detailsList.Product.Name,
                    Price = detailsList.Product.Price,
                    Count = detailsList.Count
                };
                orderHeader.CartTotalItems += detailsList.Count;
                orderHeader.OrderDetails.Add(orderDetails);
            }

            await _orderRepository.AddOrder(orderHeader);
        }
    }
}
