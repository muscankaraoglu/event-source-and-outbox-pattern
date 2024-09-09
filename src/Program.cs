using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Concrete;
using EventSourcingAndOutbox.Outbox;
using EventSourcingAndOutbox.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
        builder.Services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        builder.Services.AddSingleton<IOutboxRepository, InMemoryOutboxRepository>();
        builder.Services.AddSingleton<OrderService>();
        builder.Services.AddSingleton<OutboxProcessor>();
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
    }
}