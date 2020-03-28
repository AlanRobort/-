using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Viewmodel
{
    public class ComoditiesList
    {
        public int Id { get; set; }

        public string Commodityname { get; set; }

        public string Filepath { get; set; }

        public int Price { get; set; }

        public string Username { get; set; }

        public string Commoditycategoryname { get; set; }

        public string transactionway { get; set; }

        public bool status { get; set; }

        public string Desc { get; set; }
    }
}
