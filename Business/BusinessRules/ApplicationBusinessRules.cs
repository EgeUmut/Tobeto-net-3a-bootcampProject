using Business.Abstracts;
using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class ApplicationBusinessRules:BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBlackListService _blackListService;

    public ApplicationBusinessRules(IApplicationRepository applicationRepository, IBlackListService blackListService)
    {
        _applicationRepository = applicationRepository;
        _blackListService = blackListService;
    }


    //Business Rules
    public async Task CheckIfApplicantIsBlackListed(int id)
    {
        var item = await _blackListService.GetByApplicantIdAsync(id);
        if (item.Data != null)
        {
            throw new BusinessException("Applicant is blacklisted!");
        }
    }

    public async Task CheckApplicantApplicationToBootcamp(int applicantId, int bootCampId)
    {
        var item = await _applicationRepository.GetAsync(p => p.ApplicantId == applicantId && p.BootcampId == bootCampId);
        if (item != null)
        {
            throw new BusinessException("Applicant has already applied to this bootcamp");
        }
    }
}
