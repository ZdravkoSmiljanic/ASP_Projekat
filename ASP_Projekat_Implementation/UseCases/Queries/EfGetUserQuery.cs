using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.UserValidator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private BlogContext _context;
        private SearchUserIdValidator _validator;
        private readonly IApplicationActor _actor;
        public EfGetUserQuery(BlogContext context, SearchUserIdValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 14;

        public string Name => "Dohvatanje user po id";

        public string Description => "Dohvatanje user po id";



        

        ReadUserDTO IQuery<int, ReadUserDTO>.Execute(int search)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == search);
            _validator.ValidateAndThrow(search);

            var users = new ReadUserDTO
            {
                Email = user.Email,
                UserName = user.UserName,
                FirstName = user.Name,
                LastName = user.Surname,
                Role = _context.Role.Select(x => x.RoleName).First(),
                ProfilImage = _context.Images.Select(x => x.ImagePath).First(),
                Blogs = _context.Blogs.Where(x => x.UserId == user.Id).Select(x => new ReadUserBlogDTO
                {
                    BlogText = x.BlogText,
                    id = x.Id
                }).ToList(),
                Comments = _context.Comments.Where(x => x.UserId == user.Id).Select(x => new ReadUserCommentsDTO
                {
                    BlogId = x.BlogId,
                    TextComment = x.TextComment,
                    ParentId = x.ParentId
                }).ToList(),


            };
            return users;
        }
    }
}
