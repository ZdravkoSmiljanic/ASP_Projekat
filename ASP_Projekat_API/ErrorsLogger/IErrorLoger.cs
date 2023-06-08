namespace ASP_Projekat_API.ErrorsLogger
{
    public interface IErrorLoger
    {
        void LogError(AppError error);
    }

    public class AppError
    {
        public Guid errorGUID { get; set; }
        public string username { get; set; }
        public Exception exception { get; set; }
     
    }
}
