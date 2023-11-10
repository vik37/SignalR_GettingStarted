namespace SignalR_GettingStarted.Dtos;

public record EventMessage
{
    public string Id { get; init; }
    public string Tittle { get; init; }
    public DateTime CreatedDateTime { get; init; }

    public EventMessage(string id, string tittle, DateTime createdDateTime)
    {
        Id = id;
        Tittle = tittle;
        CreatedDateTime = createdDateTime;
    }
}