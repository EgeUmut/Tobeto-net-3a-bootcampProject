using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.User;
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

    public Employeemanager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request)
    {
        Employee applicant = new Employee();
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.Email = request.Email;
        applicant.Position = request.Position;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.Password = request.Password;
        applicant.DateOfBirth = request.DateOfBirth;

        await _employeeRepository.Add(applicant);
        CreateEmployeeResponse response = new CreateEmployeeResponse();
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.Email = applicant.Email;
        response.Position = applicant.Position;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Password = applicant.Password;
        response.DateOfBirth = applicant.DateOfBirth;
        response.CreateDate = applicant.CreateDate;

        return response;
    }

    public async Task DeleteAsync(DeleteEmployeeRequest request)
    {
        var item = await _employeeRepository.Get(p => p.Id == request.Id);
        if (item != null)
        {
            await _employeeRepository.Delete(item);
        }
    }

    public async Task<List<GetAllEmployeeResponse>> GetAll()
    {
        var list = await _employeeRepository.GetAll();
        var responseList = new List<GetAllEmployeeResponse>();

        foreach (var item in list)
        {
            GetAllEmployeeResponse response = new GetAllEmployeeResponse();
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.Position = item.Position;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
            responseList.Add(response);
        }

        return responseList;
    }

    public async Task<GetByIdEmployeeResponse> GetByIdAsync(int id)
    {
        var item = await _employeeRepository.Get(p => p.Id == id);
        GetByIdEmployeeResponse response = new GetByIdEmployeeResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.Position = item.Position;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }
        return response;
    }

    public async Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        var item = await _employeeRepository.Get(p => p.Id == request.Id);
        UpdateEmployeeResponse response = new UpdateEmployeeResponse();
        if (item != null)
        {
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.Email = request.Email;
            item.Position = request.Position;
            item.NationalIdentity = request.NationalIdentity;
            item.Password = request.Password;
            item.DateOfBirth = request.DateOfBirth;
            await _employeeRepository.Update(item);


            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.Position = item.Position;
            response.Password = item.Password;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }

        return response;
    }
}
