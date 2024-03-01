using Core.CrossCuttingConcerns;
using Core.Exceptios.Types;
using Core.Helpers;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules;

public class EmployeeBusinessRules : BaseBusinessRules
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }


    //Business Rules

    public async Task CheckUserNameIfExist(string userName, int? id)
    {
        if (id == null)
        {
            var item = await _employeeRepository.GetAsync(p => p.UserName == userName);
            if (item != null)
            {
                throw new ValidationException("UserName already exist");
            }
        }
        else
        {
            var item = await _employeeRepository.GetAsync(p => p.UserName == userName && p.Id != id);
            if (item != null)
            {
                throw new ValidationException("UserName already exist");
            }
        }
    }

    public async Task CheckIfIdNotExist(int id)
    {
        var item = await _employeeRepository.GetAsync(p => p.Id == id);
        if (item == null)
        {
            throw new NotFoundException("Object could not be found.");
        }
    }
}
