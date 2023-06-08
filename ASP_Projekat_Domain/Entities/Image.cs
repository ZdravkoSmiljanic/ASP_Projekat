using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_DataAccess.Entities
{
    public class Image:Entity
    {
        public string ImagePath { get; set; }
        public int ImageSize { get; set; }

        public virtual ICollection<BlogImages> BlogImages { get; set; } = new List<BlogImages>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
