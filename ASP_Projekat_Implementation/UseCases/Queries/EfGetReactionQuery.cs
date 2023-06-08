using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ReactionValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetReactionQuery : IGetReactionQuery
    {
        private BlogContext _context;
        private GetReactionValidator _validator;
        private readonly IApplicationActor _actor;

        public int Id => 11;

        public string Name => "Pretraga reakcija";

        public string Description => "Pretraga reakcija";

        public EfGetReactionQuery(BlogContext context, GetReactionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public ReadReactionDTO Execute(int search)
        {

            Reaction reaction = _context.Reactions.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);

            var reactions = new ReadReactionDTO
            {
                Id = reaction.Id,
                IsActive = reaction.IsActive,
                Name = reaction.ReactionName,
                ImagePath = _context.Images.Select(x => x.ImagePath).First(),

            };
            return (reactions);


        }
    }
}
