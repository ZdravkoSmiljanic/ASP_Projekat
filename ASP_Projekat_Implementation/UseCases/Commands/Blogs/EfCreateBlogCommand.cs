using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.BlogCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
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
    public class EfCreateBlogCommand : ICreateBlogCommand
    {
        private BlogContext _context;
        private CreateBlogValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateBlogCommand(BlogContext context, CreateBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 24;

        public string Name => "Kreiranje blogova";

        public string Description => "Upis blogova u bazu podataka";

        public void Execute(CreateBlogDTO request)
        {
            _validator.ValidateAndThrow(request);

           
                foreach (var t in request.BlogTags)
                {
                    var tag = _context.Tags.Where(x => x.Id == t.TagId).FirstOrDefault();
                    
                }
               

                var blog = new Blog
                {
                    BlogText = request.BlogText,
                    CreatedAt = DateTime.UtcNow,
                    UserId = request.UserId
                };
                _context.Blogs.Add(blog);
                _context.SaveChanges();


                foreach (var t in request.BlogTags)
                {

                    BlogTag blogTags = new BlogTag
                    {
                        BlogId = blog.Id,
                        TagId = t.TagId
                    };
                    _context.BlogTags.AddRange(blogTags);

                }
                foreach (var i in request.BlogImages)
                {
                    BlogImages blogImages = new BlogImages
                    {
                        BlogId = blog.Id,
                        ImageId = i.ImageId
                    };
                    _context.BlogImages.AddRange(blogImages);

                }
                _context.SaveChanges();


            }
         

        
        }
}

