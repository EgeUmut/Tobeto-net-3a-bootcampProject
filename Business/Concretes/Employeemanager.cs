using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.User;
using Core.Exceptios.Types;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class Employeemanager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly EmployeeBusinessRules _employeeBusinessRules;

    public Employeemanager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _employeeBusinessRules = employeeBusinessRules;
    }

    public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        await _employeeBusinessRules.CheckUserNameIfExist(request.UserName , null);

        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);
        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

        return new SuccessDataResult<CreateEmployeeResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
    {
        await _employeeBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

        await _employeeRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {

        var list = await _employeeRepository.GetAllAsync();
        List<GetAllEmployeeResponse> responselist = _mapper.Map<List<GetAllEmployeeResponse>>(list);

        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(GetByIdEmployeeRequest request)
    {
        await _employeeBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

        GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(item);
        return new SuccessDataResult<GetByIdEmployeeResponse>(response, "found Succesfuly.");
    }

    public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        await _employeeBusinessRules.CheckIfIdNotExist(request.Id);
        await _employeeBusinessRules.CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _employeeRepository.UpdateAsync(item);
        UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(item);

        return new SuccessDataResult<UpdateEmployeeResponse>(response, "Employee succesfully updated!");
    }
}
