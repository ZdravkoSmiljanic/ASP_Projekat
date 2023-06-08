using ASP_Projekat_Application.UseCases.Command.ReactionOnBlogCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
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
    public class EfReationOnBlogCommand : IReactOnBlogCommand
    {
        private BlogContext _context;
        private ReactOnBlogValidator _validator;


        public EfReationOnBlogCommand(BlogContext context, ReactOnBlogValidator validator)
        {
            _context = context;
            _validator = validator;

        }
        public int Id => 27;

        public string Name => "Reagovanje na blog objavu";

        public string Description => "Reagovanje na blog objavu";

        public void Execute(ReactOnBlogDTO request)
        {
            _validator.ValidateAndThrow(request);
                
                var reactionsExists = _context.BlogReactions.Where(x => x.BlogId == request.BlogId)
                                                            .Where(x => x.ReactionId == request.BlogId)
                                                            .Where(x => x.UserId == request.UserId)
                                                            .Where(x => x.IsActive != false).FirstOrDefault();

               

                BlogReactions blogReaction = new BlogReactions
                {
                    BlogId = request.BlogId,
                    UserId = request.UserId,
                    IsActive = true,
                    ReactedAt = DateTime.UtcNow,
                    ReactionId = request.ReactionId
                };

                _context.BlogReactions.Add(blogReaction);

                _context.SaveChanges();



          
           
        }
    }
}
