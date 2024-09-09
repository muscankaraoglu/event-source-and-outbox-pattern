namespace EventSourcingAndOutbox.Abstraction
{
    public interface IEventBus
    {
        void Publish(string eventType, string payload);
    }
}
