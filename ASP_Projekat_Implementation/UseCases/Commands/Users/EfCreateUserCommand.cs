using ASP_Projekat_Application;
using ASP_Projekat_Application.Email;
using ASP_Projekat_Application.UseCases.Command.Users;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.UserValidator;
using BCrypt.Net;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Users
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private BlogContext _context;
        private CreateUserValidator _validator; 
        private readonly IEmailSend _sender;


        public EfCreateUserCommand(BlogContext context, CreateUserValidator validator, IEmailSend sender)
        {
            _context = context;
            _validator = validator;

            _sender = sender;
        }
        public int Id => 17;

        public string Name => "Registracija usera";

        public string Description => "Registracija usera";

        public void Execute(CreateUserDTO request)
        {
            var user=new User();

            _validator.ValidateAndThrow(request);
            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            if (!string.IsNullOrEmpty(request.ImageFileName))
            {
                var image = new Image { ImagePath = request.ImageFileName };
                

                user.Email = request.Email;
                user.UserName = request.UserName;
                user.ProfileImgId = image.Id;
                user.Name = request.Name;
                user.Password = hash;
                user.Surname = request.Surname;
                user.RoleId = 7;
                user.Image = new Image
                {
                    ImagePath = image.ImagePath,
                    ImageSize = 50
                };
                

            }
            else
            {
                user.Email = request.Email;
                user.UserName = request.UserName;
                user.Name = request.Name;
                user.Password = hash;
                user.Surname = request.Surname;
                user.RoleId = 7;
            }
            


                 _context.Users.Add(user);
                 _context.SaveChanges();

            //_sender.Send(new MailMessages
            //{

            //    To = request.Email,
            //    From = "asp@ict.edu.rs",
            //    Title = "Successfull registration!",
            //    Body = "Dear " + request.UserName + "\n Please activate your account...."
            //});








        }
    }
}
