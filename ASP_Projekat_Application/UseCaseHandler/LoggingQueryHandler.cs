using ASP_Projekat_Application.Logging;
using ASP_Projekat_Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCaseHandler
{
    public class LoggingQueryHandler:IQueryHandler
    {
        private IQueryHandler _next;
        private IApplicationActor _actor;
        private IUseCaseHandelr _logger;

        public LoggingQueryHandler(IQueryHandler next, IApplicationActor actor, IUseCaseHandelr logger)
        {
            _next = next;
            if (next == null)
            {
                throw new ArgumentException();
            }
            _actor = actor;
            _logger = logger;
        }


        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            _logger.Add(new UseCaseLogEntry
            {
                User = _actor.Username,
                UserId = _actor.Id,
                Data = search,
                UseCaseName = query.Name
            });

            return _next.HandleQuery(query, search);
        }
    }
}
