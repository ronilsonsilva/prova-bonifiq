using Moq;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        private readonly IRepository<Customer, CustomerList> _customerRepository;
        private readonly IRepository<Order, BaseList<Order>> _orderRepository;
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerRepository = new Mock<IRepository<Customer, CustomerList>>().Object;
            _orderRepository = new Mock<IRepository<Order, BaseList<Order>>>().Object;
            _customerService = new CustomerService(_customerRepository, _orderRepository);
        }

        [Fact]
        public async Task ListCustomers_ShouldReturnCustomerList()
        {
            // Arrange
            var expectedCustomerList = new CustomerList();
            var page = 1;
            Mock.Get(_customerRepository)
                .Setup(x => x.List(page))
                .ReturnsAsync(expectedCustomerList);

            // Act
            var result = await _customerService.ListCustomers(page);

            // Assert
            Assert.Equal(expectedCustomerList, result);
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowArgumentOutOfRangeException_WhenCustomerIdIsInvalid()
        {
            // Arrange
            var invalidCustomerId = -1;
            var purchaseValue = 100;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                _customerService.CanPurchase(invalidCustomerId, purchaseValue));
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowArgumentOutOfRangeException_WhenPurchaseValueIsInvalid()
        {
            // Arrange
            var validCustomerId = 1;
            var invalidPurchaseValue = -1;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
                _customerService.CanPurchase(validCustomerId, invalidPurchaseValue));
        }

        [Fact]
        public async Task CanPurchase_ShouldThrowInvalidOperationException_WhenCustomerDoesNotExist()
        {
            // Arrange
            var nonExistentCustomerId = 999;
            var purchaseValue = 100;
            Mock.Get(_customerRepository)
                .Setup(x => x.Get(nonExistentCustomerId))
                .ReturnsAsync((Customer)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _customerService.CanPurchase(nonExistentCustomerId, purchaseValue));
        }


        [Fact]
        public async Task CanPurchase_ShouldReturnFalse_WhenCustomerHasNeverBoughtBeforeAndPurchaseValueIsGreaterThan100()
        {
            // Arrange
            var customerId = 1;
            var purchaseValue = 101;
            var haveBoughtBefore = 0;
            Mock.Get(_customerRepository)
                .Setup(x => x.Count(s => s.Id == customerId && s.Orders.Any()))
                .ReturnsAsync(haveBoughtBefore);

            Mock.Get(_customerRepository)
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(new Customer() { Id = 1, Name = "Customers" });

            // Act
            var result = await _customerService.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.False(result);
        }
    }
}
