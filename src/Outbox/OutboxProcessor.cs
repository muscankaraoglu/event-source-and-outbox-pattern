using EventSourcingAndOutbox.Abstraction;

namespace EventSourcingAndOutbox.Outbox
{
    public class OutboxProcessor
    {
        private readonly IOutboxRepository _outboxRepository;
        private readonly IEventBus _eventBus;

        public OutboxProcessor(IOutboxRepository outboxRepository, IEventBus eventBus)
        {
            _outboxRepository = outboxRepository;
            _eventBus = eventBus;
        }

        public void ProcessOutbox()
        {
            var messages = _outboxRepository.GetPendingMessages();

            foreach (var message in messages)
            {
                _eventBus.Publish(message.EventType, message.Payload);

                message.MarkAsProcessed();
                _outboxRepository.Update(message);
            }
        }

    }
}
