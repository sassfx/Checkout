using MediatR;

namespace Checkout.PaymentGateway.API
{
    public class PaymentRequest: IRequest<PaymentDetails>
    {
        public string PaymentId { get; set; }
    }
}
