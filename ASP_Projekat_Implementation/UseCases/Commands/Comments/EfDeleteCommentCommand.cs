using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.CommentsCommand;
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
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private BlogContext _context;
        private DeleteCommentValidator _validator;
        private readonly IApplicationActor _actor;
        public EfDeleteCommentCommand(BlogContext context, DeleteCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 29;

        public string Name => "Brisanje komentara";

        public string Description => "Brisanje komentara";

        public void Execute(int request)
        {
                _validator.ValidateAndThrow(request);

                var data = _context.Comments.Find(request);

                data.IsActive = false;
                data.DeletedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }
    }
}
