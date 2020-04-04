using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;
using WebApi.Viewmodel;
using Microsoft.AspNetCore.Hosting;
using WebApi.ExtensionServices;
using WebApi.ResourceParameter;

namespace WebApi.Services
{
    public class ProductsService : IProductsInterface
    {
        private readonly ProductDbContext _productdb;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsService(
            ProductDbContext productdb, 
            IHostingEnvironment hostingEnvironment) 
        {
            _productdb = productdb;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AddProductsasync(CommoditymodelView model)
        {
            try
            {

                var Commoditycategory =
                  await  _productdb.commodityCategories.FirstOrDefaultAsync(x => x.Categoryname == model.Commoditycategoryname);

                if (Commoditycategory == null)
                {
                    throw new Exception("数据错误");
                }

                var CommoditycategoryId = Commoditycategory.Id;


                var user =
                    await _productdb.users.FirstOrDefaultAsync(x => x.Username == model.Username);

                if (user == null)
                {
                    throw new Exception("数据错误");
                }

                var userId = user.Id;


                if (model != null)
                {
                    var Comdity = new Commodity();
                    Comdity.Id = model.Id;
                    Comdity.Commodityname = model.Commodityname;
                    Comdity.Filepath = model.Filepath;
                    Comdity.phone = model.phone;
                    Comdity.Price = model.Price;
                    Comdity.UserId = userId;
                    Comdity.CommoditycategoryId = CommoditycategoryId;
                    Comdity.startdate = model.startdate;
                    Comdity.transactionway= model.transactionway;
                    Comdity.expiredate = model.expiredate;
                    Comdity.status = model.status;
                    Comdity.Desc = model.Desc;

                    await _productdb.commodities.AddAsync(Comdity);
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
        /// <summary>
        /// 获取上部商品信息
        /// </summary>
        /// <param name="parameter">
        ///根据parameter 进行过滤和搜索
        /// </param>
        /// <returns></returns>
        public async Task<IEnumerable<CommoditymodelView>> GetProductsasync(CommodityParameter parameter)
        {
            var result = new List<CommoditymodelView>();
            var WebServerPath = _hostingEnvironment.ContentRootPath;
            try
            {
                if (string.IsNullOrWhiteSpace(parameter.Commoditycategoryname) &&
                    string.IsNullOrWhiteSpace(parameter.Commodityname) &&
                    string.IsNullOrWhiteSpace(parameter.transactionway)&&
                    string.IsNullOrWhiteSpace(parameter.SearchItem))
                {
                    

                    var query = from commodity in _productdb.commodities
                        join CommodityCategory in _productdb.commodityCategories
                            on commodity.CommoditycategoryId equals CommodityCategory.Id
                        join users in _productdb.users
                            on commodity.UserId equals users.Id
                        select new CommoditymodelView
                        {
                            Id = commodity.Id,
                            Commodityname = commodity.Commodityname,
                            Filepath = WebServerPath + commodity.Filepath,
                            Price = commodity.Price,
                            //
                            Username = users.Username != null ? users.Username : null,
                            Commoditycategoryname = CommodityCategory.Categoryname != null ? CommodityCategory.Categoryname : "未选择商品类型",
                            startdate = commodity.startdate,
                            transactionway = commodity.transactionway,
                            // days = commodity.days,
                            expiredate = commodity.expiredate != null ? commodity.expiredate : null,
                            status = commodity.status != true ? false : false,
                            phone = commodity.phone != null ? commodity.phone : null

                        };
                    result = await query.ToListAsync();
                    return result;
                }
                
               // var queryExpression = _productdb.commodities as IQueryable<CommoditymodelView>;


                //商品名过滤
                if (!string.IsNullOrWhiteSpace(parameter.Commodityname))
                {
                    //获取服务器路径
                    //var WebServerPath = _hostingEnvironment.ContentRootPath;
                    //联查根据商品名过滤数据
                    var query = from commodity in _productdb.commodities
                        join CommodityCategory in _productdb.commodityCategories
                            on commodity.Id equals CommodityCategory.Id
                        join users in _productdb.users
                            on commodity.UserId equals users.Id
                       // where commodity.Commodityname == parameter.Commodityname
                        //模糊查询
                        where (commodity.Commodityname.Contains(parameter.Commodityname))
                        select new CommoditymodelView
                        {
                            Id = commodity.Id,
                            Commodityname = commodity.Commodityname,
                            Filepath = WebServerPath + commodity.Filepath,
                            Price = commodity.Price,
                            //
                            Username = users.Username != null ? users.Username : null,
                            Commoditycategoryname = CommodityCategory.Categoryname != null
                                ? CommodityCategory.Categoryname
                                : "未选择商品类型",
                            startdate = commodity.startdate,
                            transactionway = commodity.transactionway,
                            // days = commodity.days,
                            expiredate = commodity.expiredate != null ? commodity.expiredate : null,
                            status = commodity.status != true ? false : false,
                            phone = commodity.phone != null ? commodity.phone : null

                        };

                    result = await query.ToListAsync();
                    return result;




                    //parameter.Commodityname = parameter.Commodityname.Trim();
                    //queryExpression = queryExpression.Where(x => x.Commodityname == parameter.Commodityname);

                }

                //交易方式过滤

                //问题：过滤出来得数据，只显示商品为ID 1 和 2 的
                if (!string.IsNullOrWhiteSpace(parameter.transactionway))
                {
                    var query = from commodity in _productdb.commodities
                        join CommodityCategory in _productdb.commodityCategories
                            on commodity.Id equals CommodityCategory.Id
                        join users in _productdb.users
                            on commodity.UserId equals users.Id
                        where commodity.transactionway == parameter.transactionway
                        select new CommoditymodelView
                        {
                            Id = commodity.Id,
                            Commodityname = commodity.Commodityname,
                            Filepath = WebServerPath + commodity.Filepath,
                            Price = commodity.Price,
                            //
                            Username = users.Username != null ? users.Username : null,
                            Commoditycategoryname = CommodityCategory.Categoryname != null
                                ? CommodityCategory.Categoryname
                                : "未选择商品类型",
                            startdate = commodity.startdate,
                            transactionway = commodity.transactionway,
                            // days = commodity.days,
                            expiredate = commodity.expiredate != null ? commodity.expiredate : null,
                            status = commodity.status != true ? false : false,
                            phone = commodity.phone != null ? commodity.phone : null

                        };

                    result = await query.ToListAsync();
                    return result;

                }

                //商品类别过滤
                if (!string.IsNullOrWhiteSpace(parameter.Commoditycategoryname))
                {
                    var query = from commodity in _productdb.commodities
                        join CommodityCategory in _productdb.commodityCategories
                            on commodity.Id equals CommodityCategory.Id
                        join users in _productdb.users
                            on commodity.UserId equals users.Id
                        where CommodityCategory.Categoryname == parameter.Commoditycategoryname
                                select new CommoditymodelView
                        {
                            Id = commodity.Id,
                            Commodityname = commodity.Commodityname,
                            Filepath = WebServerPath + commodity.Filepath,
                            Price = commodity.Price,
                            //
                            Username = users.Username != null ? users.Username : null,
                            Commoditycategoryname = CommodityCategory.Categoryname != null
                                ? CommodityCategory.Categoryname
                                : "未选择商品类型",
                            startdate = commodity.startdate,
                            transactionway = commodity.transactionway,
                            // days = commodity.days,
                            expiredate = commodity.expiredate != null ? commodity.expiredate : null,
                            status = commodity.status != true ? false : false,
                            phone = commodity.phone != null ? commodity.phone : null

                        };

                    result = await query.ToListAsync();
                    return result;
                }


                //查询(多个关联的模糊查询)
                if (!string.IsNullOrWhiteSpace(parameter.SearchItem))
                {
                    //parameter.SearchItem = parameter.SearchItem.Trim();
                    //queryExpression = queryExpression.Where(x => x.Commodityname.Contains(parameter.SearchItem) ||
                    //                                            x.transactionway.Contains(parameter.SearchItem)||
                    //                                            x.Desc.Contains(parameter.SearchItem)||
                    //                                            x.Commoditycategoryname.Contains(parameter.SearchItem));
                }

               // return await queryExpression.ToListAsync();

                //var query = await _productdb.commodities.ToListAsync();


                // return query;

                //return query;
                //result = await _productdb.commodities.ToListAsync();
                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<string> Categoryname(int id)
        {
          var result = await  _productdb.commodityCategories.FirstOrDefaultAsync(x=>x.Id==id);
          return result.Categoryname;
        }


        public async Task<CommoditymodelView> GetProductsbyidasync(int id)
        {
            try
            {
                if (id >= 0)
                {

                    var result = await _productdb.commodities.FirstOrDefaultAsync(x => x.Id == id);
                    if (result != null)
                    {
                        var Commoditycategory =
                            await _productdb.commodityCategories.FirstOrDefaultAsync(x =>
                                x.Id == result.CommoditycategoryId);

                        var user =
                            await _productdb.users.FirstOrDefaultAsync(x => x.Id == result.UserId);

                        if (user == null)
                        {
                            throw new Exception("数据错误");
                        }

                        var modelView = new CommoditymodelView();
                        modelView.Id = result.Id;
                        modelView.Username = user.Username;
                        modelView.Commodityname = result.Commodityname;
                        modelView.Commoditycategoryname = Commoditycategory.Categoryname;
                        modelView.Price = result.Price;
                        modelView.phone = result.phone;
                        modelView.startdate = result.startdate;
                        modelView.status = result.status;
                        modelView.expiredate = result.expiredate;
                        modelView.transactionway = result.transactionway;
                        modelView.Desc = result.Desc;
                        modelView.Filepath = result.Filepath;

                        return modelView;

                    }

                    throw new Exception("未获取到数据");
                }

                throw new Exception("未找到该商品");
            }
            catch (Exception ex)
            {

                throw ex;
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

                var Commoditycategory =
                    await _productdb.commodityCategories.FirstOrDefaultAsync(x => x.Id == model.CommoditycategoryId);

                if (original != null)
                {
                    original.Id= model.Id;
                    original.Commodityname = model.Commodityname;
                    original.Filepath = model.Filepath;
                    original.Price = model.Price;
                    //需要对用户名进行查找
                    original.UserId = model.UserId;
                    //需要对分类进行查找
                    original.CommoditycategoryId = Commoditycategory.Id;
                    original.startdate = model.startdate;
                    original.transactionway = model.transactionway;
                    original.phone = model.phone;
                    //original.days = model.days;
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



        /// <summary>
        /// 商品分页
        /// 处理时有个问题，如何将数据和总行数同时传回去/
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        //public async Task<IEnumerable<CommoditymodelView>> GetCommoditiesList(int pageindex, int pagesize)
        //{
        //    IEnumerable<CommoditymodelView> CommoditiesList = new List<CommoditymodelView>();

        //    CommoditiesList = await GetProductsasync();

        //    return CommoditiesList.Skip((pageindex - 1) * pagesize).Take(pagesize);
        //    return null;

        //}




    }
}
