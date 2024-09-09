using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Models;

namespace EventSourcingAndOutbox.Concrete
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, OrderAggregate> _orders = new Dictionary<Guid, OrderAggregate>();

        public void Save(OrderAggregate orderAggregate)
        {
            _orders[orderAggregate.OrderId] = orderAggregate;
        }

        public OrderAggregate GetById(Guid orderId)
        {
            _orders.TryGetValue(orderId, out var orderAggregate);
            return orderAggregate;
        }
        public List<OrderAggregate> GetOrders()
        {
            return _orders.Select(i => i.Value).ToList();
        }
    }

}
