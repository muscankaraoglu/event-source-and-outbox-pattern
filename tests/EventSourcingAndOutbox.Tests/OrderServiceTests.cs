using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Models;
using EventSourcingAndOutbox.Outbox;
using EventSourcingAndOutbox.Services;
using Moq;

namespace EventSourcingAndOutbox.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IOutboxRepository> _outboxRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _outboxRepositoryMock = new Mock<IOutboxRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object, _outboxRepositoryMock.Object);
        }

        [Fact]
        public void CreateOrder_Should_SaveOrder_And_OutboxEvent()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var product = "TestProduct";
            var quantity = 2;

            // Act
            _orderService.CreateOrder(orderId, product, quantity);

            // Assert
            _orderRepositoryMock.Verify(x => x.Save(It.IsAny<OrderAggregate>()), Times.Once);
            _outboxRepositoryMock.Verify(x => x.Save(It.IsAny<OutboxMessage>()), Times.Once);
        }
    }
}
