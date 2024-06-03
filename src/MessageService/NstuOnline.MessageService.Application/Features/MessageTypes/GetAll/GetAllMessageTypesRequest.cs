using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;

namespace NstuOnline.MessageService.Application.Features.MessageTypes.GetAll;

public record GetAllMessageTypesRequest : IRequest<List<MessageTypeResponse>>;

public class GetAllMessageTypesHandler : IRequestHandler<GetAllMessageTypesRequest, List<MessageTypeResponse>>
{
    private readonly IMessageTypeRepository _messageTypeRepository;
    private readonly IMapper _mapper;

    public GetAllMessageTypesHandler(IMessageTypeRepository messageTypeRepository, IMapper mapper)
    {
        _messageTypeRepository = messageTypeRepository;
        _mapper = mapper;
    }


    public async Task<List<MessageTypeResponse>> Handle(GetAllMessageTypesRequest request,
        CancellationToken cancellationToken)
    {
        var allMessageTypes = await _messageTypeRepository.GetAll(cancellationToken: cancellationToken);

        return _mapper.Map<List<MessageTypeResponse>>(allMessageTypes);
    }
}