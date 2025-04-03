using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models
{
    public class OildebtContext: DbContext
    {
        public OildebtContext(DbContextOptions<OildebtContext> options) : base(options) { }

        public virtual DbSet<OildebtModel> OildebtModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OildebtModel>().HasNoKey().ToView("Oildebt");
        }
    }
}
