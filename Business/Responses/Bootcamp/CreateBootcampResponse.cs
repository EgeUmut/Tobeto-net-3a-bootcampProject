using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Bootcamp;

public class CreateBootcampResponse
{
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public string InstructorName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BootcampStateId { get; set; }
    public string BootcampStateName { get; set; }
}
