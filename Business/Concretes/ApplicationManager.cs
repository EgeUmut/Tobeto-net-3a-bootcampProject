using AutoMapper;
using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
using Core.Exceptios.Types;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;
    private readonly IBlackListService _blackListService;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, IBlackListService blackListService)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
        _blackListService = blackListService;
    }

    public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
    {
        await CheckIfApplicantIsBlackListed(request.ApplicantId);

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

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
        List<GetAllApplicationResponse> responseList = _mapper.Map<List<GetAllApplicationResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(GetByIdApplicationRequest request)
    {
        var item = await _applicationRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
        //var item = list.Where(p => p.Id == request.Id).FirstOrDefault();
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicationResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdApplicationResponse>("Application could not be found.");
    }

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

    //Business Rules
    public async Task CheckIfApplicantIsBlackListed(int id)
    {
        var item = await _blackListService.GetByApplicantIdAsync(id);
        if (item != null)
        {
            throw new BusinessException("Applicant is blacklisted");
        }
    }
}
