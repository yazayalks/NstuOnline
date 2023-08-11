using AutoMapper;
using NstuOnline.MessageService.Application.Features.Messages.Create;
using NstuOnline.MessageService.Application.Features.Messages.Search;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Messages;

public class MessageMapper : Profile
{
    public MessageMapper()
    {
        MapCreate();
        MapSearch();
    }

    private void MapSearch()
    {
        CreateMap<SearchMessageRequest, SearchMessageCriteria>();
        CreateMap<Message, SearchMessageResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateMessageRequest, Message>();
    }
}