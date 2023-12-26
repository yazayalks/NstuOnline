using AutoMapper;
using NstuOnline.BFF.Application.Services.Message.Models;
using ApiModel = NstuOnline.MessageService.ApiClientContracts.Models.Messages;

namespace NstuOnline.BFF.Application.Services.Message;

public class MessageMapper : Profile
{
    public MessageMapper()
    {
        MapCreate();
        MapSearch();
    }

    private void MapSearch()
    {
        CreateMap<SearchMessageRequest, ApiModel.SearchMessageRequest>();
        CreateMap<ApiModel.SearchMessageResponse, SearchMessageResponse>();
    }

    private void MapCreate()
    {
        CreateMap<CreateMessageRequest, ApiModel.CreateMessageRequest>();
    }
}