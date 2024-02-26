using Business.Requests.Applicant;
using Business.Requests.BlackList;
using Business.Requests.User;
using Business.Responses.BlackList;
using Core.Utilities.Results;

namespace Business.Abstracts;

public interface IBlackListService
{
    public Task<IDataResult<CreatedBlackListResponse>> AddAsync(CreateBlackListRequest request);
    public Task<IDataResult<UpdatedBlackListResponse>> UpdateAsync(UpdateBlackListRequest request);
    public Task<IResult> DeleteAsync(DeleteBlackListRequest request);
    public Task<IResult> SoftDeleteAsync(DeleteBlackListRequest request);
    public Task<IDataResult<List<GetAllBlackListResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdBlackListResponse>> GetByIdAsync(int request);
    public Task<IDataResult<GetByIdBlackListResponse>> GetByApplicantIdAsync(int request);
}
