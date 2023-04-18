using ProvaPub.Models;

namespace ProvaPub.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IPaymentMethodFactory _paymentMethodFactory;

        public OrderService(IPaymentMethodFactory paymentMethodFactory)
        {
            _paymentMethodFactory = paymentMethodFactory;
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            var paymentMethodImplementation = _paymentMethodFactory.Create(paymentMethod);
            await paymentMethodImplementation.Pay(paymentValue, customerId);

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }

}
