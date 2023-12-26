using AutoMapper;
using NstuOnline.MessageService.Application.Features.Attachments.Create;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.Attachments;

public class AttachmentMapper : Profile
{
    public AttachmentMapper()
    {
        MapCreate();
    }

    private void MapCreate()
    {
        CreateMap<CreateAttachmentRequest, Attachment>();
    }
}