using AutoMapper;
using Business.Requests.User;
using Business.Responses.User;
using Core.Utilities.Security.Entities;

namespace Business.Profiles.Users;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, UpdateUserRequest>().ReverseMap();
        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, GetByIdUserRequest>().ReverseMap();

        CreateMap<User, CreateUserResponse>().ReverseMap();
        CreateMap<User, GetAllUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
        CreateMap<User, UpdateUserResponse>().ReverseMap();
    }
}
