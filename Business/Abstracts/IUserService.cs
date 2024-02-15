using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IUserService
{
    public Task Add(User user);
    public Task Update(User user);
    public Task Delete(User user);
    public Task<List<User>> GetAll();
    public Task<User> Get(int id);

}
