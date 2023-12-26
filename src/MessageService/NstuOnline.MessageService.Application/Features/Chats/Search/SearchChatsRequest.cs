using AutoMapper;
using Common.Models;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Chats.Search;

public record SearchChatsRequest : PagedRequest, IRequest<PagedList<SearchChatResponse>>
{
    public Guid UserId { get; init; }

    public byte? ChatTypeId { get; init; }
}

public class SearchChatsHandler : IRequestHandler<SearchChatsRequest, PagedList<SearchChatResponse>>
{
    private readonly IChatRepository _chatRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public SearchChatsHandler(
        IChatRepository chatRepository,
        IMessageRepository messageRepository,
        IMapper mapper)
    {
        _chatRepository = chatRepository;
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<SearchChatResponse>> Handle(
        SearchChatsRequest request,
        CancellationToken cancellationToken)
    {
        var searchCriteria = _mapper.Map<SearchChatCriteria>(request);

        var chats = await _chatRepository.Search(searchCriteria, cancellationToken);

        var chatIds = chats.Items.Select(x => x.Id);
        
        var searchMessageCriteria = new SimplifySearchMessageCriteria
        {
            Take = int.MaxValue,
            ChatIds = chatIds,
            IsLast = true
        };
        
        var lastMessages = await _messageRepository.SimplifySearch(searchMessageCriteria, cancellationToken);
        
        var lastMessagesByChatId = lastMessages.Items?.ToDictionary(m => m.ChatId, m => m) ?? new Dictionary<Guid, Message>();
        
        var chatResponses = chats.Items.Select(chat => 
        {
            var response = _mapper.Map<SearchChatResponse>(chat);
            if (lastMessagesByChatId.TryGetValue(chat.Id, out var lastMessage))
            {
                response.LastMessage = _mapper.Map<SearchChatLastMessageResponse>(lastMessage);
            }
            return response;
        }).ToList();

        return new PagedList<SearchChatResponse>
        {
            TotalCount = chats.TotalCount,
            Items = chatResponses
        };
    }
}