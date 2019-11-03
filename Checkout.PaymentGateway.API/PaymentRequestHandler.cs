using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API
{
    public class PaymentRequestHandler : IRequestHandler<PaymentRequest, PaymentDetails>
    {
        public async Task<PaymentDetails> Handle(PaymentRequest request, CancellationToken cancellationToken)
        {
            return new PaymentDetails() { Successful = true };
        }
    }
}
