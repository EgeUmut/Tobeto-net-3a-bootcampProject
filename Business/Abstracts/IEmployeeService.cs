using Business.Requests.Employee;
using Business.Requests.User;
using Business.Responses.Employee;
using Business.Responses.User;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IEmployeeService
{
    public Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
    public Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
    public Task<IResult> DeleteAsync(DeleteEmployeeRequest request);
    public Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdEmployeeResponse>> GetByIdAsync(GetByIdEmployeeRequest request);

}
