namespace ProvaPub.Services.Orders
{
    public class PaymentMethodFactory : IPaymentMethodFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentMethodFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentMethod Create(string paymentMethod)
        {
            switch (paymentMethod)
            {
                case "pix":
                    return _serviceProvider.GetService<PixPayment>();
                case "creditcard":
                    return _serviceProvider.GetService<CreditCardPayment>();
                case "paypal":
                    return _serviceProvider.GetService<PaypalPayment>();
                default:
                    throw new ArgumentException($"Invalid payment method: {paymentMethod}");
            }
        }
    }

}
