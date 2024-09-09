using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Models;
using EventSourcingAndOutbox.Outbox;
using System.Text.Json;

namespace EventSourcingAndOutbox.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOutboxRepository _outboxRepository;

        public OrderService(IOrderRepository orderRepository, IOutboxRepository outboxRepository)
        {
            _orderRepository = orderRepository;
            _outboxRepository = outboxRepository;
        }

        public void CreateOrder(Guid orderId, string product, int quantity)
        {
            var orderAggregate = new OrderAggregate();
            orderAggregate.CreateOrder(orderId, product, quantity);

            _orderRepository.Save(orderAggregate);

            foreach (var @event in orderAggregate.GetUncommittedEvents())
            {
                _outboxRepository.Save(new OutboxMessage(Guid.NewGuid(), DateTime.UtcNow, @event.GetType().Name, JsonSerializer.Serialize(@event)));
            }
        }

        public List<OrderAggregate> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        public OrderAggregate GetById(Guid id)
        {
            return _orderRepository.GetById(id);
        }
    }
}
