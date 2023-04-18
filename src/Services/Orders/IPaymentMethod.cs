namespace ProvaPub.Services.Orders
{
    public interface IPaymentMethod
    {
        Task Pay(decimal paymentValue, int customerId);
    }

}
