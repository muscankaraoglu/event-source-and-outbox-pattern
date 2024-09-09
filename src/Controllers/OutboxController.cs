using EventSourcingAndOutbox.Abstraction;
using EventSourcingAndOutbox.Outbox;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingAndOutbox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutboxController : ControllerBase
    {
        private readonly OutboxProcessor _outboxProcessor;
        private readonly IOutboxRepository _outboxRepository;
        public OutboxController(OutboxProcessor outboxProcessor, IOutboxRepository outboxRepository)
        {
            _outboxProcessor = outboxProcessor;
            _outboxRepository = outboxRepository;
        }
        [HttpGet("/GetPendingMessages")]
        public IActionResult GetPendingMessages()
        {
            return Ok(_outboxRepository.GetPendingMessages());
        }
        [HttpGet("/GetCompletedMessages")]
        public IActionResult GetCompletedMessages()
        {
            return Ok(_outboxRepository.GetCompletedMessages());
        }
        [HttpPost("/CommitAll")]
        public IActionResult CommitAll()
        {
            _outboxProcessor.ProcessOutbox();
            return Ok();
        }
    }
}
