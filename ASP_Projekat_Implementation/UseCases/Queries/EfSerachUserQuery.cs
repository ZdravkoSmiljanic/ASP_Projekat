using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.UserValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfSerachUserQuery : ISearchUser
    {
        private BlogContext _context;
        private SearchUserValidator _validator;
        private readonly IApplicationActor _actor;

        public EfSerachUserQuery(BlogContext context, SearchUserValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 15;

        public string Name => "Pretraga user po kljucnoj reci";

        public string Description => "Pretraga user po kljucnoj reci";

        public List<ReadUserDTO> Execute(SearchUsersDTO search)
        {

                _validator.ValidateAndThrow(search);
                var query = _context.Users.Include(x => x.Blogs).ThenInclude(x => x.User)
                                          .Include(x => x.Comments).ThenInclude(x => x.User)
                                          .Include(x => x.Image).AsQueryable();

                if (!string.IsNullOrEmpty(search.keyword))
                {
                    query = query.Where(x => x.UserName.Contains(search.keyword) ||
                                         x.Email.Contains(search.keyword) ||
                                         x.Name.Contains(search.keyword) ||
                                         x.Surname.Contains(search.keyword));
                }
                if (search.HasBlogs.HasValue)
                {
                    if (search.HasBlogs.Value)
                    {
                        query = query.Where(x => x.Blogs.Any());

                    }
                    if (!search.HasBlogs.Value)
                    {
                        query = query.Where(x => !x.Blogs.Any());

                    }
                }
                if (search.HasComments.HasValue)
                {
                    if (search.HasComments.Value)
                    {
                        query = query.Where(x => x.Comments.Any());

                    }
                    if (!search.HasComments.Value)
                    {
                        query = query.Where(x => !x.Comments.Any());

                    }
                }

                var data = query.Select(x => new ReadUserDTO
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    FirstName = x.Name,
                    LastName = x.Surname,
                    Role = _context.Role.Select(x => x.RoleName).First(),
                    ProfilImage = _context.Images.Select(x => x.ImagePath).First(),
                    Blogs = _context.Blogs.Where(z => z.UserId == x.Id).Select(y => new ReadUserBlogDTO
                    {
                        BlogText = y.BlogText,
                        id = y.Id,
                    }).ToList(),
                    Comments = _context.Comments.Where(z => z.UserId == x.Id).Select(y => new ReadUserCommentsDTO
                    {
                        BlogId = y.BlogId,
                        ParentId = y.ParentId,
                        TextComment = y.TextComment
                    }).ToList()
                }).ToList();


                return (data);


           
        }
    }
}
