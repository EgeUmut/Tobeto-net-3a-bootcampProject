using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Instructor;
using Business.Responses.User;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IInstructorService
{
    public Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request);
    public Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);
    public Task<IResult> DeleteAsync(DeleteInstructorRequest request);
    public Task<IDataResult<List<GetAllInstructorResponse>>> GetAll();
    public Task<IDataResult<GetByIdInstructorResponse>> GetByIdAsync(GetByIdInstructorRequest request);

}
