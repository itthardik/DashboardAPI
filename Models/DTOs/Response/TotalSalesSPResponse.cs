namespace Dashboard.Models.DTOs.Response
{
    /// <summary>
    /// Total Sales SP Res
    /// </summary>
    public class TotalSalesSPResponse
    {
        /// <summary>
        /// total quantity
        /// </summary>
        public int TotalQuantity { get; set; }

        /// <summary>
        /// current timestamp
        /// </summary>
        public DateTime CurrentDateTime { get; set; }
    }
}
