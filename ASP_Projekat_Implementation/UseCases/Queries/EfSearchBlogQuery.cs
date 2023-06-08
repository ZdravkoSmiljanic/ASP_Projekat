using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Extensions;
using ASP_Projekat_Implementation.Validators.BlogValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfSearchBlogQuery : ISearchBlog
    {
        private BlogContext _context;
        private SearchBlogValidator _validator;
        private readonly IApplicationActor _actor;

        public EfSearchBlogQuery(BlogContext context, SearchBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 22;

        public string Name => "Pretraga blogova";

        public string Description => "Pretraga blogova po kljucnoj reci i po komentarima i po reakcijama";

        public PageResponed<ReadBlogDTO> Execute(SerachBlogDTO search)
        {
            _validator.ValidateAndThrow(search);

            var query = _context.Blogs.Include(x => x.User)
                                      .Include(x => x.BlogReactions).ThenInclude(x => x.Reaction).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.BlogText.Contains(search.Keyword) || x.User.UserName.Contains(search.Keyword));
            }
            if (search.HasReactions.HasValue)
            {
                if (search.HasReactions.Value)
                {
                    query = query.Where(x => x.BlogReactions.Any());

                }
                if (!search.HasReactions.Value)
                {
                    query = query.Where(x => !x.BlogReactions.Any());

                }
            }
            var data = query.ToPagedResponse<Blog, ReadBlogDTO>(search,y => new ReadBlogDTO
            {
                CreatedAt = y.CreatedAt,
                TextContent = y.BlogText,
                FullName = _context.Users.Where(x => x.Id == y.UserId).Select(x => x.Name).First() + " " + _context.Users.Where(x => x.Id == y.UserId).Select(x => x.Surname).First(),
                Username = _context.Users.Where(x => x.Id == y.UserId).Select(x => x.UserName).First(),
                ReadBlogComments = _context.Comments.Where(x => x.BlogId == y.Id).Select(x => new ReadBlogComments
                {
                    ParentId = x.ParentId,
                    TextComment = x.TextComment
                }).ToList(),
                ReadBlogReactions = _context.BlogReactions.Where(x => x.BlogId == y.Id).Select(x => new ReadBlogReactions
                {
                    UserReacted = x.User.UserName,
                    ReactionName = x.Reaction.ReactionName,

                }).ToList()

            });
            return (data);
        }
    }
}
