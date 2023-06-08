using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.BlogValidator
{
    public class GetBlogValidator:AbstractValidator<int>
    {
        public GetBlogValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Blogs.Any(c => c.Id == x))
               .WithMessage("This blog doesnt exists in database");

        }
    }
}
