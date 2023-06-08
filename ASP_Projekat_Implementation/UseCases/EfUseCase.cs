using ASP_Projekat_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Projekat_Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected BlogContext Context { get; }

        protected EfUseCase(BlogContext context)
        {
            Context = context;
        }
    }
}
