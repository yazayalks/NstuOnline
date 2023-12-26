using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;

namespace NstuOnline.MessageService.Application.Features.AttachmentTypes.GetAll;

public record GetAllAttachmentTypesRequest : IRequest<List<AttachmentTypeResponse>>;

public class GetAllAttachmentTypesHandler : IRequestHandler<GetAllAttachmentTypesRequest, List<AttachmentTypeResponse>>
{
    private readonly IAttachmentTypeRepository _attachmentTypeRepository;
    private readonly IMapper _mapper;

    public GetAllAttachmentTypesHandler(
        IAttachmentTypeRepository attachmentTypeRepository,
        IMapper mapper)
    {
        _attachmentTypeRepository = attachmentTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<AttachmentTypeResponse>> Handle(GetAllAttachmentTypesRequest request,
        CancellationToken cancellationToken)
    {
        var allAttachmentTypes = await _attachmentTypeRepository.GetAll(cancellationToken: cancellationToken);

        return _mapper.Map<List<AttachmentTypeResponse>>(allAttachmentTypes);
    }
}