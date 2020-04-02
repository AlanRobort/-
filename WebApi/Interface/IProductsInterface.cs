using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.ResourceParameter;
using WebApi.Viewmodel;

namespace WebApi.Interface
{
    public interface IProductsInterface
   {
       Task<IEnumerable<CommoditymodelView>> GetProductsasync(CommodityParameter parameter);
       Task<CommoditymodelView> GetProductsbyidasync(int id);
       Task<bool> Deleteasync(int id);
       Task<bool> UpdateProductsasync(Commodity model);
       Task<bool> AddProductsasync(CommoditymodelView model);
      // Task<IEnumerable<CommoditymodelView>> GetCommoditiesList(int pageindex, int pagesize);
   }
}
