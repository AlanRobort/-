using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Customers
    {
        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        //身份证
        public string Idcard { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
