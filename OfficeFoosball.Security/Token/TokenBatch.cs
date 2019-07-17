using System;

namespace OfficeFoosball.Security.Authentication.Token
{
    public class TokenBatch
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiredIn { get; set; } 
    }
}
