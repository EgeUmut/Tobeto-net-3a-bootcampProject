﻿using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Bootcamp : BaseEntity<int>
{
    public Bootcamp()
    {
        Applications = new HashSet<Application>();
    }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BootcampStateId { get; set; }
    public BootcampState BootcampState { get; set; }
    public ICollection<Application> Applications { get; set; }
    public string ImageUrl { get; set; }
}
