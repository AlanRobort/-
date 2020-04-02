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
       

    }
}
