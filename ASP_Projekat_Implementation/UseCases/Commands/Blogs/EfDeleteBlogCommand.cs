using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.BlogCommands;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.BlogValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Blogs
{
    public class EfDeleteBlogCommand : IDeleteBlogCommand
    {
        private BlogContext _context;
        private DeleteBlogValidator _validator;
        private readonly IApplicationActor _actor;

        public EfDeleteBlogCommand(BlogContext context, DeleteBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 19;

        public string Name => "Brisanje bloga";

        public string Description => "Brisanje bloga";

        public void Execute(int request)
        {
                _validator.ValidateAndThrow(request);

                var data = _context.Blogs.Find(request);


                data.IsActive = false;
                data.DeletedAt = DateTime.UtcNow;
                _context.SaveChanges();

            
        }   
    }
}
