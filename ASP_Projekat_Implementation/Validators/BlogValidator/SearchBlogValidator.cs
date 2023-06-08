using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.BlogValidator
{
    public class SearchBlogValidator:AbstractValidator<SerachBlogDTO>
    {
        public SearchBlogValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Keyword).NotEmpty();


        }
    }
}
