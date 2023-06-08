using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.Exceptions
{
    public class NotFoundEntityException:Exception
    {
        public NotFoundEntityException(int id, string entity)
           : base($"Entity  {entity} with  id  {id} doesnt exists.")
        {

        }
    }
}
