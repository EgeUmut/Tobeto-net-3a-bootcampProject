using Business.Requests.Applicant;
using Business.Requests.User;
using Business.Responses.Applicant;
using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IApplicantService
{
    public Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request);
    public Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request);
    public Task DeleteAsync(DeleteApplicantRequest request);
    public Task<List<GetAllApplicantResponse>> GetAll();
    public Task<GetByIdApplicantResponse> GetByIdAsync(int id);

}
