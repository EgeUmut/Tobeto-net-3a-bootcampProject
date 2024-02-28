using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.User;

public class GetByIdEmployeeResponse
{
    public int Id { get; set; }
    public string Position { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string NationalIdentity { get; set; }
}
