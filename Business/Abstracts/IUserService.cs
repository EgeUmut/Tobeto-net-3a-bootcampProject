using Business.Requests.User;
using Business.Responses.User;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    public Task<CreateUserResponse> AddAsync(CreateUserRequest request);
    public Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request);
    public Task DeleteAsync(DeleteUserRequest request);
    public Task<List<GetAllUserResponse>> GetAll();
    public Task<GetByIdUserResponse> GetByIdAsync(int id);

}
