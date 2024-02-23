using AutoMapper;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.User;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Employees;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeRequest>().ReverseMap();
        CreateMap<Employee, DeleteEmployeeRequest>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeRequest>().ReverseMap();

        CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();
        CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();
        CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();
    }
}
