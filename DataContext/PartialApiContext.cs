using Dashboard.Models.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.DataContext
{
    public partial class ApiContext
    {
        /// <summary>
        /// Revenue SP response
        /// </summary>
        public virtual DbSet<RevenueSPResponse> RevenueSPResponses { get; set; }

        /// <summary>
        /// Sales By Category SP Responses
        /// </summary>
        public virtual DbSet<SalesByCategorySPResponse> SalesByCategorySPResponses { get; set; }

        /// <summary>
        /// Total Sales SP Responses
        /// </summary>
        public virtual DbSet<TotalSalesSPResponse> TotalSalesSPResponses { get; set; }

        /// <summary>
        /// Top Selling Products SP Responses
        /// </summary>
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

                entity.Property(e => e.Profit)
                .HasPrecision(18, 2);
                entity.Property(e => e.Revenue)
                .HasPrecision(18, 2);
            });
        }

    }
}
