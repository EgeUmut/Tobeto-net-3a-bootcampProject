using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using Core.Helpers;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class ApplicantBusinessRules: BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantBusinessRules(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }



    //Business Rules
    public async Task CheckUserNameIfExist(string userName, int? id)
    {
        //var item = await _applicantRepository.GetAsync(p => p.UserName == SeoHelper.ToSeoUrl(userName));
        var item = await _applicantRepository.GetAsync(p => p.UserName == SeoHelper.ToSeoUrl(userName) && p.Id != id);
        if (item != null)
        {
            throw new ValidationException("UserName already exist");
        }
    }

    public async Task CheckIfIdNotExist(int id)
    {
        var item = await _applicantRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new NotFoundException("Object could not be found.");
        }
    }
}
