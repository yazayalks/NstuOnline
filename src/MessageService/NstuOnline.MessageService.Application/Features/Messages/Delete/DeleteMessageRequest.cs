using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;
using MessageDb = NstuOnline.MessageService.Domain.Entities.Message;

namespace NstuOnline.MessageService.Application.Features.Messages.Delete;

public sealed record DeleteMessageRequest(Guid Id) : IRequest;

public class DeleteMessageHandler : IRequestHandler<DeleteMessageRequest>
{
    private readonly IMessageRepository _messageRepository;

    public DeleteMessageHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }


    public async Task Handle(DeleteMessageRequest request, CancellationToken cancellationToken)
    {
        var message = await _messageRepository.GetById(request.Id, cancellationToken: cancellationToken);

        if (message is null)
        {
            throw new EntitiesNotFoundException(request.Id, ExceptionEntityTypes.Message, nameof(MessageDb.Id));
        }

        message.IsDeleted = true;
        await _messageRepository.Update(message, cancellationToken);
    }
}