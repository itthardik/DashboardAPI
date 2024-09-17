namespace Dashboard.Utility.Validation
{
    /// <summary>
    /// Validation class as utility
    /// </summary>
    public class ValidationUtility
    {
        /// <summary>
        /// Validate Page Size and Page Number
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <exception cref="Exception"></exception>
        static public void PageInfoValidator(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
                throw new CustomException("Page Number and Page Size cannot be negative");
        }
    }
}
