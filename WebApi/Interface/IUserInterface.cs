using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ResourceParameter;
using WebApi.Viewmodel;

namespace WebApi.Interface
{
   public interface IUserInterface
   {
       /// <summary>
       /// 后台用户登陆
       /// </summary>
       /// <param name="userloginmodel"></param>
       /// <returns></returns>
       Task<Users> Userlogin(Userloginmodel userloginmodel);

       /// <summary>
       /// 获取用户列表
       /// </summary>
       /// <returns></returns>
       Task<IEnumerable<Users>> GetUsersasync(UsersParameter model);


       /// <summary>
       /// 获取单个用户
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       Task<Users> GetUserasync(int id);

       /// <summary>
       /// 跟新用户
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       Task<bool> UpdateUserasync(Users model);


       /// <summary>
       /// 删除用户
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       Task<bool> DeleteUsersasync(int id);

        /// <summary>
        /// 后台用户添加
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        Task<bool> AddUser(Users usermodel);

   }
}
