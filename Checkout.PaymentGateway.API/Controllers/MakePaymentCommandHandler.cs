using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Checkout.PaymentGateway.API.Controllers;
using Checkout.PaymentGateway.API.Services;
using Checkout.PaymentGateway.API.Domain;
using System;

namespace Checkout.PaymentGateway.API
{
    public class MakePaymentCommandHandler : IRequestHandler<MakePaymentCommand, MakePaymentCommandResponse>
    {
        private readonly IBank bank;
        private readonly IPaymentCache cache;

        public MakePaymentCommandHandler(IBank bank, IPaymentCache cache)
        {
            this.bank = bank;
            this.cache = cache;
        }

        public async Task<MakePaymentCommandResponse> Handle(MakePaymentCommand request, CancellationToken cancellationToken)
        {
            var response = await bank.MakePayment(request.CardDetails, request.Amount, request.Currency);

            this.cache.AddDetails(new PaymentDetails() {
                Amount = request.Amount,
                Currency = request.Currency,
                CardDetails = request.CardDetails,
                Date = DateTime.UtcNow,
                PaymentId = response.Id,
                Status = response.Status
            });

            return new MakePaymentCommandResponse()
            {
                Successful = response.Status == PaymentStatus.Successful,
                PaymentId = response.Id
            };
        }
    }
}
