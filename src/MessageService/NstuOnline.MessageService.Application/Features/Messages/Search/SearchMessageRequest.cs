using AutoMapper;
using Common.Models;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Messages.Search;

public record SearchMessageRequest : PagedRequest, IRequest<PagedList<SearchMessageResponse>>
{
    public string Keyword { get; init; }
    
    public Guid UserId { get; init; }
    
    public Guid ChatId { get; init; }
}

public class SearchMessageHandler : IRequestHandler<SearchMessageRequest, PagedList<SearchMessageResponse>>
{
    private readonly IChatUserRepository _chatUserRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;

    public SearchMessageHandler(IChatUserRepository chatUserRepository, IMessageRepository messageRepository, IMapper mapper)
    {
        _chatUserRepository = chatUserRepository;
        _messageRepository = messageRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<SearchMessageResponse>> Handle(SearchMessageRequest request, CancellationToken cancellationToken)
    {
        var chatUser = await _chatUserRepository.Get(request.UserId, request.ChatId, cancellationToken);

        if (chatUser is null)
        {
            //TODO chatUser is exist
        }

        var searchMessageCriteria = _mapper.Map<SearchMessageCriteria>(request);

        var messages = await _messageRepository.Search(searchMessageCriteria, cancellationToken);

        return _mapper.Map<PagedList<SearchMessageResponse>>(messages);
    }
}
