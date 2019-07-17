using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OfficeFoosball.Security.Token
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
    }
}
