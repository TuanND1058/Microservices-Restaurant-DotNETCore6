﻿namespace Restaurant.Services.OrderAPI.Messages
{
    public class UpdatePaymentResultMessage
    {
        public Guid OrderId { get; set; }
        public bool Status { get; set; }
    }
}