using ASP_Projekat_Application;
using ASP_Projekat_Application.UseCases;
using ASP_Projekat_Application.UseCases.DTO;
using ASP_Projekat_Application.UseCases.Queries;
using ASP_Projekat_Application.UseCases.Queries.Searches;
using ASP_Projekat_Domain;
using ASP_Projekat_Implementation.Validators.CommentValidators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases.Queries
{
    public class EfSearchCommentQuery : ISearchCommentQuery
    {
        private BlogContext _context;
        private SearchCommentValidator _validator;
        private readonly IApplicationActor _actor;

        public EfSearchCommentQuery(BlogContext context, SearchCommentValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }
        public int Id => 32;

        public string Name => "Pretraga komenata po kljucnoj reci";

        public string Description => "Pretraga komenata po kljucnoj reci";

        public List<ReadCommentDTO> Execute(SearchCommnetDTO search)
        {
            var query = _context.Comments.Include(x => x.User).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.TextComment.Contains(search.Keyword) || x.User.UserName.Contains(search.Keyword));
            }

            var data = query.Select(y => new ReadCommentDTO
            {
                CreateAt = y.CreatedAt,
                UserName = _context.Users.Where(x => x.Id == y.UserId).Select(x => x.UserName).First(),
                Text = y.TextComment,
                ChildComments = _context.Comments.Where(x => x.ParentId == y.Id).Select(x => new SubCommentsDTO
                {
                    TextSubComment = x.TextComment
                }).ToList()
            }).ToList();
            
            return data;
        }
    }
}
