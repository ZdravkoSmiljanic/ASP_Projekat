using Bugsnag;

namespace ASP_Projekat_API.ErrorsLogger
{
    public class BugSnagErrorLogger
        : IErrorLoger
    {
        private readonly Bugsnag.IClient _bugsnag;
        public BugSnagErrorLogger(IClient bugsnag)
        {
            _bugsnag = bugsnag;
        }
        public void LogError(AppError error)
        {

            _bugsnag.Notify(error.exception, (report) => {
                report.Event.Metadata.Add("Error", new Dictionary<string, string> {
                    { "user", error.username},
                    { "erroCode", error.errorGUID.ToString() },
        });
            });
        }
    }
}
