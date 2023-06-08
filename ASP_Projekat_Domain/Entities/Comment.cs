using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class Comment:Entity
    {
        public int UserId { get; set; }
        public string TextComment { get; set; }
        public int BlogId { get; set; }
        public int? ParentId { get; set; }
        public DateTime CommentedAt{ get; set; }


        public virtual User User { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual Comment ParentCommnet { get; set; }
        public virtual ICollection<Comment> ChildComments { get; set; } = new List<Comment>();
    }
}
