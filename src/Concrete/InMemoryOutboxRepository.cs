using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Outbox;

namespace EventSourcingAndOutbox.Concrete
{
    public class InMemoryOutboxRepository : IOutboxRepository
    {
        private readonly List<OutboxMessage> _outboxMessages = new List<OutboxMessage>();

        public void Save(OutboxMessage message)
        {
            _outboxMessages.Add(message);
        }

        public IEnumerable<OutboxMessage> GetPendingMessages()
        {
            return _outboxMessages.Where(m => !m.Processed).ToList();
        }
        public IEnumerable<OutboxMessage> GetCompletedMessages()
        {
            return _outboxMessages.Where(m => m.Processed).ToList();
        }

        public void Update(OutboxMessage message)
        {
            var existingMessage = _outboxMessages.FirstOrDefault(m => m.Id == message.Id);
            if (existingMessage != null)
            {
                existingMessage.Processed = message.Processed;
            }
        }
    }
}
