using AutoMapper;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using Business.Responses.User;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Instructors;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorRequest>().ReverseMap();

        CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();
    }
}
