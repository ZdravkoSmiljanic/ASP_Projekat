using ASP_Projekat_Application.Logging;
using ASP_Projekat_Domain;
using ASP_Projekat_Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Logging
{
    public class EfUserCaseLogger : IUseCaseHandelr
    {
        private readonly BlogContext _context;

        public EfUserCaseLogger(BlogContext context)
        {
            _context = context;
        }
        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new LogEntry
            {
                Actor = entry.User,
                ActorId = entry.UserId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
