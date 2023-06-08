using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ReactionOnBlogValidator
{
    public class ReactOnBlogValidator:AbstractValidator<ReactOnBlogDTO>
    {
        public ReactOnBlogValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.BlogId).NotEmpty();
            RuleFor(x => x.ReactionId).NotEmpty();
      
            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x))
                .WithMessage("This user doesnt exists in database");

            RuleFor(x => x.BlogId).Must(x => context.Blogs.Any(y => y.Id == x))
                .WithMessage("This blog doesnt exists in database");

            RuleFor(x => x.ReactionId).Must(x => context.Reactions.Any(y => y.Id == x))
             .WithMessage("This reactions doesnt exists in database");

            RuleFor(x => x)
            .Must((blogreaction) => context.BlogReactions
            .Any(x => x.BlogId == blogreaction.BlogId
             && x.UserId == blogreaction.UserId 
             && x.ReactionId==blogreaction.ReactionId &&
             x.IsActive!=false)).WithMessage("You already reacted on comment");


        }
    }
}
