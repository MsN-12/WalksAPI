using Microsoft.AspNetCore.Identity;

namespace WalksAPI.Repositories
{
    public interface ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
