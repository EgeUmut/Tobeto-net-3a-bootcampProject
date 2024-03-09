using Core.Utilities.Security.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos.Register;

public class InstructorForRegisterDto: UserForRegisterDto
{
    public string CompanyName { get; set; }
}
