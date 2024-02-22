using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Requests.User;
using Business.Responses.Application;
using Business.Responses.User;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateUserResponse>> AddAsync(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        await _userRepository.AddAsync(user);
        CreateUserResponse response = _mapper.Map<CreateUserResponse>(user);

        return new SuccessDataResult<CreateUserResponse>(response,"Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteUserRequest request)
    {
        var item = await _userRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _userRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }
        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
    {

        var list = await _userRepository.GetAllAsync();
        List<GetAllUserResponse> responselist = _mapper.Map<List<GetAllUserResponse>>(list);

        return new SuccessDataResult<List<GetAllUserResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(GetByIdUserRequest request)
    {
        var item = await _userRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(item);
            return new SuccessDataResult<GetByIdUserResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdUserResponse>("User could not be found.");
    }

    public async Task<IDataResult<UpdateUserResponse>> UpdateAsync(UpdateUserRequest request)
    {
        var item = await _userRepository.GetAsync(p => p.Id == request.Id);
        
        if (item != null)
        {
            _mapper.Map(request, item);
            await _userRepository.UpdateAsync(item);
            UpdateUserResponse response = _mapper.Map<UpdateUserResponse>(item);

            return new SuccessDataResult<UpdateUserResponse>(response, "User succesfully updated!");
        }

        return new ErrorDataResult<UpdateUserResponse>("User could not be found.");
    }
}
