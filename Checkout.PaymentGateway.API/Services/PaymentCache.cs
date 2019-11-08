using Checkout.PaymentGateway.API.Domain;
using System;
using System.Collections.Generic;

namespace Checkout.PaymentGateway.API.Services
{
    // We'd have some sort of way to persist and retrieve these in the real app, but for now we'll just store in memory
    public class PaymentCache : IPaymentCache
    {
        private Dictionary<Guid, PaymentDetails> cachedDetails = new Dictionary<Guid, PaymentDetails>();

        public PaymentDetails GetPaymentDetails(Guid paymentId)
        {
            PaymentDetails details;
            cachedDetails.TryGetValue(paymentId, out details);
            return details;
        }

        public void AddDetails(PaymentDetails details)
        {
            cachedDetails.Add(details.PaymentId, details);
        }
    }
}
