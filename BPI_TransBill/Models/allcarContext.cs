using APInv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models;

public class allcarContext : DbContext
{
    public allcarContext(DbContextOptions<allcarContext> options) : base(options) { }

    public virtual DbSet<allcarModel> allcarModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<allcarModel>().HasNoKey().ToView("ALLCAR");
    }
}
