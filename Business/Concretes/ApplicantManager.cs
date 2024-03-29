﻿using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.User;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
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
    private readonly ApplicantBusinessRules _applicantBusinessRules;

    public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules applicantBusinessRules)
    {
        _applicantRepository = applicantRepository;
        _mapper = mapper;
        _applicantBusinessRules = applicantBusinessRules;
    }

    [LogAspect(typeof(MssqlLogger))]
    [CacheRemoveAspect("IApplicantService.Get")]
    public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
    {
        await _applicantBusinessRules.CheckUserNameIfExist(request.UserName, null);

        Applicant applicant = _mapper.Map<Applicant>(request);
        applicant.PasswordSalt = new byte[10];
        applicant.PasswordHash = new byte[10];
        await _applicantRepository.AddAsync(applicant);
        CreateApplicantResponse response = _mapper.Map<CreateApplicantResponse>(applicant);
        return new SuccessDataResult<CreateApplicantResponse>(response, "Added Succesfuly");
    }

    [LogAspect(typeof(MssqlLogger))]
    [CacheRemoveAspect("IApplicantService.Get")]
    public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
    {
        //Business Rules
        await _applicantBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        await _applicantRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");
    }

    [LogAspect(typeof(MssqlLogger))]
    [CacheAspect]
    public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
    {
        var list = await _applicantRepository.GetAllAsync();
        List<GetAllApplicantResponse> responselist = _mapper.Map<List<GetAllApplicantResponse>>(list);

        return new SuccessDataResult<List<GetAllApplicantResponse>>(responselist, "Listed Succesfully.");
    }

    [LogAspect(typeof(MssqlLogger))]
    public async Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(GetByIdApplicantRequest request)
    {
        await _applicantBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        GetByIdApplicantResponse response = _mapper.Map<GetByIdApplicantResponse>(item);
        return new SuccessDataResult<GetByIdApplicantResponse>(response, "found Succesfully.");

    }

    [LogAspect(typeof(MssqlLogger))]
    [CacheRemoveAspect("IApplicantService.Get")]
    public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
    {
        //Validation Check
        await _applicantBusinessRules.CheckIfIdNotExist(request.Id);
        await _applicantBusinessRules.CheckUserNameIfExist(request.UserName,request.Id);

        var item = await _applicantRepository.GetAsync(p => p.Id == request.Id);
        _mapper.Map(request, item);
        await _applicantRepository.UpdateAsync(item);
        UpdateApplicantResponse response = _mapper.Map<UpdateApplicantResponse>(item);

        return new SuccessDataResult<UpdateApplicantResponse>(response, "Applicant succesfully updated!");
    }
}
