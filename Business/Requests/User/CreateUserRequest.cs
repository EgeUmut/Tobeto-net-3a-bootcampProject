﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.User;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string NationalIdentity { get; set; }
    public string Password { get; set; }
}
