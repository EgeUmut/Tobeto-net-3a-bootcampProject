using Business.Abstracts;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        //Async Services
        //services.AddScoped<IAsyncBrandService, AsyncBrandManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IEmployeeService, Employeemanager>();

        return services;
    }
}
