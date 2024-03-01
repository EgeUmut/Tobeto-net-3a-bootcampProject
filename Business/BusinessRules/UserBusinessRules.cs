using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using Core.Helpers;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;

namespace Business.BusinessRules;

public class UserBusinessRules: BaseBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //Business Rules

    public async Task CheckUserNameIfExist(string userName, int? id)
    {
        if (id == null)
        {
            var item = await _userRepository.GetAsync(p => p.UserName == userName);
            if (item != null)
            {
                throw new ValidationException("UserName already exist");
            }
        }
        else
        {
            var item = await _userRepository.GetAsync(p => p.UserName == userName && p.Id != id);
            if (item != null)
            {
                throw new ValidationException("UserName already exist");
            }
        }
    }

    public async Task CheckIfIdNotExist(int id)
    {
        var item = await _userRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new NotFoundException("Object could not be found.");
        }
    }
}
