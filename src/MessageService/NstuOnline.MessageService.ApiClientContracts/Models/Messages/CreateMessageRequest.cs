namespace NstuOnline.MessageService.ApiClientContracts.Models.Messages;

public record CreateMessageRequest
{
    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }

    public string Text { get; set; }

    //TODO: public IEnumerable<Guid> AttachmentIds { get; set; }
}