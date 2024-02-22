using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampState;
using Business.Responses.ApplicationState;
using Business.Responses.BootcampState;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BootcampStateManager:IBootcampStateService
{
    private readonly IBootcampStateRepository _bootcampStateRepository;
    private readonly IMapper _mapper;

    public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
    {
        _bootcampStateRepository = bootcampStateRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
    {
        BootcampState bootcampState = _mapper.Map<BootcampState>(request);
        await _bootcampStateRepository.AddAsync(bootcampState);
        return new SuccessDataResult<CreateBootcampStateResponse>("Added Succesfuly");
    }

    public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
    {
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        if (item != null)
        {
            await _bootcampStateRepository.DeleteAsync(item);
            return new SuccessResult("Deleted Succesfuly");
        }

        return new ErrorResult("Delete Failed!");
    }

    public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
    {
        var list = await _bootcampStateRepository.GetAllAsync();
        List<GetAllBootcampStateResponse> responseList = _mapper.Map<List<GetAllBootcampStateResponse>>(list);
        return new SuccessDataResult<List<GetAllBootcampStateResponse>>(responseList, "Listed Succesfuly.");
    }

    public async Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(GetByIdBootcampStateRequest request)
    {
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        GetByIdBootcampStateResponse response = _mapper.Map<GetByIdBootcampStateResponse>(item);

        if (item != null)
        {
            return new SuccessDataResult<GetByIdBootcampStateResponse>(response, "found Succesfuly.");
        }
        return new ErrorDataResult<GetByIdBootcampStateResponse>("BootcampState could not be found.");
    }

    public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
    {
        var item = await _bootcampStateRepository.GetAsync(p => p.Id == request.Id);
        if (request.Id == 0 || item == null)
        {
            return new ErrorDataResult<UpdateBootcampStateResponse>("BootcampState could not be found.");
        }

        _mapper.Map(request, item);
        await _bootcampStateRepository.UpdateAsync(item);

        UpdateBootcampStateResponse response = _mapper.Map<UpdateBootcampStateResponse>(item);
        return new SuccessDataResult<UpdateBootcampStateResponse>(response, "BootcampState succesfully updated!");
    }
}
