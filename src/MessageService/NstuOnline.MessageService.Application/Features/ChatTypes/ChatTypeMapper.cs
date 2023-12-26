using AutoMapper;
using NstuOnline.MessageService.Application.Features.ChatTypes.GetAll;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.ChatTypes;

public class ChatTypeMapper : Profile
{
    public ChatTypeMapper()
    {
        CreateMap<ChatType, ChatTypeResponse>();
    }
}