using EventSourcingAndOutbox.Events.Orders;

namespace EventSourcingAndOutbox.Models
{
    public class OrderAggregate
    {
        private List<object> _events = new List<object>();
        public Guid OrderId { get; private set; }
        public string Status { get; private set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public void CreateOrder(Guid orderId, string product, int quantity)
        {
            var orderCreatedEvent = new OrderCreatedEvent(orderId, product, quantity, DateTime.UtcNow);

            Apply(orderCreatedEvent);
            _events.Add(orderCreatedEvent);
        }

        private void Apply(OrderCreatedEvent @event)
        {
            OrderId = @event.OrderId;
            Status = "Created";
            Product = @event.Product;
            Quantity = @event.Quantity;
            // Diğer durumlar burada güncellenir
        }

        public IEnumerable<object> GetUncommittedEvents()
        {
            return _events.AsEnumerable();
        }
    }
}
