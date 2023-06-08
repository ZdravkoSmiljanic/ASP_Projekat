using ASP_Projekat_Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCaseHandler
{
    public interface IQueryHandler
    {
        TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
           where TResult : class;
    }
}
