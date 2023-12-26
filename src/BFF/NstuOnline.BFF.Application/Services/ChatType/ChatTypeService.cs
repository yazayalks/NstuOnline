using AutoMapper;
using NstuOnline.BFF.Application.Services.ChatType.Models;
using NstuOnline.MessageService.ApiClientContracts.ApiClients;

namespace NstuOnline.BFF.Application.Services.ChatType;

public class ChatTypeService : IChatTypeService
{
    private readonly IChatTypeApiClient _chatTypeApiClient;
    private readonly IMapper _mapper;

    public ChatTypeService(
        IChatTypeApiClient chatTypeApiClient,
        IMapper mapper)
    {
        _chatTypeApiClient = chatTypeApiClient;
        _mapper = mapper;
    }

    public async Task<List<ChatTypeResponse>> GetAll(CancellationToken cancellationToken = default)
    {
        var allChatTypes = await _chatTypeApiClient.GetAll(cancellationToken);

        return _mapper.Map<List<ChatTypeResponse>>(allChatTypes);
    }
}