using System.Diagnostics;
using System.Text;

namespace API.Middleware
{
    public class LogResponseTime
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogResponseTime> _logger;

        public LogResponseTime(RequestDelegate next, ILogger<LogResponseTime> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            await _next(context);

            sw.Stop();
            var elapsed = sw.ElapsedMilliseconds;

            LogResponseTimeToLogFile(context, elapsed);
        }

        private void LogResponseTimeToLogFile(HttpContext context, long elapsed)
        {
            var logMessage = $"[{DateTime.Now}] {context.Request.Method} {context.Request.Path} took {elapsed} ms to respond.";
            var directory = Directory.GetCurrentDirectory();
            var path = Path.Combine(directory, "LogResponse/log_response_times.txt");

            using (var streamWriter = new StreamWriter(path, true, Encoding.UTF8))
            {
                streamWriter.WriteLine(logMessage);
            }

            _logger.LogInformation(logMessage);
        }
    }
}