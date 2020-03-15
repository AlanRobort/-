using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Services
{
    public class ProductCategoryService : IProductCategoryInterface
    {
        private readonly ProductDbContext _productdb;

        public ProductCategoryService(ProductDbContext productdb)
        {
            _productdb = productdb;
        }

        /// <summary>
        /// 根据Id查询商品种类名字
        /// </summary>
        /// <param name="CategoryName"></param>
        /// <returns></returns>
        public async Task<int> GetProductCategoryId(string CategoryName)
        {
          var result = await _productdb.commodityCategories.FirstOrDefaultAsync(x => x.Categoryname == CategoryName);

          if (result != null)
          {
              return result.Id;
            }
          else
          {
              throw new Exception("未找到改商品类型Id");
          }


        }

        /// <summary>
        /// 查看所有种类
        /// </summary>
        /// <returns></returns>
        public Task<string> GetProductCategoryNames()
        {
            throw new NotImplementedException();
        }
    }
}
