using AutoMapper;
using Common.Models;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Chats.Search;

public record SearchChatsRequest : PagedRequest, IRequest<PagedList<SearchChatsResponse>>
{
    public Guid UserId { get; init; }
    
    public byte? ChatTypeId { get; init; }
}

public class SearchChatsHandler : IRequestHandler<SearchChatsRequest, PagedList<SearchChatsResponse>>
{
    private readonly IChatRepository _chatRepository;
    private readonly IMapper _mapper;

    public SearchChatsHandler(IChatRepository chatRepository, IMapper mapper)
    {
        _chatRepository = chatRepository;
        _mapper = mapper;
    }

    public async Task<PagedList<SearchChatsResponse>> Handle(
        SearchChatsRequest request, 
        CancellationToken cancellationToken)
    {
        var searchCriteria = _mapper.Map<SearchChatCriteria>(request);

        var chats = await _chatRepository.Search(searchCriteria, cancellationToken);

        return _mapper.Map<PagedList<SearchChatsResponse>>(chats);
    }
}