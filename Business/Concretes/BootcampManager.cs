using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Requests.Bootcamp;
using Business.Responses.Bootcamp;
using Business.Responses.BootcampState;
using Core.Exceptios.Types;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IMapper _mapper;
    private readonly BootcampBusinessRules _bootcampBusinessRules;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules bootcampBusinessRules)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
        _bootcampBusinessRules = bootcampBusinessRules;
    }

    public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
    {
        Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
        bootcamp.ImageUrl = FileHelper.Add(request.file, "Bootcamp");
        await _bootcampRepository.AddAsync(bootcamp);
        return new SuccessDataResult<CreateBootcampResponse>("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
    {
        await _bootcampBusinessRules.CheckBootCampNotExist(request.Id);
        var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id);
        FileHelper.Delete(item.ImageUrl);
        await _bootcampRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");

    }

    public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
    {
        var list = await _bootcampRepository.GetAllAsync(include: x => x.Include(p => p.Instructor).Include(p => p.BootcampState));

        List<GetAllBootcampResponse> responseList = _mapper.Map<List<GetAllBootcampResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(GetByIdBootcampRequest request)
    {
        await _bootcampBusinessRules.CheckBootCampNotExist(request.Id);
        var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id, include: x => x.Include(p => p.Instructor).Include(p => p.BootcampState));
        GetByIdBootcampResponse response = _mapper.Map<GetByIdBootcampResponse>(item);

        return new SuccessDataResult<GetByIdBootcampResponse>(response, "found Succesfuly.");
    }

    public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
    {
        await _bootcampBusinessRules.CheckBootCampNotExist(request.Id);
        var item = await _bootcampRepository.GetAsync(p => p.Id == request.Id);
        _mapper.Map(request, item);
        await _bootcampRepository.UpdateAsync(item);

        UpdateBootcampResponse response = _mapper.Map<UpdateBootcampResponse>(item);
        return new SuccessDataResult<UpdateBootcampResponse>(response, "Bootcamp succesfully updated!");
    }


}
