using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Domain
{
    public class PaymentDetails
    {
        public Guid PaymentId { get; set; }

        public PaymentStatus Status { get; set; }

        public CardDetails CardDetails { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } // In a real system we'd probably not be sending currencies around as strings

        public DateTime Date { get; set; }
    }
}
