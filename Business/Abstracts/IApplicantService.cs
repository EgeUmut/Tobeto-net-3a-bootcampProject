using Business.Requests.Applicant;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.User;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IApplicantService
{
    public Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
    public Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
    public Task<IResult> DeleteAsync(DeleteApplicantRequest request);
    public Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
    public Task<IDataResult<GetByIdApplicantResponse>> GetByIdAsync(GetByIdApplicantRequest request);

}
