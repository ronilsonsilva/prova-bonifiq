namespace ProvaPub.Services.Orders
{
    public class PixPayment : IPaymentMethod
    {
        public async Task Pay(decimal paymentValue, int customerId)
        {
            // Faz pagamento com Pix...
        }
    }

}
