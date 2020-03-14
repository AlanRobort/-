using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
  public interface IImgsInterface
    {
        //将图片放入数据库
        Task<bool> AddImg(CommodityImgs commodityImgs);

        //获取数据库中的图片
        Task<CommodityImgs> GetImgs(string imgurl);

        //删除图片
        Task<bool> DeleteImg(int id);
    }
}
