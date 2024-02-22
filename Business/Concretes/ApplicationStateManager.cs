using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationState;
using Business.Responses.Application;
using Business.Responses.ApplicationState;
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

public class ApplicationStateManager : IApplicationStateService
{
    private readonly IApplicationStateRepository _applicantStateRepository;
    private readonly IMapper _mapper;

    public ApplicationStateManager(IApplicationStateRepository applicantStateRepository, IMapper mapper)
    {
        _applicantStateRepository = applicantStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
    {
        ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
        await _applicantStateRepository.AddAsync(applicationState);
        return new SuccessDataResult<CreateApplicationStateResponse>("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
    {
        var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _applicantStateRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }

        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
    {
        var list = await _applicantStateRepository.GetAllAsync();
        List<GetAllApplicationStateResponse> responseList = _mapper.Map<List<GetAllApplicationStateResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationStateResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(GetByIdApplicationStateRequest request)
    {
        var item = await _applicantStateRepository.GetAsync(p=>p.Id == request.Id);
        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdApplicationStateResponse>("ApplicationState could not be found.");
    }

    public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
    {
        var item = await _applicantStateRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdateApplicationStateResponse>("ApplicationState could not be found.");
        }

        _mapper.Map(request, item);
        await _applicantStateRepository.UpdateAsync(item);

        UpdateApplicationStateResponse response = _mapper.Map<UpdateApplicationStateResponse>(item);
        return new SuccessDataResult<UpdateApplicationStateResponse>(response, "ApplicationState succesfully updated!");
    }
}
