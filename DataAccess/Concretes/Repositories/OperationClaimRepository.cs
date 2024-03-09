using Core.DataAccess;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;

namespace DataAccess.Concretes.Repositories;

public class OperationClaimRepository : RepositoryBase<OperationClaim, TobetoBootCampProjectContext, int>, IOperationClaimRepository
{
    public OperationClaimRepository(TobetoBootCampProjectContext context) : base(context)
    {
    }
}
