using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.CommentValidators
{
    public class DeleteCommentValidator:AbstractValidator<int>
    {
        public DeleteCommentValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Comments.Any(c => c.Id == x))
               .WithMessage("This comment doesnt exists in database");
            RuleFor(x => x)
              .Must(x => context.Comments.Any(c => c.ChildComments.Any()))
              .WithMessage("This comment cannot be delete because of subcomments");


        }
    }
}
