using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCases.Queries
{
    public interface IGetLogEntryQuery: IQuery<SearchLogDTO, List<ReadLogDTO>>
    {
    }
}
