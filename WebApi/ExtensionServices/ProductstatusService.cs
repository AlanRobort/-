using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ExtensionServices
{
    public class ProductstatusService
    {
        public string Productstatus(bool ison)
        {
            if (ison)
            {
                return "上架";
            }

            return "下架";
        }
    }
}
