using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using WebApi.Interface;
using WebApi.Viewmodel;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsInterface _productsInterface;
        private readonly PictureOptions _pictureOptions;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(
            IProductsInterface productsInterface,
            IOptions<PictureOptions> pictureOptions,
            IHostingEnvironment hostingEnvironment
            )
        {
            _productsInterface = productsInterface;
            _pictureOptions = pictureOptions.Value;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public async Task<IEnumerable<CommoditymodelView>> GetProducts()
        {
           var result = await _productsInterface.GetProductsasync();
           return result;
        }

        [HttpGet("{id}")]
        public async Task<Commodity> GetProductsbyid(int id)
        {
            var result = await _productsInterface.GetProductsbyidasync(id);
            return result;
        }

        //HttpPatch 局部更新有问题，需要研究
        [HttpPut]
        public async Task<IActionResult> Updateproduct(Commodity model)
        {
            var result = await _productsInterface.UpdateProductsasync(model);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [EnableCors("AllowSpecificOrigin")]
        [HttpPost]
        public async Task<IActionResult> UploadImg([FromForm]IFormFile file)
        {
            if (file == null)
            {
                throw new Exception("文件获取失败");
            }
            var headerValue = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            
            var originalFileName = headerValue.FileName.Trim('"');
            var fileExt = originalFileName.Split(".")[1].Trim();
            var fileName = Guid.NewGuid().ToString() + "." + fileExt;
            Stream s = file.OpenReadStream();
            //string WebServerPath = _hostingEnvironment.ContentRootPath;
            string filepath = _hostingEnvironment.ContentRootPath + $"\\ImageServer\\" +fileName;
            using (var output = new FileStream(filepath, FileMode.Create))
            {
                //if (!File.Exists(filePath))
                //string name = "111111111111111111";
                await s.CopyToAsync(output);
            }
            //返回路径+文件名
            //var result = $"\\ImageServer\\" + fileName;





            //将保存的图片存入数据库
            //用on-success 去请求接口 获取文件路径

            
           
            
            //return StatusCode(200, new {newFileName = $"{result}"});

            return Ok();
        }












    }
}