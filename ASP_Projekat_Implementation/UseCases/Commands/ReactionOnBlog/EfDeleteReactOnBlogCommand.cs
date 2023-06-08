using ASP_Projekat_Application.UseCases.Command.ReactionOnBlogCommands;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ReactionOnBlogValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.ReactionOnBlog
{
    public class EfDeleteReactOnBlogCommand : IDeleteReactionOnBlogCommand
    {
        private BlogContext _context;
        private DeleteReactionOnBlog _validator;


        public EfDeleteReactOnBlogCommand(BlogContext context, DeleteReactionOnBlog validator)
        {
            _context = context;
            _validator = validator;

        }
        public int Id => 28;

        public string Name => "Uklanjanje reakcije sa blog objave";

        public string Description => "Uklanjanje reakcije sa blog objave";

        public void Execute(List<int> request)
        {
             _validator.ValidateAndThrow(request);

             var data = _context.BlogReactions.Where(x => x.BlogId == request.First())
                .Where(x => x.ReactionId == request.ElementAt(1))
                .Where(x => x.UserId == request.ElementAt(2))
                .FirstOrDefault();

               
                _context.BlogReactions.Remove(data);

                _context.SaveChanges();


            
            
        }
    }
}
