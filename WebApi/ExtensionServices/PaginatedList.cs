using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ExtensionServices
{
    public class PaginatedList<T>:List<T> where T :class
    {

        public PaginationBase paginationBase { get; set; }

    }
}
