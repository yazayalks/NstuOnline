namespace NstuOnline.MessageService.Domain.Enums;

public enum MessageTypes : byte
{
    Text = 1,
    Attachments = 2,
    TextAndAttachments = 3,
    Photo = 4,
    Voice = 5
}