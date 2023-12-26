using AutoMapper;
using NstuOnline.BFF.Application.Services.AttachmentType.Models;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.AttachmentTypes;

namespace NstuOnline.BFF.Application.Services.AttachmentType;

public class AttachmentTypeMapper : Profile
{
    public AttachmentTypeMapper()
    {
        GetAll();
    }

    private void GetAll()
    {
        CreateMap<ApiModel.AttachmentTypeResponse, AttachmentTypeResponse>();
    }
}