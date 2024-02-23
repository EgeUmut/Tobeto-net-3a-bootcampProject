using AutoMapper;
using Business.Requests.Applicant;
using Business.Requests.Application;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Application;
using Business.Responses.User;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Applicants;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantRequest>().ReverseMap();

        CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();
    }
}
