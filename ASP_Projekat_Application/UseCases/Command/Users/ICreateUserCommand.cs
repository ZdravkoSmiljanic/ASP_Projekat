using ASP_Projekat_Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Application.UseCases.Command.Users
{
    public interface ICreateUserCommand: ICommand<CreateUserDTO>
    {
    }
}
