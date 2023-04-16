using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TR_I_FO___Inventry_VERSION__2.Areas.Identity.Data;

namespace TR_I_FO___Inventry_VERSION__2.Data;

public class TR_I_FO___Inventry_VERSION__2Context : IdentityDbContext<TR_I_FO___Inventry_VERSION__2User>
{
    public TR_I_FO___Inventry_VERSION__2Context(DbContextOptions<TR_I_FO___Inventry_VERSION__2Context> options)
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
