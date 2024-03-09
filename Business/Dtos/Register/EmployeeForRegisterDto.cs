using Core.Utilities.Security.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Register;

public class EmployeeForRegisterDto: UserForRegisterDto
{
    public string Position { get; set; }
}
