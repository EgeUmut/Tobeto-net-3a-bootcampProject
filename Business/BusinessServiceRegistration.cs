using Business.Abstracts;
using Business.Concretes;
using Core.CrossCuttingConcerns;
using Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Services
        services.RegisterAssemblyTypes(assembly).Where(p => p.ServiceType.Name.EndsWith("Manager"));

        //services.AddScoped<IUserService, UserManager>();
        //services.AddScoped<IInstructorService, InstructorManager>();
        //services.AddScoped<IApplicantService, ApplicantManager>();
        //services.AddScoped<IEmployeeService, Employeemanager>();

        //services.AddScoped<IApplicationService, ApplicationManager>();
        //services.AddScoped<IApplicationStateService, ApplicationStateManager>();
        //services.AddScoped<IBootcampService, BootcampManager>();
        //services.AddScoped<IBootcampStateService, BootcampStateManager>();

        //services.AddScoped<IBlackListService, BlackListManager>();


        //Business Rules
        services.AddSubClassesOfType(assembly, typeof(BaseBusinessRules));

        return services;
    }
}
