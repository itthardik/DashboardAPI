namespace Dashboard.Models.DTOs.Response
{
    /// <summary>
    /// Response type of revenue
    /// </summary>
    public class RevenueSPResponse
    {
        /// <summary>
        /// Category Name
        /// </summary>
        public string CategoryName { get; set; } = null!;
   
        /// <summary>
        /// Total Revenue
        /// </summary>
        public decimal Revenue { get; set; }

        /// <summary>
        /// Net Profit
        /// </summary>
        public decimal Profit { get; set; }
    }
}
