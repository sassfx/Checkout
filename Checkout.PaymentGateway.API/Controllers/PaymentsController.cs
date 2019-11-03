using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController
    {
        private readonly IMediator mediator;

        public PaymentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<PaymentDetails> PaymentDetails(string paymentId)
        {
            var result = await mediator.Send(new PaymentRequest { PaymentId = paymentId });
            return result;
        }
    }
}
