using AutoMapper;
using Business.Requests.BlackList;
using Business.Requests.Bootcamp;
using Business.Responses.BlackList;
using Business.Responses.Bootcamp;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
