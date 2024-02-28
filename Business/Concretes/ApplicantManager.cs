using AutoMapper;
using Business.Abstracts;
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

public class ApplicantManager : IApplicantService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IMapper _mapper;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        await CheckUserNameIfExist(request.UserName);

        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);

        return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        //Business Rules
        await CheckIfIdNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        await _applicantRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> responselist = _mapper.Map<List<GetAllApplicantResponse>>(list);

        return new SuccessDataResult<List<GetAllApplicantResponse>>(responselist, "Listed Succesfully.");
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(GetByIdApplicantRequest request)
    {
        await CheckIfIdNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "found Succesfully.");

    }

    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        //Validation Check
        await CheckIfIdNotExist(request.Id);
        await CheckUserNameIfExist(request.UserName);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        _mapper.Map(request, item);
        await _applicantRepository.UpdateAsync(item);
        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(item);

        return new SuccessDataResult<UpdateApplicantResponse>(response, "Applicant succesfully updated!");
    }

    //
    //
    //Business Rules
    public async Task CheckUserNameIfExist(string userName)
    {
        var item = await _applicantRepository.GetAsync(p => p.UserName == SeoHelper.ToSeoUrl(userName));
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
