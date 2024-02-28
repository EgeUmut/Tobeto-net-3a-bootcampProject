using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Requests.BlackList;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.BlackList;
using Business.Responses.User;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BlackListManager : IBlackListService
{
    private readonly IBlackListRepository _blackListRepository;
    private readonly IMapper _mapper;

    public BlackListManager(IBlackListRepository blackListRepository, IMapper mapper)
    {
        _blackListRepository = blackListRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreatedBlackListResponse>> AddAsync(CreateBlackListRequest request)
    {
        BlackList blackList = _mapper.Map<BlackList>(request);

        await _blackListRepository.AddAsync(blackList);


        CreatedBlackListResponse response = _mapper.Map<CreatedBlackListResponse>(blackList);

        return new SuccessDataResult<CreatedBlackListResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteBlackListRequest request)
    {
        var item = await _blackListRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _blackListRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }
        return new ErrorResult("Delete Failed!");
    }

    public async Task<IResult> SoftDeleteAsync(DeleteBlackListRequest request)
    {
        var item = await _blackListRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _blackListRepository.SoftDeleteAsync(item);
            return new SuccessResult("SoftDeleted Succesfuly");
        }
        return new ErrorResult("SoftDelete Failed!");
    }

    public async Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync()
    {
        var list = await _blackListRepository.GetAllAsync(p => p.IsDeleted != true, include: p => p.Include(p => p.Applicant));
        List<GetAllBlackListResponse> responselist = _mapper.Map<List<GetAllBlackListResponse>>(list);

        return new SuccessDataResult<List<GetAllBlackListResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int request)
    {
        var item = await _blackListRepository.GetAsync(predicate: p => p.IsDeleted != true && p.Id == request, include: x => x.Include(p => p.Applicant));
        if (item != null)
        {
            GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(item);
            return new SuccessDataResult<GetByIdBlackListResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdBlackListResponse>("BlackList could not be found.");
    }

    public async Task<IDataResult<GetByIdBlackListResponse>> GetByApplicantIdAsync(int request)
    {
        var item = await _blackListRepository.GetAsync(predicate: p => p.IsDeleted != true && p.ApplicantId == request, include: x => x.Include(p => p.Applicant));
        if (item != null)
        {
            GetByIdBlackListResponse response = _mapper.Map<GetByIdBlackListResponse>(item);
            return new SuccessDataResult<GetByIdBlackListResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdBlackListResponse>("BlackListed applicant could not be found.");
    }

    public async Task<IDataResult<UpdatedBlackListResponse>> UpdateAsync(UpdateBlackListRequest request)
    {
        var item = await _blackListRepository.GetAsync(p => p.Id == request.Id);

        if (item != null)
        {
            _mapper.Map(request, item);
            await _blackListRepository.UpdateAsync(item);
            UpdatedBlackListResponse response = _mapper.Map<UpdatedBlackListResponse>(item);

            return new SuccessDataResult<UpdatedBlackListResponse>(response, "BlackList succesfully updated!");
        }

        return new ErrorDataResult<UpdatedBlackListResponse>("BlackList could not be found.");
    }
}
