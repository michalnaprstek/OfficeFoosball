using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace OfficeFoosball.Services.AccessCode
{
    public class AccessCodeService : IAccessCodeService
    {
        private readonly string _accessCode;
        public AccessCodeService(IOptions<AccessCodeSettings> settings)
        {
            _accessCode = settings.Value.Code;
        }

        public Task<bool> CheckAccessCodeAsync(string accessCode) 
            => Task.FromResult(accessCode == _accessCode);
    }
}
