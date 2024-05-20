namespace NstuOnline.EducationalStructure.Domain.Entity;

public class TopicAttachment
{
    public Guid TopicId { get; set; }
    
    public Topic Topic { get; set; }
    
    public Guid AttachmentId { get; set; }
    
    public Attachment Attachment { get; set; }
}