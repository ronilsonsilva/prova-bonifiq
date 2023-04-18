namespace ProvaPub.Services.Orders
{
    public interface IPaymentMethodFactory
    {
        IPaymentMethod Create(string paymentMethod);
    }

}
