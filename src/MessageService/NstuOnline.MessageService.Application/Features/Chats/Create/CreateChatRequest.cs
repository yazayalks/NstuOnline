using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Application.Exceptions;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;

namespace NstuOnline.MessageService.Application.Features.Chats.Create;

public record CreateChatRequest : IRequest<Guid>
{
    public string Name { get; init; }

    public byte ChatTypeId { get; init; }

    public IEnumerable<Guid> UserIds { get; init; }
}

public class CreateChatHandler : IRequestHandler<CreateChatRequest, Guid>
{
    private readonly IChatRepository _chatRepository;
    private readonly IChatTypeRepository _chatTypeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateChatHandler(
        IChatRepository chatRepository,
        IChatTypeRepository chatTypeRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _chatRepository = chatRepository;
        _chatTypeRepository = chatTypeRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateChatRequest request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);
        
        var users = await _userRepository.GetByIds(request.UserIds, cancellationToken);

        if (users.Count != request.UserIds.Count())
        {
            var notFoundIds = request.UserIds.Except(users.Select(x => x.UserId));

            throw new UserNotFoundException(notFoundIds);
        }

        var chat = _mapper.Map<Chat>(request);
        chat.ChatUsers = users
            .Select(x => new ChatUser { UserId = x.UserId })
            .ToList();

        await _chatRepository.Add(chat, cancellationToken);

        return chat.Id;
    }
    
    private async Task Validate(CreateChatRequest request, CancellationToken cancellationToken)
    {
        if (!await _chatTypeRepository.IsExist(request.ChatTypeId, cancellationToken))
        {
            throw new EntitiesNotFoundException(request.ChatTypeId, ExceptionEntityTypes.ChatType, nameof(request.ChatTypeId));
        }
    }
}