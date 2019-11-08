using System;
using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Services
{
    // Assuming that the actual implementation of this will handle the communication with the bank 
    public class BankMockImplementation : IBank
    {
        public async Task<BankResponse> MakePayment(CardDetails details, decimal amount, string currency)
        {
            return new BankResponse()
            {
                Id = Guid.NewGuid(),
                Status = PaymentStatus.Successful
            };
        }
    }
}
