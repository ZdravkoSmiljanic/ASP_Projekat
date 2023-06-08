using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.ReactionValidator
{
    public class CreateReactionValidator : AbstractValidator<CreateReactionDTO>
    {
        public CreateReactionValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ReactionName).NotEmpty().WithMessage("Name is required ");
            RuleFor(x => x.ReactionName).Must(x => !context.Reactions.Any(u => u.ReactionName == x))
                .WithMessage("This name is already taken");
            RuleFor(x => x.ImageId).Must(x=>context.Images.Any(y=>y.Id==x))
                .WithMessage("This image doesent exists. Please upload new file, or use our images");

        }
    }

}
