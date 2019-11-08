using Checkout.PaymentGateway.API.Domain;
using Checkout.PaymentGateway.API.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Tests
{
    [TestFixture]
    public class GetPaymentRequestHandlerTest
    {
        [Test]
        public async Task Handle_GetsPaymentFromCacheAndMasksCardNumber()
        {
            var paymentId = Guid.NewGuid();

            var cardDetails = new CardDetails()
            {
                Cvv = "123",
                Expiry = "08/09",
                Number = "1234567890"
            };

            var paymentDetails = new PaymentDetails()
            {
                Amount = 10m,
                Currency = "GBP",
                Date = DateTime.UtcNow,
                PaymentId = paymentId,
                Status = PaymentStatus.Successful,
                CardDetails = cardDetails
            };
            var paymentCache = new Mock<IPaymentCache>();
            paymentCache.Setup(x => x.GetPaymentDetails(It.Is<Guid>(x => x == paymentId))).Returns(paymentDetails);
            var requestHandler = new GetPaymentRequestHandler(paymentCache.Object);

            var result = await requestHandler.Handle(new GetPaymentRequest() { PaymentId = paymentId }, new System.Threading.CancellationToken());

            result.PaymentDetails.Amount.Should().Be(paymentDetails.Amount);
            result.PaymentDetails.Currency.Should().Be(paymentDetails.Currency);
            result.PaymentDetails.Date.Should().Be(paymentDetails.Date);
            result.PaymentDetails.PaymentId.Should().Be(paymentId);
            result.PaymentDetails.Status.Should().Be(paymentDetails.Status);
            result.PaymentDetails.CardDetails.Cvv.Should().Be(cardDetails.Cvv);
            result.PaymentDetails.CardDetails.Expiry.Should().Be(cardDetails.Expiry);
            result.PaymentDetails.CardDetails.Number.Should().Be("xxxxxx7890");
        }
    }
}
