using System.Threading.Tasks;

namespace OfficeFoosball.Services.AccessCode
{
    public interface IAccessCodeService
    {
        Task<bool> CheckAccessCodeAsync(string accessCode);
    }
}
