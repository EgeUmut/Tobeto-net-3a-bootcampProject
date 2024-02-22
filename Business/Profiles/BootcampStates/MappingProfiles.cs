using AutoMapper;
using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
using Entities.Concretes;

namespace Business.Profiles.BootcampStates;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<BootcampState, CreateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateRequest>().ReverseMap();

        CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();
    }
}
