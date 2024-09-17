namespace Dashboard.Utility
{
    /// <summary>
    /// Custom Exception class
    /// </summary>
    /// <remarks>
    /// constructor for custom exception
    /// </remarks>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    public class CustomException(string message, int statusCode = 200) : Exception(message)
    {
        /// <summary>
        /// Status Code
        /// </summary>
        public int StatusCode = statusCode;
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage = message;
    }
}
