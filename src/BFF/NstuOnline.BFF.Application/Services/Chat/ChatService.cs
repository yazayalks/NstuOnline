using AutoMapper;
using Common.Models;
using NstuOnline.BFF.Application.Services.Chat.Models;
using NstuOnline.MessageService.ApiClientContracts.ApiClients;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.Chats;

namespace NstuOnline.BFF.Application.Services.Chat;

public class ChatService : IChatService
{
    private readonly IChatApiClient _chatApiClient;
    private readonly IMapper _mapper;

    public ChatService(IChatApiClient chatApiClient, IMapper mapper)
    {
        _chatApiClient = chatApiClient;
        _mapper = mapper;
    }

    public async Task<Guid> Create(CreateChatRequest request, CancellationToken cancellationToken)
    {
        var apiRequest = _mapper.Map<ApiModel.CreateChatRequest>(request);
        
        return await _chatApiClient.Create(apiRequest, cancellationToken);
    }

    public async Task<PagedList<SearchChatResponse>> Search(SearchChatRequest request, CancellationToken cancellationToken)
    {
        var apiRequest = _mapper.Map<ApiModel.SearchChatRequest>(request);

        var chats = await _chatApiClient.Search(apiRequest, cancellationToken);

        return _mapper.Map<PagedList<SearchChatResponse>>(chats);
    }
}