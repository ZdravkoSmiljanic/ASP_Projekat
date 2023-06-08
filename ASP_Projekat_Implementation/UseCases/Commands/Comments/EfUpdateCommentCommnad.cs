using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.CommentsCommand;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.CommentValidators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Comments
{
    public class EfUpdateCommentCommnad : IUpdateCommentCommand
    {
        private BlogContext _context;
        private UpdateCommentValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateCommentCommnad(BlogContext context, UpdateCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 31;

        public string Name => "Izmena teksta komentara";

        public string Description => "Izmena teksta komentara";

        public void Execute(UpdateCommentTextDTO request)
        {
                _validator.ValidateAndThrow(request);
                var comment = _context.Comments.Find(request.Id);

                comment.TextComment = request.CommentText;
                comment.ModifiedAt = DateTime.UtcNow;
                _context.Entry(comment).State = EntityState.Modified;

                _context.SaveChanges();
            }
    }
}
