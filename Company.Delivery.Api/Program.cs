var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();

builder.Services.AddScoped<IWaybillService, WaybillService>();

builder.Services.AddDbContext<DeliveryDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase") );

var app = builder.Build();

app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = new ExceptionMiddleware().Invoke });

app.UseDeliveryApi();
app.MapControllers();

app.Run();