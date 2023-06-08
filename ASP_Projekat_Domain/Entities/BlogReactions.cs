using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class BlogReactions
    {
        public int BlogId { get; set; }
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReactedAt { get; set; }
        public DateTime? DeletedAt{ get; set; }
        public bool? IsActive{ get; set; }

        public User User { get; set; }
        public Blog Blog { get; set; }
        public Reaction Reaction { get; set; }
    }
}
