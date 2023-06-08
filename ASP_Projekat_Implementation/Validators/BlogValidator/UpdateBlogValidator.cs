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
    public class UpdateBlogValidator:AbstractValidator<UpdateBlogDTO>
    {
        public UpdateBlogValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.BlogText).NotEmpty().WithMessage("Blog text is required ");
            
            RuleFor(x => x.BlogText)
                .Must((blog, name) => context.Blogs
                .Any(x => x.BlogText == name && x.Id != blog.Id)).WithMessage("There is blog whit same text, plesae add some caracter");
            RuleFor(x => x.Id).Must(x => context.Blogs.Any(y => y.Id == x))
                .WithMessage("This blog doesent exists. Looking for something else?");



        }
    }
}
