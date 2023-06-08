using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.Validators.UserValidator
{
    public class CreateUserValidator:AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .Must(x => !context.Users.Any(u => u.Email == x))
                .WithMessage("This Email is already in use.");

            RuleFor(x => x.UserName)
             .NotEmpty()
             .WithMessage("UserName is requiredd.")
             .Matches("^(?=.{3,12}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")
             .WithMessage("Invalid username format. Min 3 characters - allowed letters, digits, . and _")
             .Must(x => !context.Users.Any(u => u.UserName == x))
             .WithMessage("This username is already in use.");

            RuleFor(x => x.Password).NotEmpty()
               .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
               .WithMessage("Password isnt in good format.");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
          
          
            


        }

    }
}
