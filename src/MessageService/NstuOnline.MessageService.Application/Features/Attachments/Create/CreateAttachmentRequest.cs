using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.Attachments.Create;

public record CreateAttachmentRequest : IRequest<Guid>
{
    public Guid FileId { get; init; }

    public byte AttachmentTypeId { get; init; }
}

public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentRequest, Guid>
{
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IMapper _mapper;

    public CreateAttachmentHandler(
        IAttachmentRepository attachmentRepository,
        IMapper mapper)
    {
        _attachmentRepository = attachmentRepository;
        _mapper = mapper;
    }


    public async Task<Guid> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        var attachment = _mapper.Map<Attachment>(request);

        await _attachmentRepository.Add(attachment, cancellationToken);

        return attachment.Id;
    }
}