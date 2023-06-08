using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class Reaction:Entity
    {
        public string ReactionName { get; set; }
        public int ImageID { get; set; }

        public virtual Image Image { get; set; }
        public virtual ICollection<BlogReactions> BlogReactions { get; set; } = new List<BlogReactions>();
    }
}
