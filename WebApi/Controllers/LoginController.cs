using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Interface;
using WebApi.Viewmodel;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserInterface _user;
        private readonly ICustomersInterface _customers;

        public LoginController(IUserInterface user,ICustomersInterface customers)
        {
            _user = user;
            _customers = customers;
        }


        /// <summary>
        /// 系统用户登陆
        /// </summary>
        /// <param name="userlogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserLogin(Userloginmodel userlogin)
        {
             var result = await _user.Userlogin(userlogin);
            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
            //throw new Exception("登陆失败，用户名或密码错误");
        }


        /// <summary>
        /// 顾客前台登陆,通过视图model(CustomerLoginmodel)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CustomerLogin(CustomerLoginmodel model)
        {
            var result = await _customers.CustomerLoginasync(model);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

     

        /// <summary>
        /// 用户注册
        /// 1.获取用户名是否有重复
        /// 2.如果不重复则添加用户，如果重复则返回400状态码给前台
        /// 3.获取email检测邮箱是否重复
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Registered(RegisteredUserViewmodel model)
        {
            var result =await _customers.CustomerRegistered(model);

            if (result)
            {
                return Ok("注册成功");
            }
            else
            {
                return BadRequest("注册失败");
            }
        }


    }
}