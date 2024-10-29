namespace Dashboard.Models.DTOs.Request
{
    /// <summary>
    /// Request Order Item
    /// </summary>
    public class RequestOrderItem
    {
        /// <summary>
        /// product Id
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
