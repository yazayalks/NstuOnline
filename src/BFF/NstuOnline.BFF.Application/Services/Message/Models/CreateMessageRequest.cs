namespace NstuOnline.BFF.Application.Services.Message.Models;

public class CreateMessageRequest
{
    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }

    public string Text { get; set; }

    //TODO: public IEnumerable<Guid> AttachmentIds { get; set; }
}