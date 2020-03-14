using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;
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
        public async Task<Users> Userlogin(Userloginmodel userlogin)
        {
           var result = await _dbContext.users.FirstOrDefaultAsync(x => x.Username == userlogin.username && x.password == userlogin.password);
           return result;
        }
    }
}
