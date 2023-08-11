namespace NstuOnline.MessageService.ApiClientContracts.Models.Chats;

public class SearchChatsResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public byte ChatTypeId { get; set; }
}