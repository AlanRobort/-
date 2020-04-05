using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ResourceParameter
{
    public class CommodityParameter
    {
        //查询
        public string SearchItem { get; set; }

        //过滤的
        public string Commoditycategoryname { get; set; }
        public string Commodityname { get; set; }
        public string transactionway { get; set; }
       

        //分页
        public int PageIndex { get; set; } = 0;

        //public int PageSize { get; set; }

        private int PageSize;

        public int _PageSize
        {
            get { return PageSize; }
            set { PageSize = value > 100 ? 100 : PageSize; }
        }


    }
}
