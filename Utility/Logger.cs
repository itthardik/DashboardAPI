namespace Dashboard.Utility
    {
        /// <summary>
        /// Logger Class
        /// </summary>
        public static class Logger
        {
        
            /// <summary>
            /// Log Exception into LogFile
            /// </summary>
            /// <param name="ex"></param>
            /// <param name="logFilePath"></param>
            public static void LogException(this Exception ex, string logFilePath = "exception_log.txt" )
            {
                try
                {
                //filter
                if (ex.GetType() == typeof(CustomException)) {
                    return;
                }

                using StreamWriter Writer = new(logFilePath, true);
                Writer.WriteLine("------------------------------------------------");
                Writer.WriteLine($"Date: {DateTime.Now}");
                Writer.WriteLine($"Message: {ex.Message}");
                Writer.WriteLine($"StackTrace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Writer.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    Writer.WriteLine($"Inner StackTrace: {ex.InnerException.StackTrace}");
                }
                Writer.WriteLine("------------------------------------------------");
            }
                catch (Exception loggingEx)
                {
                    Console.WriteLine($"Failed to log exception: {loggingEx.Message}");
                }
            }
        }
    
    }
