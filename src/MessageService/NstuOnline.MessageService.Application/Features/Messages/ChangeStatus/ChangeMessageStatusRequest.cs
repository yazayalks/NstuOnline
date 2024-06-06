using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;

namespace NstuOnline.MessageService.Application.Features.Messages.ChangeStatus;

public record ChangeMessageStatusRequest(Guid Id, byte StatusId) : IRequest;

public class ChangeMessageStatusHandler : IRequestHandler<ChangeMessageStatusRequest>
{
    private readonly IMessageRepository _messageRepository;
    private readonly IMessageStatusRepository _messageStatusRepository;

    public ChangeMessageStatusHandler(
        IMessageRepository messageRepository,
        IMessageStatusRepository messageStatusRepository
    )
    {
        _messageRepository = messageRepository;
        _messageStatusRepository = messageStatusRepository;
    }

    public async Task Handle(ChangeMessageStatusRequest request, CancellationToken cancellationToken)
    {
        if (!await _messageStatusRepository.IsExist(request.StatusId, cancellationToken))
        {
            throw new EntitiesNotFoundException(request.StatusId, ExceptionEntityTypes.MessageStatus, nameof(request.StatusId));
        }
    
        var message = await _messageRepository.GetById(request.Id,
            new[] { nameof(Domain.Entities.Message) },
            cancellationToken: cancellationToken);
        if (message is null)
        {
            throw new EntitiesNotFoundException(request.Id, ExceptionEntityTypes.Message, nameof(request.Id));
        }
    
        message.MessageStatusId = request.StatusId;

        await _messageRepository.Update(message, cancellationToken);
    }
}