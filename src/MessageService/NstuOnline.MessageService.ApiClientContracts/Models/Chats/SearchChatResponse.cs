namespace NstuOnline.MessageService.ApiClientContracts.Models.Chats;

public class SearchChatResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public byte ChatTypeId { get; set; }
    
    public SearchChatLastMessageResponse LastMessage { get; set; }
}

public class SearchChatLastMessageResponse
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public string Text { get; set; }

    public DateTime CreateDate { get; set; }
}