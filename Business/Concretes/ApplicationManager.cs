using AutoMapper;
using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
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

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(CreateApplicationRequest request)
    {
        Application application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);
        return new SuccessResult("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(int request)
    {
        var item = await _applicationRepository.GetAsync(p=>p.Id == request);
        if (item != null)
        {
            await _applicationRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }

        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
    {
        var list = await _applicationRepository.GetAllAsync(include:x=>x.Include(p=>p.Applicant).Include(p=>p.Bootcamp).Include(p=>p.ApplicationState));
        List<GetAllApplicationResponse> responseList = _mapper.Map<List<GetAllApplicationResponse>>(list);
        return new SuccessDataResult<List<GetAllApplicationResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(int id)
    {
        var list = await _applicationRepository.GetAllAsync(include: x => x.Include(p => p.Applicant).Include(p => p.Bootcamp).Include(p => p.ApplicationState));
        var item = list.Where(p=>p.Id==id).FirstOrDefault();
        GetByIdApplicationResponse response = _mapper.Map<GetByIdApplicationResponse>(item);
        if (item != null)
        {
            return new SuccessDataResult<GetByIdApplicationResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdApplicationResponse>("Application could not be found.");
    }

    public Task<UpdateApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
    {
        throw new NotImplementedException();
    }
}
