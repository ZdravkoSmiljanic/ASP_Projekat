using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.Users;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.UserValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private BlogContext _context;
        private DeleteUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfDeleteUserCommand(BlogContext context, DeleteUserValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 16;

        public string Name => "Brisanje korisnika";

        public string Description => "Brisanje korisnika";

        public void Execute(int request)
        {
            
                var data = _context.Users.Find(request);

                _validator.ValidateAndThrow(request);
                data.IsActive = false;
                data.DeletedAt = DateTime.UtcNow;

                _context.SaveChanges();

             
        }
    }
}
