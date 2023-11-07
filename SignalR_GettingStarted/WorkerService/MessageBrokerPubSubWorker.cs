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
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
        }
    }
}