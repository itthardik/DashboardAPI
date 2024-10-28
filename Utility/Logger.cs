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
            public static void LogException(this Exception ex )
            {
                try
                {
                    var TodayDate = DateTime.Now;
                    var TodayForamtedDate=TodayDate.Year + "_" + TodayDate.Month + "_" +TodayDate.Day;
                    string logFilePath = $"C:/Users/hardik.sharma/source/repos/DashboardLogs/ExceptionLogs/{TodayForamtedDate}_exception_log.txt";
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
