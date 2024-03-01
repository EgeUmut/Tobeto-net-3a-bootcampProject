using AutoMapper;
using Business.Abstracts;
using Business.BusinessRules;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Employee;
using Business.Responses.Instructor;
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

public class InstructorManager : IInstructorService
{
    private readonly IInstructorRepository _ınstructorRepository;
    private readonly IMapper _mapper;
    private readonly InstructorBusinessRules _ınstructorBusinessRules;

    public InstructorManager(IInstructorRepository ınstructorRepository, IMapper mapper, InstructorBusinessRules ınstructorBusinessRules)
    {
        _ınstructorRepository = ınstructorRepository;
        _mapper = mapper;
        _ınstructorBusinessRules = ınstructorBusinessRules;
    }

    public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
    {
        await _ınstructorBusinessRules.CheckUserNameIfExist(request.UserName, null);

        Instructor user = _mapper.Map<Instructor>(request);
        await _ınstructorRepository.AddAsync(user);
        CreateInstructorResponse response = _mapper.Map<CreateInstructorResponse>(user);

        return new SuccessDataResult<CreateInstructorResponse>(response, "Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
    {
        await _ınstructorBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);

        await _ınstructorRepository.DeleteAsync(item);
        return new SuccessResult("Deleted Succesfuly");
    }

    public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAll()
    {
        var list = await _ınstructorRepository.GetAllAsync();
        List<GetAllInstructorResponse> responselist = _mapper.Map<List<GetAllInstructorResponse>>(list);

        return new SuccessDataResult<List<GetAllInstructorResponse>>(responselist, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(GetByIdInstructorRequest request)
    {
        await _ınstructorBusinessRules.CheckIfIdNotExist(request.Id);

        var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);

        GetByIdInstructorResponse response = _mapper.Map<GetByIdInstructorResponse>(item);
        return new SuccessDataResult<GetByIdInstructorResponse>(response, "found Succesfuly.");
    }

    public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
    {
        await _ınstructorBusinessRules.CheckIfIdNotExist(request.Id);
        await _ınstructorBusinessRules.CheckUserNameIfExist(request.UserName, request.Id);

        var item = await _ınstructorRepository.GetAsync(p => p.Id == request.Id);

        _mapper.Map(request, item);
        await _ınstructorRepository.UpdateAsync(item);
        UpdateInstructorResponse response = _mapper.Map<UpdateInstructorResponse>(item);

        return new SuccessDataResult<UpdateInstructorResponse>(response, "User succesfully updated!");
    }
}
