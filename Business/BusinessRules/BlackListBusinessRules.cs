using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using DataAccess.Abstracts;

namespace Business.BusinessRules;

public class BlackListBusinessRules: BaseBusinessRules
{
    private readonly IBlackListRepository _blackListRepository;

    public BlackListBusinessRules(IBlackListRepository blackListRepository)
    {
        _blackListRepository = blackListRepository;
    }

    public async Task CheckBlackListNotExist(int id)
    {
        var item = await _blackListRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new BusinessException("BlackList could not be found");
        }
    }
}
