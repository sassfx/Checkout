using Checkout.PaymentGateway.API.Controllers;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Tests
{
    [TestFixture]
    public class PaymentsControllerTest
    {
        [Test]
        public async Task GetPaymentDetailsCallsThroughToMediator()
        {
            Guid paymentId = Guid.NewGuid();
            var mediator = new Mock<IMediator>();
            var sut = new PaymentsController(mediator.Object);

            await sut.GetPaymentDetails(paymentId);

            mediator.Verify(x => x.Send(It.Is<GetPaymentRequest>(y => y.PaymentId == paymentId), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task MakePaymentRequestCallsThroughToMediator()
        {
            MakePaymentCommand command = new MakePaymentCommand();
            var mediator = new Mock<IMediator>();
            var sut = new PaymentsController(mediator.Object);

            await sut.MakePayment(command);

            mediator.Verify(x => x.Send(It.Is<MakePaymentCommand>(y => y == command), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}