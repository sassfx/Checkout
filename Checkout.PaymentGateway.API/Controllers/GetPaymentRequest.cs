using MediatR;
using System;

namespace Checkout.PaymentGateway.API
{
    public class GetPaymentRequest: IRequest<GetPaymentResponse>
    {
        public Guid PaymentId { get; set; }
    }
}
