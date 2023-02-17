using Restaurant.MessageBus;

namespace Restaurant.Services.PaymentAPI.Messages
{
    public class UpdatePaymentResultMessage : BaseMessage
    {
        public Guid OrderId { get; set; }
        public bool Status { get; set; }
    }
}
