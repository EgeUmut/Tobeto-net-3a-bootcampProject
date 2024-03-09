using Core.Utilities.Security.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos.Register;

public class ApplicantForRegisterDto: UserForRegisterDto
{
    public string About { get; set; }
}
