using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ResourceParameter
{
    public class UsersParameter
    {
        private const int MaxPageSize = 20;

        public string  SearchItem { get; set; }

        public int PageNumber { get; set; } = 1;
   
        private int _PageSize = 2;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value > MaxPageSize ? MaxPageSize:value; }
        }

    }
}
