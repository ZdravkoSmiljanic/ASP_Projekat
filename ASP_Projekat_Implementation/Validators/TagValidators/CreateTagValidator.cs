using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.TagValidators
{
    public class CreateTagValidator : AbstractValidator<CreateTagDTO>
    {
        public CreateTagValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.Name).Must(x => !context.Tags.Any(u => u.TagText == x))
                .WithMessage("This name is already taken");

        }
    }
}
