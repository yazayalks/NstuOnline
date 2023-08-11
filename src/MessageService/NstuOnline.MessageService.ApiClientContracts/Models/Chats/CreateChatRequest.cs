namespace NstuOnline.MessageService.ApiClientContracts.Models.Chats;

public record CreateChatRequest
{
    public string Name { get; set; }

    public byte ChatTypeId { get; set; }

    public IEnumerable<Guid> UserIds { get; set; }
}