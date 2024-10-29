namespace Dashboard.Models.DTOs.Response
{
    /// <summary>
    /// Sales by category sp response
    /// </summary>
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
