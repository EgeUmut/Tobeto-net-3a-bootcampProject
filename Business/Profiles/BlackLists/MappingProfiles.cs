using AutoMapper;
using Business.Requests.BlackList;
using Business.Responses.BlackList;
using Entities.Concretes;

namespace Business.Profiles.BlackLists;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<BlackList, CreateBlackListRequest>().ReverseMap();
        CreateMap<BlackList, UpdateBlackListRequest>().ReverseMap();
        CreateMap<BlackList, DeleteBlackListRequest>().ReverseMap();
        //CreateMap<BlackList, GetByIdBlackListRequest>().ReverseMap();

        CreateMap<BlackList, CreatedBlackListResponse>().ReverseMap();
        CreateMap<BlackList, GetAllBlackListResponse>().ReverseMap();
        CreateMap<BlackList, GetByIdBlackListResponse>().ReverseMap();
        CreateMap<BlackList, UpdatedBlackListResponse>().ReverseMap();
    }
}
