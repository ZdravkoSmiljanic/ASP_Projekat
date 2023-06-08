using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.TagValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetTagQuery : IGetTagQuery
    {
        private BlogContext _context;
        private GetTagValidator _validator;
        private readonly IApplicationActor _actor;

        public int Id => 3;

        public string Name => "Dohvatanje taga po id";

        public string Description => "Dohvatanje taga po id";

        public EfGetTagQuery(BlogContext context, GetTagValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public ReadTagDTO Execute(int search)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var tags = new ReadTagDTO
            {
                Id = tag.Id,
                IsActive = tag.IsActive,
                Name = tag.TagText


            };
            return (tags);
        }
    }
}
