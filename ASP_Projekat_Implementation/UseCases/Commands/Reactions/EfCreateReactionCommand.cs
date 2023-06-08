using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.ReactionCommand;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.ReactionValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Reactions
{
    public class EfCreateReactionCommand : ICreateReactionCommand
    {
        private BlogContext _context;
        private CreateReactionValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateReactionCommand(BlogContext context, CreateReactionValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 12;

        public string Name => "Kreiranje reakcije";

        public string Description => "DOdavanje nove reakcije u bazu podataka";

        public void Execute(CreateReactionDTO request)
        {

                _validator.ValidateAndThrow(request);

                Reaction reaction = new Reaction
                    {
                        ReactionName = request.ReactionName,
                        ImageID = request.ImageId
                    };


                _context.Reactions.Add(reaction);

                _context.SaveChanges();



        }
    }
}
