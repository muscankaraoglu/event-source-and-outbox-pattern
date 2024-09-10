using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Outbox;
using Moq;

namespace EventSourcingAndOutbox.Tests
{
    public class OutboxProcessorTests
    {
        private readonly Mock<IOutboxRepository> _outboxRepositoryMock;
        private readonly Mock<IEventBus> _eventBusMock;
        private readonly OutboxProcessor _outboxProcessor;

        public OutboxProcessorTests()
        {
            _outboxRepositoryMock = new Mock<IOutboxRepository>();
            _eventBusMock = new Mock<IEventBus>();
            _outboxProcessor = new OutboxProcessor(_outboxRepositoryMock.Object, _eventBusMock.Object);
        }

        [Fact]
        public void ProcessOutbox_Should_PublishEvents_And_UpdateOutbox()
        {
            // Arrange
            OutboxMessage outboxMessage = new(Guid.NewGuid(), DateTime.UtcNow, "OrderCreatedEvent", "{..}");

            _outboxRepositoryMock.Setup(x => x.GetPendingMessages())
                .Returns(new List<OutboxMessage> { outboxMessage });

            // Act
            _outboxProcessor.ProcessOutbox();

            // Assert
            _eventBusMock.Verify(x => x.Publish(outboxMessage.EventType, outboxMessage.Payload), Times.Once);
            _outboxRepositoryMock.Verify(x => x.Update(It.Is<OutboxMessage>(m => m.Id == outboxMessage.Id && m.Processed == true)), Times.Once);
        }
    }
}
