﻿using ProvaPub.Models;

namespace ProvaPub.Services.Orders
{
    public interface IOrderService
    {
        Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId);
    }
}
