using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
using Core.Utilities.Results;
namespace Business.Abstracts;

public interface IBootcampStateService
{
    public Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
    public Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
    public Task<IResult> DeleteAsync(DeleteBootcampStateRequest request);
    public Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdBootcampStateResponse>> GetByIdAsync(GetByIdBootcampStateRequest request);
}
