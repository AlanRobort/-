using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;

namespace WebApi.Services
{
    public class ImgsService: IImgsInterface
    {
        private readonly ProductDbContext _productdb;

        public ImgsService(ProductDbContext productdb)
        {
            _productdb = productdb;
        }


        /// <summary>
        /// 添加图片
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddImg(CommodityImgs commodityImgs)
        {
            if (commodityImgs != null)
            {
                await _productdb.CommodityImgs.AddAsync(commodityImgs);
                var result = await _productdb.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取图片
        /// 获取图片针对查看商品的时候用到
        /// 上传图片时候，只需要添加和删除
        /// </summary>
        /// <returns></returns>
        public Task<CommodityImgs> GetImgs(string imgurl)
        {
            //imurl 参数应该是相对路径
            //数据库保存的时候也应该是相对路径
            throw new NotImplementedException();
        }


        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id">图片Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteImg(int id)
        {
         var result = await _productdb.CommodityImgs.FirstOrDefaultAsync(x => x.Id == id);
         if (result != null)
         {
             _productdb.CommodityImgs.Remove(result);
             var changesnum = await _productdb.SaveChangesAsync();
                if (changesnum > 0)
                {
                    return true;
                }
                return false;   
         }

         return false;
        }
    }
}
