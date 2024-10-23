using RealTimeComTest.Models;

namespace Dashboard.Models.DTOs.Response
{
    public class LoginServiceResponse
    {
        public string Token {  get; set; }

        public LoginResponse LoginResponse { get; set; }

    }
}
