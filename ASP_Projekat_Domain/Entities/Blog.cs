using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class Blog:Entity
    {
        public string BlogText { get; set; }
        public  int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BlogTag> BlogTags { get; set; } = new List<BlogTag>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<BlogImages> BlogImages { get; set; } = new List<BlogImages>();
        public virtual ICollection<BlogReactions> BlogReactions { get; set; } = new List<BlogReactions>();
    }
}
