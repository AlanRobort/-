using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;
using WebApi.ResourceParameter;
using WebApi.Viewmodel;

namespace WebApi.Services
{
    public class Userservice : IUserInterface
    {
        private readonly ProductDbContext _dbContext;

        public Userservice(ProductDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUsersasync(int id)
        {
            var result = await GetUserasync(id);
            if (result != null)
            {
               _dbContext.users.Remove(result);
               var num = await _dbContext.SaveChangesAsync();
               if (num > 0)
               {
                   return true;
               }
    
            }

            return false;
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Users> GetUserasync(int id)
        {
            if (id >= 0)
            {
                var result = await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    return result;
                }
            }
            throw new Exception("数据库中没有该数据");

        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Users>> GetUsersasync(UsersParameter usersParameter)
        {
            var result = new List<Users>();
            if (usersParameter.SearchItem == null)
            {
                result = await _dbContext.users.ToListAsync();
                return result;
            }

            var query = from users in _dbContext.users
                where (users.Username.Contains(usersParameter.SearchItem) ||
                       (users.Phone.Contains(usersParameter.SearchItem)))
                select new Users
                {
                    Id = users.Id,
                    Username = users.Username,
                    password = users.password,
                    Phone = users.Phone,
                    Address = users.Address,
                    email = users.email
                };

            result = await query.ToListAsync();

            return result.Skip(usersParameter.PageSize * (usersParameter.PageNumber - 1))
                .Take(usersParameter.PageSize);


        }


        /// <summary>
        /// 用户跟新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserasync(Users model)
        {
            var result = await GetUserasync(model.Id);

            if (result != null)
            {

               // _dbContext.users.Update(model);
               result.Username = model.Username;
               result.password = model.password;
               result.Phone = model.Phone;
               result.Address = model.Address;
               result.email = model.email;
               result.socre = model.socre;

             var num =  await _dbContext.SaveChangesAsync();

             if (num > 0)
             {
                 return true;
             }

            }

            return false;
        }

        /// <summary>
        /// 后台用户登陆
        /// </summary>
        /// <param name="userlogin"></param>
        /// <returns></returns>
        public async Task<Users> Userlogin(Userloginmodel userlogin)
        {
           var result = await _dbContext.users.FirstOrDefaultAsync(x => x.Username == userlogin.username && x.password == userlogin.password);
           return result;
        }

        /// <summary>
        /// 后台用户添加
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        public async Task<bool> AddUser(Users usermodel)
        {
            if (usermodel != null)
            {
              await  _dbContext.users.AddAsync(usermodel);
              var num =await  _dbContext.SaveChangesAsync();
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
