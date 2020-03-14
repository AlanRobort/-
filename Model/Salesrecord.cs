using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //销售记录
   public class Salesrecord
    {
        public int Id { get; set;}
        public int Categoryid { get; set;}
        public int Commdityid { get; set;}
        public int Userid { get; set; }
        public string Startdatetime { get; set; }
        public string OrderUser { get; set; }
        public bool isfinally { get; set; }
    }
}
