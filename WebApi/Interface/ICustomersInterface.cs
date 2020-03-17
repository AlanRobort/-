using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interface
{
   public interface ICustomersInterface
    {
        //获取用户列表
        Task<IEnumerable<Customers>> GetCustomersasync();

        //获取单个用户
        Task<Customers> GetCustomerasync(int id);

        //添加用户
        Task<bool> AddCustomerasync(Customers model);

        //修改用户
        Task<bool> UpdateCustomersasync(Customers model);

        //删除用户
        Task<bool> DeleteCustomersasync(int id);
    }
}
