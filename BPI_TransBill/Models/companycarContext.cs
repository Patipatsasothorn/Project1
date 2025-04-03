using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models
{
    public class companycarContext : DbContext
    {
        public companycarContext(DbContextOptions<companycarContext> options) : base(options) { }

        public virtual DbSet<companycarModel> companycarModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<companycarModel>().HasNoKey().ToView("companycar");
        }
    }
}
