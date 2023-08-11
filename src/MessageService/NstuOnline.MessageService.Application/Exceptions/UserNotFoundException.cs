namespace NstuOnline.MessageService.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(IEnumerable<Guid> ids) 
        : base($"Some users not found {string.Join(", ", ids)}")
    {
        
    }
}