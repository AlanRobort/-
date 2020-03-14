using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;
using WebApi.Viewmodel;

namespace WebApi.Services
{
    public class ProductsService : IProductsInterface
    {
        private readonly ProductDbContext _productdb;

        public ProductsService(ProductDbContext productdb) 
        {
            _productdb = productdb;
        }

        public async Task<bool> AddProductsasync(Commodity model)
        {
            try
            {
                if (model != null)
                {
                        await _productdb.commodities.AddAsync(model);
                        await _productdb.SaveChangesAsync();
                        return true; 
                  
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Deleteasync(int id)
        {
            try
            {
                var result = await _productdb.commodities.FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    _productdb.commodities.Remove(result);
                    var num = await _productdb.SaveChangesAsync();
                    if (num > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }

        public async Task<IEnumerable<CommoditymodelView>> GetProductsasync()
        {
            try
            {
                var result = new List<CommoditymodelView>();

                var query = from commodity in _productdb.commodities
                    join CommodityCategory in _productdb.commodityCategories
                        on commodity.CommoditycategoryId equals CommodityCategory.Id
                        join users in  _productdb.users
                            on commodity.UserId equals users.Id
                    select new CommoditymodelView
                    {
                        Id=commodity.Id,
                        Commodityname = commodity.Commodityname,
                        Filepath = commodity.Filepath,
                        Price = commodity.Price,
                        Username = users.Username,
                        Commoditycategory = CommodityCategory.Categoryname,
                        startdate = commodity.startdate,
                        transactionway = commodity.transactionway,
                        days = commodity.days,
                        expiredate = commodity.expiredate,
                        status = commodity.status
                        
                    };

                result = await query.ToListAsync();

                return result;
                //result = await _productdb.commodities.ToListAsync();
                //return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Task<Commodity> GetProductsbyidasync(int id)
        {
            try
            {
                if (id >= 0)
                {
                    var result = _productdb.commodities.FirstOrDefaultAsync(x => x.Id == id);
                    return result;
                }

                throw new Exception("未找到该商品");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        //First:返回序列中的第一条记录，如果没有记录，则引发异常。

        // FirstOrDefault:返回序列中的第一条记录，如果没有记录，则返回默认值。

        // Single:返回序列中的唯一记录，如果没有或返回多条记录，则引发异常。

        // SingleOrDefault:返回序列中的唯一记录；如果该序列为空，则返回默认值；如果该序列包含多个元素，则引发异常。
        public async Task<bool> UpdateProductsasync(Commodity model)
        {
            try
            {
                var original = await _productdb.commodities.SingleAsync(x => x.Id == model.Id);


                if (original != null)
                {
                    original.Id= model.Id;
                    original.Commodityname = model.Commodityname;
                    original.Filepath = model.Filepath;
                    original.Price = model.Price;
                    //需要对用户名进行查找
                    original.UserId = model.UserId;
                    //需要对分类进行查找
                    original.CommoditycategoryId = model.CommoditycategoryId;
                    original.startdate = model.startdate;
                    original.transactionway = model.transactionway;
                    original.days = model.days;
                    original.expiredate = model.expiredate;
                    original.status = model.status;

                    // original = model;

                    await _productdb.SaveChangesAsync();
                    return true;


                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //存商品图片

        //获取商品图片
    }
}
