using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace identityissue
{
    public class DbContext : IdentityDbContext<ApplicationUserEntity, ApplicationRoleEntity, int>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public virtual DbSet<DetailsEntity> DetailsEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
