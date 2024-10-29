namespace Dashboard.Models.DTOs.Response
{
    /// <summary>
    /// Paginated Response Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedResponse<T>
    {
        /// <summary>
        /// Max Pages
        /// </summary>
        public int MaxPages { get; set; }

        /// <summary>
        /// Generic Data List
        /// </summary>
        public List<T> Data { get; set; } = null!;
    }
}
