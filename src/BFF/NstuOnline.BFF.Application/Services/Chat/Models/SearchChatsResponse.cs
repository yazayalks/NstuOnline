namespace NstuOnline.BFF.Application.Services.Chat.Models;

public class SearchChatsResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public byte ChatTypeId { get; set; }
}