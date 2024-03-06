using System.Text;

namespace Core.Utilities.Security.Hashing;

public static class HashingHelper
{
    public static void CreatePasswordHash(string passsword, out byte[] passwordHash,out byte[] passwordSalt) 
    {
        using(var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passsword));
            passwordSalt = hmac.Key;
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
