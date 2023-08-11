using AutoMapper;
using Common.Models;
using NstuOnline.MessageService.Application.Features.Chats.Create;
using NstuOnline.MessageService.Application.Features.Chats.Search;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Chats;

public class ChatMapper : Profile
{
    public ChatMapper()
    {
        MapSearch();
        MapCreate();
    }

    private void MapCreate()
    {
        CreateMap<CreateChatRequest, Chat>();
    }

    private void MapSearch()
    {
        CreateMap<SearchChatsRequest, SearchChatCriteria>();
        CreateMap<Chat, SearchChatsResponse>();
    }
}