using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInterface _users;

        public UsersController(IUserInterface users)
        {
            _users = users;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Users>> GetUsers()
        {
          var result = await _users.GetUsersasync();
            return result;
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Users> GetUser(int id)
        {
            var result = await _users.GetUserasync(id);
            return result;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _users.DeleteUsersasync(id);
            if (result)
                return Ok();
            return BadRequest();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUsers(Users usermodel)
        {
           var result  = await  _users.AddUser(usermodel);
           if (result)
           {
               return Ok();
           }

           return BadRequest();
        }

        /// <summary>
        /// 用户跟新
        /// </summary>
        /// <param name="usermodel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUsers(Users usermodel)
        {
            var result = await _users.UpdateUserasync(usermodel);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}