using AutoMapper;
using Business.Requests.Application;
using Business.Requests.Bootcamp;
using Business.Responses.Application;
using Business.Responses.Bootcamp;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Bootcamps;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();

        CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();
    }
}
