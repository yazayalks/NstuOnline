namespace NstuOnline.WorkCompletion.Domain.Enums;

public enum WorkCompletionStatuses : byte
{
    NotIssued = 1,
    Issued = 2,
    InProgress = 3,
    AwaitingReview = 4,
    UnderReview = 5,
    Returned = 6,
    Completed = 7,
    NotCompleted = 8
}