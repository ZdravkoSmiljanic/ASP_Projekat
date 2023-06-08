using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.Users;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.UserValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {

        private BlogContext _context;
        private UpdateUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfUpdateUserCommand(BlogContext context, UpdateUserValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 18;

        public string Name => "Izmena korisnika";

        public string Description => "Izmena korisnika";

        public void Execute(UpdateUserDTO request)
        {
            
                var user = _context.Users.Find(request.Id);
                 _validator.ValidateAndThrow(request);


                var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                user.Email = request.Email;
                user.Password = hash;
                user.UserName = request.Username;
                user.ProfileImgId = request.ProfileImageId;

                user.ModifiedAt = DateTime.UtcNow;
                _context.Entry(user).State = EntityState.Modified;

                _context.SaveChanges();



            }
            
    }
}

