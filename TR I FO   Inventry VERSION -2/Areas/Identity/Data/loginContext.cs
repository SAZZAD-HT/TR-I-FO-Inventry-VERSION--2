using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TR_I_FO___Inventry_VERSION__2.Areas.Identity.Data;

namespace TR_I_FO___Inventry_VERSION__2.Areas.Identity.Data;

public class loginContext : IdentityDbContext<usercontext>
{
    public loginContext(DbContextOptions<loginContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
