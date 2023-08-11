using AutoMapper;
using Common.Models;

namespace NstuOnline.BFF.Application.Configuration;

public class CommonMapper : Profile
{
    public CommonMapper()
    {
        CreateMap(typeof(PagedList<>), typeof(PagedList<>));
    }
}