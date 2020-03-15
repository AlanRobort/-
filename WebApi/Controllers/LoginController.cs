using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interface;
using WebApi.Viewmodel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserInterface _user;

        public LoginController(IUserInterface user)
        {
            _user = user;
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(Userloginmodel userlogin)
        {
             var result = await _user.Userlogin(userlogin);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
            throw new Exception("登陆失败，用户名或密码错误");
        }


        //[HttpGet]
        //public async Task<IActionResult> GetUser()
        //{



        //    return Ok();
        //}
    }
}