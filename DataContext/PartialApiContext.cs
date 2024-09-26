using Dashboard.Models.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.DataContext
{
    public partial class ApiContext
    {
        public virtual DbSet<RevenueSPResponse> RevenueSPResponses { get; set; }
        public virtual DbSet<SalesByCategorySPResponse> SalesByCategorySPResponses { get; set; }
        public virtual DbSet<TotalSalesSPResponse> TotalSalesSPResponses { get; set; }
        public virtual DbSet<TopSellingProductsSPResponse> TopSellingProductsSPResponses { get; set; }

        static partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TopSellingProductsSPResponse>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });

            modelBuilder.Entity<TotalSalesSPResponse>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });

            modelBuilder.Entity<SalesByCategorySPResponse>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });

            modelBuilder.Entity<RevenueSPResponse>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null); // Treats this entity as a query only
            });
        }

    }
}
