using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.BlogCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.BlogValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Blogs
{
    public class EfUpdateBlogCommand : IUpdateBlogCommand
    {
        private BlogContext _context;
        private UpdateBlogValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateBlogCommand(BlogContext context, UpdateBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 25;

        public string Name => "Update bloga";

        public string Description => "Update bloga";

        public void Execute(UpdateBlogDTO request)
        {

                _validator.ValidateAndThrow(request);
                var blog = _context.Blogs.Find(request.Id);
               
                blog.BlogText = request.BlogText;
                blog.ModifiedAt = DateTime.UtcNow;
                _context.Entry(blog).State = EntityState.Modified;

                _context.SaveChanges();

            }
            
        }
}

