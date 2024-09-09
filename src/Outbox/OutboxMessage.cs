
namespace EventSourcingAndOutbox.Outbox
{
    public record OutboxMessage(Guid Id, DateTime OccurredAt, string EventType, string Payload)
    {
        public bool Processed { get; set; }

        internal void MarkAsProcessed()
        {
            Processed = true;
        }
    }
}
