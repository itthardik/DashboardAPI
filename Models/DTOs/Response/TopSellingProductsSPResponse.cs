namespace Dashboard.Models.DTOs.Response
{
    /// <summary>
    /// Top Selling Products SP Response
    /// </summary>
    public class TopSellingProductsSPResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id {  get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// total sales
        /// </summary>
        public int TotalSales { get; set; }
    }
}
