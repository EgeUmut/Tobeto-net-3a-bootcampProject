﻿using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Requests.Application;
using Business.Responses.Application;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationBusinessRules _applicationBusinessRules;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules applicationBusinessRules)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _applicationBusinessRules = applicationBusinessRules;
    }

    //[TransactionScopeAspect]
    //[CacheRemoveAspect("IApplicationService.Get")]
    [LogAspect(typeof(MssqlLogger))]
    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await _applicationBusinessRules.CheckIfApplicantIsBlackListed(request.ApplicantId);
        await _applicationBusinessRules.CheckApplicantApplicationToBootcamp(request.ApplicantId, request.BootcampId);

        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);

        return new SuccessDataResult<CreateApplicationResponse>("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _applicationRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }

        return new ErrorResult("Delete Failed!");
    }

    //[CacheAspect]
    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
        List<GetAllApplicationResponse> responseList = _mapper.Map<List<GetAllApplicationResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responseList, "Listed Succesfully.");
    }

    //[CacheAspect]
    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(GetByIdApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
        //var item = list.Where(p => p.Id == request.Id).FirstOrDefault();
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicationResponse>(response, "found Succesfully.");
        }
        return new ErrorDataResult<GetByIdApplicationResponse>("Application could not be found.");
    }

    //[CacheRemoveAspect("IApplicationService.Get")]
    public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp));
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdateApplicationResponse>("Application could not be found.");
        }

        _mapper.Map(request, item);
        await _applicationRepository.UpdateAsync(item);

        UpdateApplicationResponse response = _mapper.Map<UpdateApplicationResponse>(item);
        return new SuccessDataResult<UpdateApplicationResponse>(response, "Application succesfully updated!");

    }
}
