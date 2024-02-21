using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Application;

public class GetAllApplicationResponse
{
    public int Id { get; set; }
    public int ApplicantName { get; set; }
    public int BootcampName { get; set; }
    public int ApplicationStateName { get; set; }

}
