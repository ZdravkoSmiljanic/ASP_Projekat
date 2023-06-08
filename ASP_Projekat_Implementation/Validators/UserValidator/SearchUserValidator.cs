using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.UserValidator
{
    public class SearchUserValidator:AbstractValidator<SearchUsersDTO>
    {
        public SearchUserValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.keyword).NotEmpty();


        }
    }
}
