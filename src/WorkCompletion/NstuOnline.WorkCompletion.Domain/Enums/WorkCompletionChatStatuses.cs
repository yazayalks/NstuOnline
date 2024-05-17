namespace NstuOnline.WorkCompletion.Domain.Enums;

public enum WorkCompletionChatStatuses : byte
{
    NoChat = 1,
    NewMessage = 2,
    Read = 3,
    Sent = 4,
    AwaitingResponse = 5
}