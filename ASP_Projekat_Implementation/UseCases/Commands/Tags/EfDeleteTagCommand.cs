using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.TagCommands;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.TagValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Tags
{
    public class EfDeleteTagCommand : IDeleteTagCommand
    {
        private BlogContext _context;
        private DeleteTagValidator _validator;
        private readonly IApplicationActor _actor;

        public EfDeleteTagCommand(BlogContext context, DeleteTagValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 2;

        public string Name => "Brisanje taga";

        public string Description => "Brisanje taga podrazumeva da mu se vrednost isActive postavi na false";

        public void Execute(int request)
        {
            var data = _context.Tags.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
