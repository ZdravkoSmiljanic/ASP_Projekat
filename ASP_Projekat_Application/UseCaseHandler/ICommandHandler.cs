using ASP_Projekat_Application.Exceptions;
using ASP_Projekat_Application.Logging;
using ASP_Projekat_Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCaseHandler
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data);

    }
    public class CommandHandler : ICommandHandler
    {
        private IApplicationActor _actor;
        private IUseCaseHandelr _logger;

        public CommandHandler(IApplicationActor actor, IUseCaseHandelr logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUserUseCaseException(_actor.Username, command.Name);
            }

            _logger.Add(new UseCaseLogEntry
            {
                User = _actor.Username,
                UserId = _actor.Id,
                Data = data,
                UseCaseName = command.Name
            });

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine("Execution time:" + stopwatch.ElapsedMilliseconds + " UseCase: " + command.Name + " User: " + _actor.Username);
        }
    }
}
