namespace ProvaPub.Services.Orders
{
    public class CreditCardPayment : IPaymentMethod
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            // Faz pagamento com cartão de crédito...
        }
    }

}
