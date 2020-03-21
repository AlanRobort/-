using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Viewmodel;

namespace WebApi.Interface
{
   public interface ICustomersInterface
    {
        //获取用户列表
        Task<IEnumerable<Customer>> GetCustomersasync();

        //获取单个用户
        Task<Customer> GetCustomerasync(int id);

        //添加用户
        Task<bool> AddCustomerasync(Customer model);

        //修改用户
        Task<bool> UpdateCustomersasync(Customer model);

        //删除用户 
        Task<bool> DeleteCustomersasync(int id);

        //顾客登陆
        Task<bool> CustomerLogin(CustomerLoginmodel model);


    }
}
