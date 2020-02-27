using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace identityissue
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUserEntity> FindByEmailIncludeAsync(this UserManager<ApplicationUserEntity> input, string email)
        {
            return await input.Users
                .Include(x => x.Details)
                .SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}