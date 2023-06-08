using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.Command.RoleCommands;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.RoleValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Commands.Roles
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private BlogContext _context;
        private CreateRoleValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateRoleCommand(BlogContext context, CreateRoleValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 6;

        public string Name => "Kreiranje uloge";

        public string Description => "Kreiranje uloge";

        public void Execute(CreateRoleDTO request)
        {
            _validator.ValidateAndThrow(request);


            bool tagExists = _context.Tags.Any(x => x.TagText.ToLower() ==
                                                                request.Name.ToLower());

            Role roles = new Role
            {
                RoleName = request.Name,
            };


            _context.Role.Add(roles);

            _context.SaveChanges();
        }
    }
}
