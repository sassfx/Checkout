using System;

namespace Checkout.PaymentGateway.API
{
    public class BankResponse
    {
        public Guid Id { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
