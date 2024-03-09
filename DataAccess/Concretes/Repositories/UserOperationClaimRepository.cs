using Core.DataAccess;
using Core.Utilities.Security.Entities;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;

namespace DataAccess.Concretes.Repositories;

public class UserOperationClaimRepository : RepositoryBase<UserOperationClaim, TobetoBootCampProjectContext, int>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(TobetoBootCampProjectContext context) : base(context)
    {
    }
}
