using AutoMapper;
using Common.Models;
using NstuOnline.MessageService.Application.Features.Chats.Search;
using NstuOnline.MessageService.Domain.Entities;
using NstuOnline.MessageService.Domain.Models;

namespace NstuOnline.MessageService.Application.Features.Chats;

public class ChatMapper : Profile
{
    public ChatMapper()
    {
        MapSearch();
    }

    private void MapSearch()
    {
        CreateMap(typeof(PagedList<>), typeof(PagedList<>));
        CreateMap<SearchChatsRequest, SearchChatCriteria>();
        CreateMap<Chat, SearchChatsResponse>();
    }
}