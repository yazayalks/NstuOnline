using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Application.Exceptions;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;

namespace NstuOnline.MessageService.Application.Features.Chats.Update;

public sealed record UpdateChatRequest : IRequest<Guid>
{
    public Guid Id { get; init; }
    
    public string Name { get; set; }
    
    public byte ChatTypeId { get; set; }

    public ICollection<Guid> ChatUserIds { get; set; }
    
    public Guid? ParentId { get; set; } 
}

public class UpdateChatHandler : IRequestHandler<UpdateChatRequest, Guid>
{
    private readonly IChatRepository _chatRepository;
    private readonly IChatTypeRepository _chatTypeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateChatHandler(IChatRepository chatRepository, IChatTypeRepository chatTypeRepository, IUserRepository userRepository, IMapper mapper)
    {
        _chatRepository = chatRepository;
        _chatTypeRepository = chatTypeRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(UpdateChatRequest request, CancellationToken cancellationToken)
    {
        var chat = await _chatRepository.GetById(request.Id, cancellationToken: cancellationToken);
        
        if (chat is null)
        {
            throw new EntitiesNotFoundException(request.Id, ExceptionEntityTypes.Chat, nameof(request.Id));
        }
        
        await Validate(request, cancellationToken);
        
        var users = await _userRepository.GetByIds(request.ChatUserIds, cancellationToken);

        if (users.Count != request.ChatUserIds.Count())
        {
            var notFoundIds = request.ChatUserIds.Except(users.Select(x => x.UserId));

            throw new UserNotFoundException(notFoundIds);
        }
        
        chat = _mapper.Map(request, chat);
        
        await _chatRepository.Update(chat, cancellationToken);

        return chat.Id;
    }
    
    private async Task Validate(UpdateChatRequest request, CancellationToken cancellationToken)
    {
        if (!await _chatTypeRepository.IsExist(request.ChatTypeId, cancellationToken))
        {
            throw new EntitiesNotFoundException(request.ChatTypeId, ExceptionEntityTypes.ChatType, nameof(request.ChatTypeId));
        }
    }
}

