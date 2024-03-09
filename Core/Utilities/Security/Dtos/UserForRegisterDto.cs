using System.ComponentModel.DataAnnotations;

namespace Core.Utilities.Security.Dtos;

public class UserForRegisterDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string NationalIdentity { get; set; }
    public string Password { get; set; }
    //public byte[] PasswordHash { get; set; }
    //public byte[] PasswordSalt { get; set; }
}
