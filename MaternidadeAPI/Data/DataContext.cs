using MaternidadeAPI.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MaeModelo> Maes { get; set; }
        public DbSet<RecemNascidoModelo> RecemNascido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecemNascidoModelo>()
                .HasOne(m => m.Mae)
                .WithMany()
                .HasForeignKey(m => m.MaeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
