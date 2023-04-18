namespace ProvaPub.Services.Orders
{
    public class PaypalPayment : IPaymentMethod
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            // Faz pagamento com PayPal...
        }
    }

}
