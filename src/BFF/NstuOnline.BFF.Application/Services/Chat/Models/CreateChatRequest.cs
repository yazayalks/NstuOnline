namespace NstuOnline.BFF.Application.Services.Chat.Models;

public class CreateChatRequest
{
    public string Name { get; set; }

    public byte ChatTypeId { get; set; }

    public IEnumerable<Guid> UserIds { get; set; }
}