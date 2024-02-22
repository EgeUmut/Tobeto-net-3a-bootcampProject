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
        Applicant applicant = _mapper.Map<Applicant>(request);
        await _applicantRepository.AddAsync(applicant);
        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);

        return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _applicantRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }
        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {

        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> responselist = _mapper.Map<List<GetAllApplicantResponse>>(list);

        return new SuccessDataResult<List<GetAllApplicantResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(GetByIdApplicantRequest request)
    {
        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);
            return new SuccessDataResult<GetByIdApplicantResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdApplicantResponse>("Applicant could not be found.");
    }

    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);

        if (item != null)
        {
            _mapper.Map(request, item);
            await _applicantRepository.UpdateAsync(item);
            UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(item);

            return new SuccessDataResult<UpdateApplicantResponse>(response, "Applicant succesfully updated!");
        }

        return new ErrorDataResult<UpdateApplicantResponse>("Applicant could not be found.");
    }
}
