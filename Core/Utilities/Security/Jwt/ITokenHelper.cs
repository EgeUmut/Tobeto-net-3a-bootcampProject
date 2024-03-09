using Core.Utilities.Security.Entities;

namespace Core.Utilities.Security.Jwt;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}
