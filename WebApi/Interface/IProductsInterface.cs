using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Viewmodel;

namespace WebApi.Interface
{
   public interface IProductsInterface
   {
       Task<IEnumerable<CommoditymodelView>> GetProductsasync();
       Task<CommoditymodelView> GetProductsbyidasync(int id);
       Task<bool> Deleteasync(int id);
       Task<bool> UpdateProductsasync(Commodity model);
       Task<bool> AddProductsasync(CommoditymodelView model);
       Task<IEnumerable<CommoditymodelView>> GetCommoditiesList(int pageindex, int pagesize)
   }
}
