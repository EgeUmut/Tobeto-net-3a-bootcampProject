using Business.Requests.Instructor;
using Business.Requests.User;
using Business.Responses.Instructor;
using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface IInstructorService
{
    public Task<CreateInstructorResponse> AddAsync(CreateInstructorRequest request);
    public Task<UpdateInstructorResponse> UpdateAsync(UpdateInstructorRequest request);
    public Task DeleteAsync(DeleteInstructorRequest request);
    public Task<List<GetAllInstructorResponse>> GetAll();
    public Task<GetByIdInstructorResponse> GetByIdAsync(int id);

}
