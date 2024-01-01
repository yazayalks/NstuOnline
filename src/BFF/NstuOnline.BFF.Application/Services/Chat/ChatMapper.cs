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
        CreateMap<SearchChatRequest, ApiModel.SearchChatRequest>();
        CreateMap<ApiModel.SearchChatResponse, SearchChatResponse>();
        CreateMap<ApiModel.SearchChatLastMessageResponse, SearchChatLastMessageResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateChatRequest, ApiModel.CreateChatRequest>();
    }
}