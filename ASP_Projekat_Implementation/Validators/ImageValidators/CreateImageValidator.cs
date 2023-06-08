using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ImageValidators
{
    public class CreateImageValidator:AbstractValidator<CreateImageDTO>
    {
        public CreateImageValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Image path is required ");
            RuleFor(x => x.ImageSize).NotEmpty().WithMessage("Image size is required ");
            RuleFor(x => x.ImageSize).GreaterThan(20).WithMessage("Image size must be greather then 20");
            RuleFor(x => x.ImagePath).Must(x => !context.Tags.Any(u => u.TagText == x))
                .WithMessage("You cannont insert same addres");

        }
    }
}
