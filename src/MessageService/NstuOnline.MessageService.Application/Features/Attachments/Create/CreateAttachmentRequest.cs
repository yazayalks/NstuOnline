using AutoMapper;
using MediatR;
using NstuOnline.MessageService.Domain.Contracts;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Enums;
using NstuOnline.MessageService.Domain.Exceptions;

namespace NstuOnline.MessageService.Application.Features.Attachments.Create;

public record CreateAttachmentRequest : IRequest<Guid>
{
    public Guid FileId { get; init; }

    public byte AttachmentTypeId { get; init; }
}

public class CreateAttachmentHandler : IRequestHandler<CreateAttachmentRequest, Guid>
{
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IAttachmentTypeRepository _attachmentTypeRepository;
    private readonly IMapper _mapper;

    public CreateAttachmentHandler(
        IAttachmentRepository attachmentRepository,
        IAttachmentTypeRepository attachmentTypeRepository,
        IMapper mapper)
    {
        _attachmentRepository = attachmentRepository;

        _attachmentTypeRepository = attachmentTypeRepository;
        _mapper = mapper;
    }


    public async Task<Guid> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        await ValidateAttachmentType(request, cancellationToken);

        var attachment = _mapper.Map<Attachment>(request);

        await _attachmentRepository.Add(attachment, cancellationToken);

        return attachment.Id;
    }

    private async Task ValidateAttachmentType(CreateAttachmentRequest request, CancellationToken cancellationToken)
    {
        
        if (!await _attachmentTypeRepository.IsExist(request.AttachmentTypeId, cancellationToken))
        {
            throw new EntitiesNotFoundException(request.AttachmentTypeId, ExceptionEntityTypes.AttachmentType, nameof(request.AttachmentTypeId));
        }
    }
}