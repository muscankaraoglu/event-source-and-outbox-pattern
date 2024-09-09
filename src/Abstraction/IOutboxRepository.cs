using EventSourcingAndOutbox.Outbox;

namespace EventSourcingAndOutbox.Abstraction
{
    public interface IOutboxRepository
    {
        IEnumerable<OutboxMessage> GetPendingMessages();
        IEnumerable<OutboxMessage> GetCompletedMessages();
        void Save(OutboxMessage outboxMessage);
        void Update(OutboxMessage message);
    }
}
