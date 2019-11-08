using Checkout.PaymentGateway.API.Domain;
using System;

namespace Checkout.PaymentGateway.API
{
    public class GetPaymentResponse
    {
        public PaymentDetails PaymentDetails { get; set; }
    }
}