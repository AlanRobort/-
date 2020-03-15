using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
   public  interface IProductCategoryInterface
    {
        //根据Id查询商品种类
        Task<int> GetProductCategoryId(string CategoryName);

        //查看所有种类
        Task<string> GetProductCategoryNames();
    }
}
