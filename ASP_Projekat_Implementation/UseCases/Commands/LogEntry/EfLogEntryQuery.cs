using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.LogEntryValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.LogEntry
{
    public class EfLogEntryQuery : IGetLogEntryQuery
    {
        private BlogContext _context;
        private LogEntryValidators _validator;
        private readonly IApplicationActor _actor;
        public EfLogEntryQuery(BlogContext context, LogEntryValidators validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 10;

        public string Name => "Filter log entry tabele";

        public string Description => "Filter log entry tabele";

 


        public List<ReadLogDTO> Execute(SearchLogDTO search)
        {
            var query = _context.LogEntries.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.Keyword) || x.Actor.Contains(search.Keyword));
            }
            if (search.DateTo.HasValue)
            {
                query = query.Where(x => x.CreatedAt < search.DateTo.Value);
            }
            if (search.DateFrom.HasValue)
            {
                query = query.Where(x => x.CreatedAt > search.DateFrom.Value);
            }


            var data = query.Select(x => new ReadLogDTO
            {
                Actor = x.Actor,
                CreatedAt = x.CreatedAt,
                UseCasename = x.UseCaseName,
            }).ToList();

            return (data);
        }
    }
}
