using Microsoft.EntityFrameworkCore;
using ProvaPub.Controllers;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using ProvaPub.Services.Orders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<RandomService>();
builder.Services.AddDbContext<TestDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ctx")));
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRepository<Customer, CustomerList>, CustomerRepository>();

// Register the payment methods
builder.Services.AddScoped<IPaymentMethodFactory, PaymentMethodFactory>();
builder.Services.AddTransient<PixPayment>();
builder.Services.AddTransient<CreditCardPayment>();
builder.Services.AddTransient<PaypalPayment>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
