using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ReactionOnBlogValidator
{
    public class DeleteReactionOnBlog:AbstractValidator<List<int>>
    {

        public DeleteReactionOnBlog(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.First()).NotEmpty().WithMessage("BlogId is required ");
            RuleFor(x => x.ElementAt(1)).NotEmpty().WithMessage("UserID is required ");
            RuleFor(x => x.ElementAt(2)).NotEmpty().WithMessage("ReactionID is required ");
            RuleFor(x => x).Must(x => context.BlogReactions.Any(u => u.BlogId==x.First() 
            && u.ReactionId==x.ElementAt(1)
            && u.UserId==x.ElementAt(2)
            && u.DeletedAt!=null)).WithMessage("Reaction on blog whit this id doesent exists in database");

        }
    }
}
