using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Application;

public class CreateApplicationResponse
{
    public string ApplicantFirstName { get; set; }
    public string ApplicantLastName { get; set; }
    public string BootcampName { get; set; }
    public string ApplicationStateName { get; set; }
}
