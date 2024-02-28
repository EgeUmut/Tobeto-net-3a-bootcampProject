﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Applicant;

public class UpdateApplicantResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string About { get; set; }
    public string CompanyName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string NationalIdentity { get; set; }
    public string Password { get; set; }
}
