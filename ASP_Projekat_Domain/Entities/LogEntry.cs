using ASP_Projekat_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Domain.Entities
{
    public class LogEntry:Entity
    {
        public string Actor { get; set; }
        public int ActorId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
    }
}
