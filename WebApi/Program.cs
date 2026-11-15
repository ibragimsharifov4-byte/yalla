using Application.interfaces;
using Application.Services;
using Domain.Data;
using Domain.interfaces;
using Infrastructure.Repositories;
using WebApi.MiddleWares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Database>();
builder.Services.AddScoped<ICompanyRepository , CompanyRepository>();
builder.Services.AddScoped<ICompanyService , CompanyService>();

builder.Services.AddScoped<IMenuRepository , MenuRepository>();
builder.Services.AddScoped<IMenuService , MenuService>();

builder.Services.AddScoped<IMenuItemRepository , MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService , MenuItemService>();

builder.Services.AddScoped<ISubscriptionRepository , SubscriptionRepository>();
builder.Services.AddScoped<ISubscriptionService , SubscriptionService>();

builder.Services.AddScoped<IOrderRepository , OrderRepository>();
builder.Services.AddScoped<IOrderService , OrderService>();

builder.Services.AddScoped<IOrderItemRepository , OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService , OrderItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestLoggingMiddleWare>();
app.MapControllers();
app.Run();
