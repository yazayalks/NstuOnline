using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;
using ChatDb = NstuOnline.MessageService.Domain.Entities.Chat;

namespace NstuOnline.MessageService.Application.Features.Chats.Delete;

public sealed record DeleteChatRequest(Guid Id) : IRequest;

public class DeleteChatHandler : IRequestHandler<DeleteChatRequest>
{
    private readonly IChatRepository _chatRepository;

    public DeleteChatHandler(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task Handle(DeleteChatRequest request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetById(request.Id, cancellationToken: cancellationToken);

        if (chat is null)
        {
            throw new EntitiesNotFoundException(request.Id, ExceptionEntityTypes.Chat, nameof(ChatDb.Id));
        }

        await _chatRepository.Delete(chat, cancellationToken);
    }
}