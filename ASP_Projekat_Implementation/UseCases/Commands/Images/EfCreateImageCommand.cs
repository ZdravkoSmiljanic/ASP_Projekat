using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.ImageCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ImageValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Images
{
    public class EfCreateImageCommand : ICreateImageCommand
    {
        private BlogContext _context;
        private CreateImageValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateImageCommand(BlogContext context, CreateImageValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 9;

        public string Name => "Kreiranje slike";

        public string Description => "Kreiranje slike";

        public void Execute(CreateImageDTO request)
        {
            _validator.ValidateAndThrow(request);



            Image image= new Image
            {
                ImageSize=request.ImageSize,
                ImagePath=request.ImagePath
            };


            _context.Images.Add(image);

            _context.SaveChanges();
        }
    }
}
