using Microsoft.EntityFrameworkCore;
using TR_I_FO___Inventry_VERSION__2.Models.Databases;

namespace TR_I_FO___Inventry_VERSION__2.Models
{
    public class context:DbContext
    {
        public context()
        {
        }
        public context(DbContextOptions<context> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IE1FQHR\\SQLEXPRESS;Initial Catalog=InventoryCore;Integrated Security=true;Encrypt=false");
        }

        public DbSet<warehouse> Warehouse { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<ImportList> Imports { get; set; }
        public DbSet<MEMO> memo { get; set; }
        public DbSet<USER> AccountInfo { get; set; }
      
    }
}
