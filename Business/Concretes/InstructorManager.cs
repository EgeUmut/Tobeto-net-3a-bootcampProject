using Business.Abstracts;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using Business.Responses.User;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class InstructorManager:IInstructorService
{
    private readonly IInstructorRepository _ınstructorRepository;

    public InstructorManager(IInstructorRepository ınstructorRepository)
    {
        _ınstructorRepository = ınstructorRepository;
    }

    public async Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request)
    {
        Instructor instructor = new Instructor();
        instructor.FirstName = request.FirstName;
        instructor.LastName = request.LastName;
        instructor.Email = request.Email;
        instructor.CompanyName = request.CompanyName;
        instructor.NationalIdentity = request.NationalIdentity;
        instructor.Password = request.Password;
        instructor.DateOfBirth = request.DateOfBirth;

        await _ınstructorRepository.AddAsync(instructor);
        CreateInstructorResponse response = new CreateInstructorResponse();
        response.FirstName = instructor.FirstName;
        response.LastName = instructor.LastName;
        response.Email = instructor.Email;
        response.CompanyName = instructor.CompanyName;
        response.NationalIdentity = instructor.NationalIdentity;
        response.Password = instructor.Password;
        response.DateOfBirth = instructor.DateOfBirth;
        response.CreatedDate = instructor.CreateDate;

        return response;
    }

    public async Task DeleteAsync(DeleteInstructorRequest request)
    {
        var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _ınstructorRepository.DeleteAsync(item);
        }
    }

    public async Task<List<GetAllInstructorResponse>> GetAll()
    {
        var list = await _ınstructorRepository.GetAllAsync();
        var responseList = new List<GetAllInstructorResponse>();

        foreach (var item in list)
        {
            GetAllInstructorResponse response = new GetAllInstructorResponse();
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.CompanyName = item.CompanyName;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
            responseList.Add(response);
        }

        return responseList;
    }

    public async Task<GetByIdInstructorResponse> GetByIdAsync(int id)
    {
        var item = await _ınstructorRepository.GetAsync(p => p.Id == id);
        GetByIdInstructorResponse response = new GetByIdInstructorResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.CompanyName = item.CompanyName;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }
        return response;
    }

    public async Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request)
    {
        var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);
        UpdateInstructorResponse response = new UpdateInstructorResponse();
        if (item != null)
        {
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.Email = request.Email;
            item.CompanyName = request.CompanyName;
            item.NationalIdentity = request.NationalIdentity;
            item.Password = request.Password;
            item.DateOfBirth = request.DateOfBirth;
            await _ınstructorRepository.UpdateAsync(item);


            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.CompanyName = item.CompanyName;
            response.Password = item.Password;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }

        return response;
    }
}
