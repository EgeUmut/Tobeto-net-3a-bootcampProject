using Core.DataAccess;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories;

public class BootcampRepository : RepositoryBase<Bootcamp, TobetoBootCampProjectContext, int>, IBootcampRepository
{
    public BootcampRepository(TobetoBootCampProjectContext context) : base(context)
    {
    }
}
