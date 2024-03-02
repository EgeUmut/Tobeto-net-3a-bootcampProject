using Business.Requests.Application;
using Business.Responses.Application;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IApplicationService
{
    public Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
    public Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
    public Task<IResult> DeleteAsync(DeleteApplicationRequest request);
    public Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdApplicationResponse>> GetByIdAsync(GetByIdApplicationRequest request);
    //public Task<IResult> AddTransactionalTest(CreateApplicationRequest request);
}
