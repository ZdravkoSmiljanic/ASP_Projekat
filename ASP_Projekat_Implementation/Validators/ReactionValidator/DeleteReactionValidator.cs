using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ReactionValidator
{
    public class DeleteReactionValidator:AbstractValidator<int>
    {
        public DeleteReactionValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Reactions.Any(c => c.Id == x))
               .WithMessage("This reaction doesnt exists in database");


        }
    }
}
