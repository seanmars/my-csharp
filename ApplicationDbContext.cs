using AdminCore.Common;
using AdminCore.Data;
using AdminCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdminSite.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Rename the Identity table names
            builder.Entity<IdentityUser<int>>().ToTable("Users");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            // or 
            // builder.Entity<IdentityUser<int>>().ToTable("users");
            // builder.Entity<IdentityRole<int>>().ToTable("roles");
            // builder.Entity<IdentityUserClaim<int>>().ToTable("user_claims");
            // builder.Entity<IdentityUserRole<int>>().ToTable("user_roles");
            // builder.Entity<IdentityUserLogin<int>>().ToTable("user_logins");
            // builder.Entity<IdentityRoleClaim<int>>().ToTable("role_claims");
            // builder.Entity<IdentityUserToken<int>>().ToTable("user_tokens");
        }
    }
}
