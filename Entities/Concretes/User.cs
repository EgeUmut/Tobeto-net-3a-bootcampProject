using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

//[Table("User")]
public class User:BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    //[DisplayName("Email")]
    [EmailAddress]
    public string Email { get; set; }
    //[DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
}
