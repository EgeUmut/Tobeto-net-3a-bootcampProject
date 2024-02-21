using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Bootcamp;

public class GetAllBootcampResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BootcampStateName { get; set; }
}
