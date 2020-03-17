using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using WebApi.Interface;

namespace WebApi.Services
{
    public class CustomersService : ICustomersInterface
    {
        private readonly ProductDbContext _dbContext;

        public CustomersService(
            ProductDbContext dbContext 
           )
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加顾客
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddCustomerasync(Customers model)
        {
            if (model != null)
            {
                await _dbContext.Customers.AddAsync(model);
                var result = await _dbContext.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// 删除顾客
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCustomersasync(int id)
        {
          
              var result = await GetCustomerasync(id);
                _dbContext.Customers.Remove(result);
              var num =  await _dbContext.SaveChangesAsync();
             if (num > 0)
             {
                 return true;
             }

             return false;
        }

        /// <summary>
        /// 获取单个顾客信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<Customers> GetCustomerasync(int id)
        {
           
               var result = await _dbContext.Customers.FirstOrDefaultAsync(x=>x.Id==id);

               return result;
        }

        /// <summary>
        /// 获取所有顾客信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customers>> GetCustomersasync()
        {
            var result = await _dbContext.Customers.ToListAsync();
            return result;
        }

        /// <summary>
        /// 更新客户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCustomersasync(Customers model)
        {
            var result = await GetCustomerasync(model.Id);

            if (result != null)
            {

                _dbContext.Customers.Update(model);
                var num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return true;
                }
               
                    return false;
            }
            return false;
        }
    }
}
