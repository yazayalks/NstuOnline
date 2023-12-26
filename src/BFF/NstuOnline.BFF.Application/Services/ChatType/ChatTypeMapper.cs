using AutoMapper;
using NstuOnline.BFF.Application.Services.ChatType.Models;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.ChatTypes;

namespace NstuOnline.BFF.Application.Services.ChatType;

public class ChatTypeMapper : Profile
{
    public ChatTypeMapper()
    {
        GetAll();
    }

    private void GetAll()
    {
        CreateMap<ApiModel.ChatTypeResponse, ChatTypeResponse>();
    }
}