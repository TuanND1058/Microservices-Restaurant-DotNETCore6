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
        private readonly IConfiguration _configuration;

        private ServiceBusProcessor checkOutProcessor;

        private readonly string serviceBusConnectionString;
        private readonly string checkoutMessageTopic;
        private readonly string subscriptionCheckOut;

        public AzureServiceBusConsumer(OrderRepository orderRepository, IConfiguration configuration)
        {
            _orderRepository = orderRepository;
            _configuration = configuration;

            serviceBusConnectionString = _configuration.GetValue<string>("ServiceBusConnectionString");
            checkoutMessageTopic = _configuration.GetValue<string>("CheckoutMessageTopic");
            subscriptionCheckOut = _configuration.GetValue<string>("SubscriptionCheckOut");

            var client = new ServiceBusClient(serviceBusConnectionString);

            checkOutProcessor = client.CreateProcessor(checkoutMessageTopic, subscriptionCheckOut);
        }

        public async void Start()
        {
            checkOutProcessor.ProcessMessageAsync += OnCheckOutMessageReceived;
            checkOutProcessor.ProcessErrorAsync += ErrorHandler;
            await checkOutProcessor.StartProcessingAsync();
        }

        public async void Stop()
        {
            await checkOutProcessor.StopProcessingAsync();
            await checkOutProcessor.DisposeAsync();
        }

        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
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
