using Company.Delivery.Api.AppStart;
using Company.Delivery.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();

var app = builder.Build();

app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = new ExceptionMiddleware().Invoke });

app.UseDeliveryApi();
app.MapControllers();

app.Run();