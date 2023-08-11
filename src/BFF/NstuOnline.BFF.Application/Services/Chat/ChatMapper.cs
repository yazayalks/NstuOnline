using AutoMapper;
using NstuOnline.BFF.Application.Services.Chat.Models;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.Chats;

namespace NstuOnline.BFF.Application.Services.Chat;

public class ChatMapper : Profile
{
    public ChatMapper()
    {
        MapCreate();
        MapSearch();
    }

    private void MapSearch()
    {
        CreateMap<SearchChatsRequest, ApiModel.SearchChatsRequest>();
        CreateMap<ApiModel.SearchChatsResponse, SearchChatsResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateChatRequest, ApiModel.CreateChatRequest>();
    }
}