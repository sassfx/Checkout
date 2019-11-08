using Checkout.PaymentGateway.API.Controllers;
using MediatR;

namespace Checkout.PaymentGateway.API
{
    public class MakePaymentCommand : IRequest<MakePaymentCommandResponse>
    {
        public CardDetails CardDetails { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}