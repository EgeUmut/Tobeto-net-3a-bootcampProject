using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules;

public class BootcampBusinessRules: BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository)
    {
        _bootcampRepository = bootcampRepository;
    }

    public async Task CheckBootCampNotExist(int id)
    {
        var item = await _bootcampRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new BusinessException("Bootcamp could not be found");
        }
    }
}
