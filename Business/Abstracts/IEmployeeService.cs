using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Employee;
using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IEmployeeService
{
    public Task<CreateEmployeeResponse> AddAsync(CreateEmployeeRequest request);
    public Task<UpdateEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    public Task DeleteAsync(DeleteEmployeeRequest request);
    public Task<List<GetAllEmployeeResponse>> GetAll();
    public Task<GetByIdEmployeeResponse> GetByIdAsync(int id);

}
