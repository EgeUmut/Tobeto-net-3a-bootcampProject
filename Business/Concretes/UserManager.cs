using Business.Abstracts;
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

    public async Task Add(User user)
    {
        await _userRepository.Add(user);
    }

    public async Task Delete(User user)
    {
        await _userRepository.Delete(user);
    }

    public async Task<User> Get(int id)
    {
        return await _userRepository.Get(u => u.Id == id);
    }

    public async Task<List<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task Update(User user)
    {
        await _userRepository.Update(user);
    }
}
