using Business.Requests.User;
using Business.Responses.User;
using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    public Task<IDataResult<CreateUserResponse>> AddAsync(CreateUserRequest request);
    public Task<IDataResult<UpdateUserResponse>> UpdateAsync(UpdateUserRequest request);
    public Task<IResult> DeleteAsync(DeleteUserRequest request);
    public Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdUserResponse>> GetByIdAsync(GetByIdUserRequest request);

}
