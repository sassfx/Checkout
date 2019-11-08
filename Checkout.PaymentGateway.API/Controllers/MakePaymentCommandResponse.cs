using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Controllers
{
    public class MakePaymentCommandResponse
    {
        public Guid? PaymentId { get; set; }

        public bool Successful { get; set; }
    }
}
