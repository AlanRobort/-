using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
   public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {

        }

        public DbSet<Administrator> administrators { get; set;}
        public DbSet<Commodity> commodities { get; set; }
        public DbSet<CommodityCategory> commodityCategories { get; set; }
        public DbSet<OrderInfo> orderInfos { get; set; }
        public DbSet<Salesrecord> salesrecords { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CommodityImgs> CommodityImgs { get; set; }

    }
}
