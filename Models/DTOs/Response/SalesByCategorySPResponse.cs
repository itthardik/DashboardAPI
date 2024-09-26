namespace Dashboard.Models.DTOs.Response
{
    public class SalesByCategorySPResponse
    {
        /// <summary>
        /// Category id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Category { get; set; } = null!;

        /// <summary>
        /// Total Sales
        /// </summary>
        public int TotalSales { get; set; }

    }
}
