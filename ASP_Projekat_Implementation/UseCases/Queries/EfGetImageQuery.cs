using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ImageValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetImageQuery : IGetImageQuery
    {
        private BlogContext _context;
        private GetImageValidator _validator;
        private readonly IApplicationActor _actor;
        public EfGetImageQuery(BlogContext context, GetImageValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 7;

        public string Name => "Dohvatanje slika";

        public string Description => "Dohvatanje slika";

        public ReadImageDTO Execute(int search)
        {
            Image image = _context.Images.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var tags = new ReadImageDTO
            {
                Id = image.Id,
                IsActive = image.IsActive,
                ImagePath = image.ImagePath,
                ImageSize =image.ImageSize
            };
            return (tags);
        }
    }
}
