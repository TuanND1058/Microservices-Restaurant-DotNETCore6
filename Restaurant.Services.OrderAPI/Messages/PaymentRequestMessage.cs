﻿using Restaurant.MessageBus;

namespace Restaurant.Services.OrderAPI.Messages
{
    public class PaymentRequestMessage : BaseMessage
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public double OrderTotal { get; set; }
    }
}