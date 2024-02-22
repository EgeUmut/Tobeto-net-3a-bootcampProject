using AutoMapper;
using Business.Requests.Application;
using Business.Responses.Application;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Profiles.Applications;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();
        CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
        CreateMap<Application, GetByIdApplicationRequest>().ReverseMap();

        CreateMap<Application, CreateApplicationResponse>().ReverseMap();
        CreateMap<Application, GetAllApplicationResponse>().ReverseMap();
        CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();
        CreateMap<Application, UpdateApplicationResponse>().ReverseMap();
    }
}
