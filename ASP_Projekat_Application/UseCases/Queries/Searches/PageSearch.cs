using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCases.Queries.Searches
{
    public class PageSearch
    {
        public int PerPage { get; set; } = 5;
        public int Page { get; set; } = 1;
    }
}
