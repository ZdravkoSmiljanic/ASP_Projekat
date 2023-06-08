using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.CommentValidators
{
    public class UpdateCommentValidator:AbstractValidator<UpdateCommentTextDTO>
    {
        public UpdateCommentValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.CommentText).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).Must(x => context.Comments.Any(y => y.Id == x))
                .WithMessage("This comment doesnt exist in database");
        }
    }
}
