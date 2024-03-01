using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using Core.Helpers;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class InstructorBusinessRules: BaseBusinessRules
{
    private readonly IInstructorRepository _ınstructorRepository;

    public InstructorBusinessRules(IInstructorRepository ınstructorRepository)
    {
        _ınstructorRepository = ınstructorRepository;
    }

    //Business Rules

    public async Task CheckUserNameIfExist(string userName, int? id)
    {
        //var item = await _ınstructorRepository.GetAsync(p => p.UserName == SeoHelper.ToSeoUrl(userName));
        var item = await _ınstructorRepository.GetAsync(p => p.UserName == SeoHelper.ToSeoUrl(userName) && p.Id != id);
        if (item != null)
        {
            throw new ValidationException("UserName already exist");
        }
    }

    public async Task CheckIfIdNotExist(int id)
    {
        var item = await _ınstructorRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new NotFoundException("Object could not be found.");
        }
    }
}
