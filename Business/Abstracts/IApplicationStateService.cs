using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IApplicationStateService
{
    public Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
    public Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
    public Task<IResult> DeleteAsync(DeleteApplicationStateRequest request);
    public Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(GetByIdApplicationStateRequest request);
}
