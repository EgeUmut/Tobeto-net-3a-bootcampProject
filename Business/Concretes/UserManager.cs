using Business.Abstracts;
using Business.Requests.User;
using Business.Responses.User;
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

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> AddAsync(CreateUserRequest request)
    {
        User user = new User();
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.NationalIdentity = request.NationalIdentity;
        user.Password = request.Password;
        user.DateOfBirth = request.DateOfBirth;

        await _userRepository.Add(user);
        CreateUserResponse response = new CreateUserResponse();
        response.FirstName = user.FirstName;
        response.LastName = user.LastName;
        response.Email = user.Email;
        response.NationalIdentity = user.NationalIdentity;
        response.Password = user.Password;
        response.DateOfBirth = user.DateOfBirth;
        response.CreatedDate = user.CreateDate;

        return response;
    }

    public async Task DeleteAsync(DeleteUserRequest request)
    {
        var item = await _userRepository.Get(p => p.Id == request.Id);
        if (item != null)
        {
            await _userRepository.Delete(item);
        }
    }

    public async Task<List<GetAllUserResponse>> GetAll()
    {

        var list = await _userRepository.GetAll();
        var responseList = new List<GetAllUserResponse>();

        foreach (var item in list)
        {
            GetAllUserResponse response = new GetAllUserResponse();
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
            responseList.Add(response);
        }

        return responseList;
    }

    public async Task<GetByIdUserResponse> GetByIdAsync(int id)
    {
        var item = await _userRepository.Get(p => p.Id == id);
        GetByIdUserResponse response = new GetByIdUserResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }
        return response;
    }

    public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        var item = await _userRepository.Get(p => p.Id == request.Id);
        UpdateUserResponse response = new UpdateUserResponse();
        if (item != null)
        {
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.Email = request.Email;
            item.NationalIdentity = request.NationalIdentity;
            item.Password = request.Password;
            item.DateOfBirth = request.DateOfBirth;
            await _userRepository.Update(item);


            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.Password = item.Password;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }

        return response;
    }
}
