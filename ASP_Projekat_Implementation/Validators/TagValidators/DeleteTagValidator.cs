using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.TagValidators
{
    public class DeleteTagValidator:AbstractValidator<int>
    {
        public DeleteTagValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Tags.Any(c => c.Id == x))
               .WithMessage("This tag doesnt exists in database");


        }
    }
}
