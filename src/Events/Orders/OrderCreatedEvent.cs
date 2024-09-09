
namespace EventSourcingAndOutbox.Events.Orders
{
    public record OrderCreatedEvent(Guid OrderId, string Product, int Quantity, DateTime CreatedAt);
}
