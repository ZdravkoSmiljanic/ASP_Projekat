using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ImageValidators
{
    public class DeleteImageValidator:AbstractValidator<int>
    {

        public DeleteImageValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Images.Any(c => c.Id == x))
               .WithMessage("This image doesnt exists in database");


        }
    }
}
