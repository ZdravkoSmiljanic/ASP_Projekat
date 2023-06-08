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
    public class CreateCommentValidator:AbstractValidator<CreateCommentDTO>
    {
        public CreateCommentValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x))
              .WithMessage("This user doesnt exist in our data base");
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.BlogId).Must(x => context.Blogs.Any(y => y.Id == x))
              .WithMessage("This blog doesnt exist in our data base");

            RuleFor(x => x.ParentId).Must(x => context.Comments.Any(y => y.Id == x))
             .WithMessage("This comennt doesnt exist in our data base");
            RuleFor(x => x.Text).NotEmpty();


        }
    }
}
