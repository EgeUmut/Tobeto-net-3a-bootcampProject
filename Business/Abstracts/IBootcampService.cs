using Business.Requests.Bootcamp;
using Business.Responses.Bootcamp;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBootcampService
{
    public Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request);
    public Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
    public Task<IResult> DeleteAsync(DeleteBootcampRequest request);
    public Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdBootcampResponse>> GetByIdAsync(GetByIdBootcampRequest request);
}
