using System.Text;

namespace ASP_Projekat_API.ErrorsLogger
{
    public class ConsoleErrorLogger
        : IErrorLoger
    {
        public void LogError(AppError error)
        {
            var errorDate = DateTime.UtcNow;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Error code: " + error.errorGUID.ToString());
            builder.AppendLine("User: " + error.username != null ? error.username : "/");
            builder.AppendLine("Error time:" + errorDate.ToLongDateString());
            builder.AppendLine("Ex message:" + error.exception.Message);
            builder.AppendLine("Ex stack trace:");
            builder.AppendLine(error.exception.StackTrace);

            Console.WriteLine(builder.ToString());
        }
    }
}
