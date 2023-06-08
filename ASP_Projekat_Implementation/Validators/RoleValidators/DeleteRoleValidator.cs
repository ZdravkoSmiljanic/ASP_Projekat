using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.RoleValidators
{
    public class DeleteRoleValidator:AbstractValidator<int>
    {
        public DeleteRoleValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(id => id).NotEmpty();
            RuleFor(x => x)
               .Must(x => context.Role.Any(c => c.Id == x))
               .WithMessage("This tag doesnt exists in database");


        }
    }
}
