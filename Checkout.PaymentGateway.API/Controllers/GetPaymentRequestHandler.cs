using Checkout.PaymentGateway.API.Domain;
using Checkout.PaymentGateway.API.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API
{
    public class GetPaymentRequestHandler : IRequestHandler<GetPaymentRequest, GetPaymentResponse>
    {
        private readonly IPaymentCache cache;

        public GetPaymentRequestHandler(IPaymentCache cache)
        {
            this.cache = cache;
        }
        public async Task<GetPaymentResponse> Handle(GetPaymentRequest request, CancellationToken cancellationToken)
        {
            var details = cache.GetPaymentDetails(request.PaymentId);

            if (details != null)
            {
                var paymentDetails = new PaymentDetails()
                {
                    PaymentId = details.PaymentId,
                    Amount = details.Amount,
                    Currency = details.Currency,
                    Date = details.Date,
                    Status = details.Status,
                    CardDetails = MaskCardDetails(details.CardDetails),
                };

                return new GetPaymentResponse() { PaymentDetails = paymentDetails };
            }

            return new GetPaymentResponse();
        }

        // Could probably move this into a class of its own as I imagine it might be something we can reuse.
        private CardDetails MaskCardDetails(CardDetails cardDetails)
        {
            var maskedNumber = $"{new string('x', cardDetails.Number.Length - 4)}{cardDetails.Number.Substring(cardDetails.Number.Length - 4)}";

            return new CardDetails()
            {
                Cvv = cardDetails.Cvv,
                Expiry = cardDetails.Expiry,
                Number = maskedNumber
            };
        }
    }
}
