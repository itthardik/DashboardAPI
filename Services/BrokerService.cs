using System.Diagnostics;

namespace Dashboard.Services
{
    /// <summary>
    /// Broker Service
    /// </summary>
    public class BrokerService
    {
        private readonly string _mosquittoCtrlPath = @"C:\Program Files\mosquitto\mosquitto_ctrl";
        private readonly string _controlUrl = "localhost";
        private readonly int _controlPort = 1883;         
        private readonly string _adminUsername = "admin"; 
        private readonly string _adminPassword = "admin";

        /// <summary>
        /// Add User to broker
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<CommandResult> AddUser(string Username, string Password, string Role)
        {
            var command = $"dynsec createClient {Username} {Password}";
            var result = await RunMosquittoCtrlCommand(command);
            if(result.Success == false)
                throw new Exception(result.Error);

            
            command = $"dynsec setClientPassword {Username} {Password}";
            result = await RunMosquittoCtrlCommand(command);
            if (result.Success == false)
                throw new Exception(result.Error);


            command = $"dynsec addClientRole {Username} {Role}";
            result = await RunMosquittoCtrlCommand(command);
            if (result.Success == false)
                throw new Exception(result.Error);

            return result;
        }

        /// <summary>
        /// Login user to broker
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CommandResult> LoginUser(string Username, string Password, string Role)
        {
            // Check Client Exist
            var command = $"dynsec getClient {Username}";
            var result = await RunMosquittoCtrlCommand(command);
            if (result.Success == false)
                throw new Exception(result.Error);

            if (result.Error!.Contains("Client not found"))
            {
                await AddUser(Username, Password, Role );
            }
            else
            {
                command = $"dynsec enableClient {Username}";
                result = await RunMosquittoCtrlCommand(command);
                if (result.Success == false)
                    throw new Exception(result.Error);

                command = $"dynsec setClientPassword {Username} {Password}";
                result = await RunMosquittoCtrlCommand(command);
                if (result.Success == false)
                    throw new Exception(result.Error);
            }


            return result ;

        }

        /// <summary>
        /// Logout User to broker
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CommandResult> LogoutUser(string Username)
        {
            var command = $"dynsec disableClient {Username}";
            var result = await RunMosquittoCtrlCommand(command);
            if (result.Success == false)
                throw new Exception(result.Error);

            return result;
        }

        /// <summary>
        /// Refresh User in broker
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CommandResult> RefreshUser(string Username, string Password)
        {
            var command = $"dynsec setClientPassword {Username} {Password}";
            var result = await RunMosquittoCtrlCommand(command);
            if (result.Success == false)
                throw new Exception(result.Error);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<CommandResult> RunMosquittoCtrlCommand(string command)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = _mosquittoCtrlPath,
                Arguments = $"-h {_controlUrl} -p {_controlPort} -u {_adminUsername} -P {_adminPassword} {command}",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = new Process { StartInfo = startInfo };

            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();

            process.WaitForExit();
            Console.WriteLine(process.ExitCode);

            return new CommandResult
            {
                Success = true,
                //Success = process.ExitCode == 0,
                Output = output,
                Error = error
            };
        }

    }

    /// <summary>
    /// DYNSEC Command results
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Output
        /// </summary>
        public string? Output { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string? Error { get; set; }
    }
}
