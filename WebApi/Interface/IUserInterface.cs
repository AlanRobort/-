using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Viewmodel;

namespace WebApi.Interface
{
   public interface IUserInterface
   {
       Task<Users> Userlogin(Userloginmodel userloginmodel);
   }
}
