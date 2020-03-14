using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Commodity
    {
        public int Id { get; set; }
        public string Commodityname { get; set; }
        public string Filepath { get; set; }
        public int Price { get; set;}
        //添加商品时候需要自动记录用户名ID
        public int UserId { get; set; }
        //添加种类是需要根据种类名转换成对应的ID
        public int CommoditycategoryId { get; set;}
        public string startdate { get; set; }
        //交易方式 线上 和 线下
        public string transactionway { get; set; }
        public int days { get; set; }
        public string expiredate { get; set; }
        //是否处于上架
        public bool status { get; set; }

    }
}
