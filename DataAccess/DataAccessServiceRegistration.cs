﻿using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using DataAccess.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TobetoBootCampProjectContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        var assembly = Assembly.GetExecutingAssembly();


        //Repositories
        services.RegisterAssemblyTypes(assembly).Where(p => p.ServiceType.Name.EndsWith("Repository"));

        //services.AddScoped<IUserRepository, UserRepository>();
        //services.AddScoped<IInstructorRepository, InstructorRepository>();
        //services.AddScoped<IApplicantRepository, ApplicantRepository>();
        //services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        //services.AddScoped<IApplicationRepository, ApplicationRepository>();
        //services.AddScoped<IApplicationStateRepository, ApplicationStateRepository>();
        //services.AddScoped<IBootcampRepository, BootcampRepository>();
        //services.AddScoped<IBootcampStateRepository, BootcampStateRepository>();

        //services.AddScoped<IBlackListRepository, BlackListRepository>();

        return services;
    }
}
