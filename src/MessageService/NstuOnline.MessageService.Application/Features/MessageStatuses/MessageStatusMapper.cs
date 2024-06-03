using AutoMapper;
using NstuOnline.MessageService.Application.Features.MessageStatuses.GetAll;
using NstuOnline.MessageService.Domain.Entities;

namespace NstuOnline.MessageService.Application.Features.MessageStatuses;

public class MessageStatusMapper : Profile
{
    public MessageStatusMapper()
    {
        CreateMap<MessageStatus, MessageStatusResponse>();
    }
}
