using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.RoleValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetRoleQuery : IGetRoleQuery
    {
        private BlogContext _context;
        private GetRoleValidator _validator;
        private readonly IApplicationActor _actor;
        public EfGetRoleQuery(BlogContext context, GetRoleValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 4;

        public string Name => "Dohvatanje uloga po id";

        public string Description => "Dohvatanje uloga po id";

        public ReadRoleDTO Execute(int search)
        {

            Role role = _context.Role.FirstOrDefault(x => x.Id == search);

            _validator.ValidateAndThrow(search);


            var roles = new ReadRoleDTO
            {
                Id = role.Id,
                IsActive = role.IsActive,
                Name = role.RoleName
            };
            return (roles);

        }
    }
}
