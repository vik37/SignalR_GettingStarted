using SignalR_GettingStarted.Dtos;

namespace SignalR_GettingStarted.WorkerService;

public sealed class MessageBrokerPubSubWorker : BackgroundService
{
    private readonly IHubContext<MessageBrokerHub> _messages;

    public MessageBrokerPubSubWorker(IHubContext<MessageBrokerHub> messages)
    {
        _messages = messages;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}",$"Tittle_{Guid.NewGuid()}:N",DateTime.UtcNow);
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
            await _messages.Clients.All.SendAsync("onMessageReceived",eventMessage,stoppingToken);
        }
    }
}