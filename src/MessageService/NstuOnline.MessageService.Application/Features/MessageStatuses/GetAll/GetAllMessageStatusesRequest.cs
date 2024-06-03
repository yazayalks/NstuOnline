using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;

namespace NstuOnline.MessageService.Application.Features.MessageStatuses.GetAll;

public record GetAllMessageStatusesRequest : IRequest<List<MessageStatusResponse>>;

public class GetAllMessageStatusesHandler : IRequestHandler<GetAllMessageStatusesRequest, List<MessageStatusResponse>>
{
    private readonly IMessageStatusRepository _messageStatusRepository;
    private readonly IMapper _mapper;

    public GetAllMessageStatusesHandler(IMessageStatusRepository messageStatusRepository, IMapper mapper)
    {
        _messageStatusRepository = messageStatusRepository;
        _mapper = mapper;
    }

    public async Task<List<MessageStatusResponse>> Handle(GetAllMessageStatusesRequest request,
        CancellationToken cancellationToken)
    {
        var allMessageStatuses = await _messageStatusRepository.GetAll(cancellationToken: cancellationToken);

        return _mapper.Map<List<MessageStatusResponse>>(allMessageStatuses);
    }
}