using Checkout.PaymentGateway.API.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Tests
{
    public class PaymentsControllerTest
    {
        [Test]
        public async Task PaymentDetailsCallsThroughToMediator()
        {
            const string paymentId = "test-payment-id";
            var mediator = new Mock<IMediator>();
            var sut = new PaymentsController(mediator.Object);

            await sut.PaymentDetails(paymentId);

            mediator.Verify(x => x.Send(It.Is<PaymentRequest>(y => y.PaymentId == paymentId), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}