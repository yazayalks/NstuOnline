using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.Messages.Create;

public record CreateMessageRequest : IRequest<Guid>
{
    public Guid UserId { get; init; }

    public Guid ChatId { get; init; }

    public string Text { get; init; }

    //TODO: public IEnumerable<Guid> AttachmentIds { get; init; }
}

public class CreateMessageHandler : IRequestHandler<CreateMessageRequest, Guid>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public CreateMessageHandler(
        IMessageRepository messageRepository, 
        IMapper mapper)
    {
        _messageRepository = messageRepository;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(
        CreateMessageRequest request, 
        CancellationToken cancellationToken)
    {
        var message = _mapper.Map<Message>(request);
        message.CreateDate = DateTime.UtcNow;
        
        await _messageRepository.Add(message, cancellationToken);

        return message.Id;
    }
}