using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.Exceptions
{
    public class UnauthorizedUserUseCaseException:Exception
    {
        public UnauthorizedUserUseCaseException(string userName, string nameUsecase)
           : base($"Unauthorized user {userName} try to attempt for {nameUsecase} use case.")
        {

        }
    }
}
