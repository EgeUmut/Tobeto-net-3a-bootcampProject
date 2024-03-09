using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt;

public class TokenOptions
{
    public string Audience { get; set; }    // bir kimlik doğrulama tokenının hedef kitlesini temsil eden özellik.
    public string Issuer { get; set; }  // Bİr kimlik doğrulama işleminde token ı veren kimseyi temsil eden özellik
    public int AccessTokenExpiration { get; set; }  //Token geçerlilik süresi.
    public string SecurityKey { get; set; }  //kimlik doğrulama için kullanılan güvenlik anahtarı
}
