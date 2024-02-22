using AutoMapper;
using Business.Requests.Application;
using Business.Requests.ApplicationState;
using Business.Responses.Application;
using Business.Responses.ApplicationState;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.ApplicationStates;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<ApplicationState, CreateApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, UpdateApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, DeleteApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, GetByIdApplicationStateRequest>().ReverseMap();


        CreateMap<ApplicationState, CreateApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, GetByIdApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, UpdateApplicationStateResponse>().ReverseMap();
    }
}
