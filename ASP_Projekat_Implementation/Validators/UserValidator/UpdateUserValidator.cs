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
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator(BlogContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email).NotEmpty();
          
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

            RuleFor(x => x.Username)
                .Must((user, name) => !context.Users
                .Any(x => x.UserName == name && x.Id != user.Id)).WithMessage("This username is already taken");

            RuleFor(x => x.Email)
               .Must((user, name) => !context.Users
               .Any(x => x.Email == name && x.Id != user.Id)).WithMessage("This email is already taken");
            RuleFor(x => x.ProfileImageId).Must(x => !context.Images.Any(y => y.Id == x))
                .WithMessage("This image doesent exists. Please upload new file, or use our images");


        }

    }
}
