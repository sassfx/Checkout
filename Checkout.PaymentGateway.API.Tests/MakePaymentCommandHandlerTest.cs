using Checkout.PaymentGateway.API.Domain;
using Checkout.PaymentGateway.API.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Tests
{
    [TestFixture]
    public class MakePaymentCommandHandlerTest
    {
        [Test]
        public async Task Handle_CallsBankApiAndReturnsIdAndStatus()
        {
            var paymentId = Guid.NewGuid();

            var cardDetails = new CardDetails()
            {
                Cvv = "123",
                Expiry = "08/09",
                Number = "1234567890"
            };
            var amount = 10m;
            var currency = "GBP";

            var paymentCache = new Mock<IPaymentCache>();
            var bank = new Mock<IBank>();
            bank.Setup(x => x.MakePayment(It.Is<CardDetails>(x => x == cardDetails), It.Is<decimal>(x => x == amount), It.Is<string>(x => x == currency)))
                .ReturnsAsync(new BankResponse() { Id = paymentId, Status = PaymentStatus.Successful });
            var commandHandler = new MakePaymentCommandHandler(bank.Object, paymentCache.Object);

            var result = await commandHandler.Handle(new MakePaymentCommand() { CardDetails = cardDetails, Amount = amount, Currency = currency } , new System.Threading.CancellationToken());

            paymentCache.Verify(x => x.AddDetails(It.Is<PaymentDetails>(y => y.CardDetails == cardDetails && y.Amount == amount && y.Currency == currency && y.PaymentId == paymentId && y.Status == PaymentStatus.Successful)));
            result.PaymentId.Should().Be(paymentId);
            result.Successful.Should().Be(true);
        }
    }
}
