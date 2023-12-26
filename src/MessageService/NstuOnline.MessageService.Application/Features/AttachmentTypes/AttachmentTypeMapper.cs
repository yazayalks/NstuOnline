using AutoMapper;
using NstuOnline.MessageService.Application.Features.AttachmentTypes.GetAll;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.AttachmentTypes;

public class AttachmentTypeMapper : Profile
{
    public AttachmentTypeMapper()
    {
        CreateMap<AttachmentType, AttachmentTypeResponse>();
    }
}