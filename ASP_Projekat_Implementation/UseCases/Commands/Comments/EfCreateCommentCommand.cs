using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.CommentsCommand;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.CommentValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Comments
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private BlogContext _context;
        private CreateCommentValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateCommentCommand(BlogContext context, CreateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 30;

        public string Name => "Kreiranje komentara";

        public string Description => "Kreiranje komentara";

        public void Execute(CreateCommentDTO request)
        {

            //var blog = _context.Blogs.Where(x => x.Id == request.BlogId).First();
                 _validator.ValidateAndThrow(request);

                var comment = new Comment
                {
                    ParentId = request.ParentId,
                    BlogId = request.BlogId,
                    CommentedAt = DateTime.UtcNow,
                    TextComment = request.Text,
                    UserId = request.UserId
                };
                _context.Comments.Add(comment);
                _context.SaveChanges();
            }
    }
}
