using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APInv.Models
{
    public class APInvtableContext : DbContext
    {
  
            public APInvtableContext(DbContextOptions<APInvtableContext> options) : base(options) { }

            public virtual DbSet<APInvModel> APInvModels { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<APInvModel>().HasNoKey().ToView("APInv");
            }
        
    }
}
