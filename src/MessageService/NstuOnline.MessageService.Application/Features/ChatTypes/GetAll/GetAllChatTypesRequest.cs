using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;

namespace NstuOnline.MessageService.Application.Features.ChatTypes.GetAll;

public record GetAllChatTypesRequest : IRequest<List<ChatTypeResponse>>;

public class GetAllChatTypesHandler : IRequestHandler<GetAllChatTypesRequest, List<ChatTypeResponse>>
{
    private readonly IChatTypeRepository _chatTypeRepository;
    private readonly IMapper _mapper;

    public GetAllChatTypesHandler(IChatTypeRepository chatTypeRepository, IMapper mapper)
    {
        _chatTypeRepository = chatTypeRepository;
        _mapper = mapper;
    }


    public async Task<List<ChatTypeResponse>> Handle(GetAllChatTypesRequest request,
        CancellationToken cancellationToken)
    {
        var allChatTypes = await _chatTypeRepository.GetAll(cancellationToken: cancellationToken);

        return _mapper.Map<List<ChatTypeResponse>>(allChatTypes);
    }
}