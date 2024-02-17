using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Requests.User;
using Business.Responses.Applicant;
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

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;

    public ApplicantManager(IApplicantRepository applicantRepository)
    {
        _applicantRepository = applicantRepository;
    }

    public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
    {
        Applicant applicant = new Applicant();
        applicant.FirstName = request.FirstName;
        applicant.LastName = request.LastName;
        applicant.Email = request.Email;
        applicant.About = request.About;
        applicant.NationalIdentity = request.NationalIdentity;
        applicant.Password = request.Password;
        applicant.DateOfBirth = request.DateOfBirth;

        await _applicantRepository.Add(applicant);
        CreateApplicantResponse response = new CreateApplicantResponse();
        response.FirstName = applicant.FirstName;
        response.LastName = applicant.LastName;
        response.Email = applicant.Email;
        response.About = applicant.About;
        response.NationalIdentity = applicant.NationalIdentity;
        response.Password = applicant.Password;
        response.DateOfBirth = applicant.DateOfBirth;
        response.CreatedDate = applicant.CreateDate;

        return response;
    }

    public async Task DeleteAsync(DeleteApplicantRequest request)
    {
        var item = await _applicantRepository.Get(p => p.Id == request.Id);
        if (item != null)
        {
            await _applicantRepository.Delete(item);
        }
    }

    public async Task<List<GetAllApplicantResponse>> GetAll()
    {
        var list = await _applicantRepository.GetAll();
        var responseList = new List<GetAllApplicantResponse>();

        foreach (var item in list)
        {
            GetAllApplicantResponse response = new GetAllApplicantResponse();
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.About = item.About;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
            responseList.Add(response);
        }

        return responseList;
    }

    public async Task<GetByIdApplicantResponse> GetByIdAsync(int id)
    {
        var item = await _applicantRepository.Get(p => p.Id == id);
        GetByIdApplicantResponse response = new GetByIdApplicantResponse();
        if (item != null)
        {
            response.Id = item.Id;
            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.About = item.About;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }
        return response;
    }

    public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
    {
        var item = await _applicantRepository.Get(p => p.Id == request.Id);
        UpdateApplicantResponse response = new UpdateApplicantResponse();
        if (item != null)
        {
            item.Id = request.Id;
            item.FirstName = request.FirstName;
            item.LastName = request.LastName;
            item.Email = request.Email;
            item.About = request.About;
            item.NationalIdentity = request.NationalIdentity;
            item.Password = request.Password;
            item.DateOfBirth = request.DateOfBirth;
            await _applicantRepository.Update(item);


            response.FirstName = item.FirstName;
            response.LastName = item.LastName;
            response.Email = item.Email;
            response.About = item.About;
            response.Password = item.Password;
            response.NationalIdentity = item.NationalIdentity;
            response.DateOfBirth = item.DateOfBirth;
        }

        return response;
    }
}
