using System;
using Checkout.PaymentGateway.API.Domain;

namespace Checkout.PaymentGateway.API.Services
{
    public interface IPaymentCache
    {
        void AddDetails(PaymentDetails details);
        PaymentDetails GetPaymentDetails(Guid paymentId);
    }
}