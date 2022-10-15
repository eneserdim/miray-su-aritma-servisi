using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALPAY_WEP_PROJECT.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceArea> ServiceAreas { get; set; }
        public DbSet<User> Users { get; set; }

    }
}