using System.Threading.Tasks;

namespace Checkout.PaymentGateway.API.Services
{
    public interface IBank
    {
        Task<BankResponse> MakePayment(CardDetails details, decimal amount, string currency);
    }
}
