namespace NstuOnline.BFF.Application.Services.Message.Models;

public class SearchMessageResponse
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }

    public Guid ChatId { get; set; }
    
    public Guid? ParentId { get; set; }

    public string Text { get; set; }

    public DateTime CreateDate { get; set; }
    
    //TODO public ICollection<Attachment> Attachments { get; set; }
}