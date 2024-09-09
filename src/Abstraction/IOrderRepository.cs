using EventSourcingAndOutbox.Models;

namespace EventSourcingAndOutbox.Abstraction
{
    public interface IOrderRepository
    {
        List<OrderAggregate> GetOrders();
        OrderAggregate GetById(Guid id);
        void Save(OrderAggregate orderAggregate);
    }
}
