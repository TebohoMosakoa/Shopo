using EventBus.Messages.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.Application;
using Order.Infrastructure;
using Order.Infrastructure.Persistence;
using OrderApi.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddMassTransit(c =>
    {
        c.AddConsumer<BasketCheckoutConsumer>();

        c.UsingRabbitMq((context, config) =>
        {
            config.Host(builder.Configuration["EventBusSettings:HostAddress"]);

            config.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, cfg =>
            {
                cfg.ConfigureConsumer<BasketCheckoutConsumer>(context);
            });
        });
    });

builder.Services.AddScoped<BasketCheckoutConsumer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
