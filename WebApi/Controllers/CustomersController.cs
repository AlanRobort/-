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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersInterface _customers;

        public CustomersController(ICustomersInterface customers)
        {
            _customers = customers;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var result = await _customers.GetCustomersasync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if (id >= 0)
            {
            var result = await _customers.GetCustomerasync(id);
                if (result != null)
                    return StatusCode(200, result);

            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
           
             var isdelete = await  _customers.DeleteCustomersasync(id);
             if (isdelete == true)
             {
                 return Ok();
             }

             return BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody]Customer customersmodel)
        {
         var result = await _customers.AddCustomerasync(customersmodel);
         if (result)
         {
             return Ok();
         }

         return StatusCode(400,"传输中错误");
        }

        /// <summary>
        /// 跟新顾客信息，后续需要根据密码MD5加密问题
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var result = await _customers.UpdateCustomersasync(customer);
            return Ok();
        }



        //[HttpPost]
        //public async Task<IActionResult> Registere(RegisteredUserViewmodel model)
        //{

        //}

       


        


    }
}