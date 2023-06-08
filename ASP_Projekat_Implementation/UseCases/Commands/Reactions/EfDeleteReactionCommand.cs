using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.ReactionCommand;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ReactionValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Reactions
{
    public class EfDeleteReactionCommand : IDeleteReactionCommand
    {
        private BlogContext _context;
        private DeleteReactionValidator _validator;
        private readonly IApplicationActor _actor;
        public EfDeleteReactionCommand(BlogContext context, DeleteReactionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 13;

        public string Name => "Brisanje reakcije";

        public string Description => "Brisanje reakcije";

        public void Execute(int request)
        {
            var data = _context.Reactions.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
