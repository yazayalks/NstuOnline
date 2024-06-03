using AutoMapper;
using NstuOnline.MessageService.Application.Features.MessageTypes.GetAll;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.MessageTypes;

public class MessageTypeMapper : Profile
{
    public MessageTypeMapper()
    {
        CreateMap<MessageType, MessageTypeResponse>();
    }
}
