using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Models
{
    public class dmgebtContext: DbContext
    {
        public dmgebtContext(DbContextOptions<dmgebtContext> options) : base(options) { }

        public virtual DbSet<dmgebtModel> dmgebtModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dmgebtModel>().HasNoKey().ToView("dmgebt");
        }
    }
}
