using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_DataAccess.Entities;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.BlogValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfGetBlogQuery : IGetBlogQuery
    {
        private BlogContext _context;
        private GetBlogValidator _validator;
        private readonly IApplicationActor _actor;
        public EfGetBlogQuery(BlogContext context, GetBlogValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 21;

        public string Name => "Iscitavanje blog po id";

        public string Description => "Iscitavanje blog po id";

        public ReadBlogDTO Execute(int search)
        {
            
                Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == search);
                

                var blogforSearch = new ReadBlogDTO
                {
                    CreatedAt = blog.CreatedAt,
                    TextContent = blog.BlogText,
                    FullName = _context.Users.Where(x => x.Id == blog.UserId).Select(x => x.Name).First() + " " + _context.Users.Where(x => x.Id == blog.UserId).Select(x => x.Surname).First(),
                    Username = _context.Users.Where(x => x.Id == blog.UserId).Select(x => x.UserName).First(),
                    ReadBlogComments = _context.Comments.Where(x => x.BlogId == blog.Id).Select(x => new ReadBlogComments
                    {
                        ParentId = x.ParentId,
                        TextComment = x.TextComment
                    }).ToList(),
                    ReadBlogReactions = _context.BlogReactions.Where(x => x.BlogId == blog.Id).Select(x => new ReadBlogReactions
                    {
                        UserReacted = x.User.UserName,
                        ReactionName = x.Reaction.ReactionName,

                    }).ToList()

                };
                return (blogforSearch);


           
        }
    }
}
