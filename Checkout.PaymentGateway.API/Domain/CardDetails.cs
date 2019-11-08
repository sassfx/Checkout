namespace Checkout.PaymentGateway.API
{
    // Ideally our domain objects would be immutable and we'd have some separation between them and a DTO layer
    public class CardDetails
    {
        public string Number { get; set; }

        public string Expiry { get; set; }

        public string Cvv { get; set; }
    }
}