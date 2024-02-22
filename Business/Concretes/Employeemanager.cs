using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.User;
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

public class Employeemanager:IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public Employeemanager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
    {
        Employee employee = _mapper.Map<Employee>(request);
        await _employeeRepository.AddAsync(employee);
        CreateEmployeeResponse response = _mapper.Map<CreateEmployeeResponse>(employee);

        return new SuccessDataResult<CreateEmployeeResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
    {
        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _employeeRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }
        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
    {

        var list = await _employeeRepository.GetAllAsync();
        List<GetAllEmployeeResponse> responselist = _mapper.Map<List<GetAllEmployeeResponse>>(list);

        return new SuccessDataResult<List<GetAllEmployeeResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(GetByIdEmployeeRequest request)
    {
        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            GetByIdEmployeeResponse response = _mapper.Map<GetByIdEmployeeResponse>(item);
            return new SuccessDataResult<GetByIdEmployeeResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdEmployeeResponse>("Employee could not be found.");
    }

    public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
    {
        var item = await _employeeRepository.GetAsync(p => p.Id == request.Id);

        if (item != null)
        {
            _mapper.Map(request, item);
            await _employeeRepository.UpdateAsync(item);
            UpdateEmployeeResponse response = _mapper.Map<UpdateEmployeeResponse>(item);

            return new SuccessDataResult<UpdateEmployeeResponse>(response, "Employee succesfully updated!");
        }

        return new ErrorDataResult<UpdateEmployeeResponse>("Employee could not be found.");
    }
}
