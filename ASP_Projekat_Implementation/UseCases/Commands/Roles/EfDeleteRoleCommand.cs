using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.RoleCommands;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.RoleValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Roles
{
    public class EfDeleteRoleCommand:IDeleteRoleCommand
    {
        private BlogContext _context;
        private DeleteRoleValidator _validator;
        private readonly IApplicationActor _actor;

        public EfDeleteRoleCommand(BlogContext context, DeleteRoleValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 5;

        public string Name => "Brisanje uloge";

        public string Description => "Brisanje uloge podrazumeva da mu se vrednost isActive postavi na false";

        public void Execute(int request)
        {
            var data = _context.Role.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
