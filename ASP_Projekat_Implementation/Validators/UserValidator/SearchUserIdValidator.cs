using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.UserValidator
{
    public class SearchUserIdValidator:AbstractValidator<int>
    {
        public SearchUserIdValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Users.Any(c => c.Id == x))
               .WithMessage("This user doesnt exists in database");


        }
    }
}
