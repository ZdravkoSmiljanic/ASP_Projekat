using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class BlogImages
    {
        public int BlogId { get; set; }
        public int ImageId { get; set; }

        public virtual Image Image { get; set; }
        public virtual Blog Blog{ get; set; }
    }
}
