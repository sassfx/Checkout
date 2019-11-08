using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentsController
    {
        private readonly IMediator mediator;

        public PaymentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<GetPaymentResponse> GetPaymentDetails([FromRoute]Guid paymentId)
        {
            var result = await mediator.Send(new GetPaymentRequest { PaymentId = paymentId });
            return result;
        }

        [HttpPost]
        [Route("")]
        public async Task<MakePaymentCommandResponse> MakePayment([FromBody]MakePaymentCommand makePaymentCommand)
        {
            var result = await mediator.Send(makePaymentCommand);
            return result;
        }
    }
}
