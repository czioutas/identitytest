using Microsoft.AspNetCore.Identity;

namespace identityissue
{
    public class ApplicationRoleEntity : IdentityRole<int>
    {
        public ApplicationRoleEntity(string name) : base(name)
        {
        }
    }
}