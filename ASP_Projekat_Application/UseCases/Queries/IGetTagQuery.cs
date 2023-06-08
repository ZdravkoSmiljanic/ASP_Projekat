using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCases.Queries
{
    public interface IGetTagQuery: IQuery<int, ReadTagDTO>
    {
    }
}
