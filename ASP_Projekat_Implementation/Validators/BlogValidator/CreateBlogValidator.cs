using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.BlogValidator
{
    public class CreateBlogValidator:AbstractValidator<CreateBlogDTO>
    {
        public CreateBlogValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).Must(x => context.Users.Any(y => y.Id == x))
              .WithMessage("This user doesnt exist in our data base");
            RuleFor(x => x.BlogText).NotEmpty();
            RuleFor(x => x.BlogImages).Must(x => x.Count > 0).WithMessage("You must insert at least one photo");
            RuleFor(x => x.BlogImages).Must(x => context.Images.Any(y => y.BlogImages == x))
                .WithMessage("This image doesnt exists in database");

            RuleFor(x => x.BlogTags).Must(x => context.Tags.Any(y => y.BlogTags == x))
                .WithMessage("This tag doesnt exists in database");


        }
    }
}
