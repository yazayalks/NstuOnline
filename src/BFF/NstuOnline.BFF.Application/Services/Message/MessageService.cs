using AutoMapper;
using Common.Models;
using NstuOnline.BFF.Application.Services.Message.Models;
using NstuOnline.MessageService.ApiClientContracts.ApiClients;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.Messages;

namespace NstuOnline.BFF.Application.Services.Message;

public class MessageService : IMessageService
{
    private readonly IMessageApiClient _messageApiClient;
    private readonly IMapper _mapper;

    public MessageService(IMessageApiClient messageApiClient, IMapper mapper)
    {
        _messageApiClient = messageApiClient;
        _mapper = mapper;
    }

    public async Task<Guid> Create(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        var apiRequest = _mapper.Map<ApiModel.CreateMessageRequest>(request);
        
        return await _messageApiClient.Create(apiRequest, cancellationToken);
    }

    public async Task<PagedList<SearchMessageResponse>> Search(SearchMessageRequest request, CancellationToken cancellationToken)
    {
        var apiRequest = _mapper.Map<ApiModel.SearchMessageRequest>(request);

        var messages = await _messageApiClient.Search(apiRequest, cancellationToken);

        return _mapper.Map<PagedList<SearchMessageResponse>>(messages);
    }
}