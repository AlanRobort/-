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
        private const int MaxPageSize = 20;

        public int PageNumber { get; set; } = 1;

        private int _PageSize = 5;

        public int PageSize
        {
            //get { return _PageSize; }
            //set { _PageSize = value>MaxPageSize?MaxPageSize:value; }
            get => _PageSize;
            set => _PageSize = (value > MaxPageSize ? MaxPageSize : value);
        }







    }
}
