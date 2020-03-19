using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ExtensionServices
{
    public class PaginationBase
    {
        //默认分页大小
        private int _PageSize = 10;

        //分页最大值
        private int MaxPageSize = 100;

        public int PageIndex { get; set; } = 0;

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = value > MaxPageSize ? MaxPageSize : _PageSize;
        }
    }
}
