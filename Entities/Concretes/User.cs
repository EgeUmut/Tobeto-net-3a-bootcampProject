using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class User:BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
}
