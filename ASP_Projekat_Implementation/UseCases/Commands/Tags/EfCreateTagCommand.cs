using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.TagCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.TagValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Tags
{
    public class EfCreateTagCommand : ICreateTagCommand
    {

        private BlogContext _context;
        private CreateTagValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateTagCommand(BlogContext context, CreateTagValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 1;

        public string Name => "Kreiranje taga";

        public string Description => "Komanda za unos novog taga unutar tabele tags";

        public void Execute(CreateTagDTO request)
        {
            _validator.ValidateAndThrow(request);


            bool tagExists = _context.Tags.Any(x => x.TagText.ToLower() ==
                                                                request.Name.ToLower());

            Tag tag = new Tag
            {
                TagText = request.Name,
            };


            _context.Tags.Add(tag);

            _context.SaveChanges();
        }
    }
}
