using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.ImageCommands;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ImageValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Images
{
    public class EfDeleteImageCommand:IDeleteImageCommand
    {
        private BlogContext _context;
        private DeleteImageValidator _validator;
        private readonly IApplicationActor _actor;

        public int Id => 8;

        public string Name => "Brisanje slike";

        public string Description => "Brisanje slike";

        public EfDeleteImageCommand(BlogContext context, DeleteImageValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public void Execute(int request)
        {
            var data = _context.Images.Find(request);

            _validator.ValidateAndThrow(request);
            data.IsActive = false;
            data.DeletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
