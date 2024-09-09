using EventSourcingAndOutbox.Abstraction;

namespace EventSourcingAndOutbox.Concrete
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly List<(string eventType, string payload)> _publishedEvents = new List<(string eventType, string payload)>();

        public void Publish(string eventType, string payload)
        {
            _publishedEvents.Add((eventType, payload));
        }

        public List<(string eventType, string payload)> GetPublishedEvents()
        {
            return _publishedEvents;
        }
    }

}
