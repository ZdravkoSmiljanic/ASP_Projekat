using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.RoleValidators
{
    public class GetRoleValidator: AbstractValidator<int>
    {
        public GetRoleValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Role.Any(c => c.Id == x))
               .WithMessage("This role doesnt exists in database");


        }
    }
}
