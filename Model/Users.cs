﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //系统用户
    //对系统用户做一些权限
   public class Users
    {
        public int Id { get; set;}
        public string Username { get; set;}
        public string password { get; set; }
        //int32太短对于手机来说
        public string Phone { get; set;}
        public string Address { get; set;}
        public string email { get; set; }
        
        public int socre { get; set; }
    }
}
