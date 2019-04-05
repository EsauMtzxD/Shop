using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class DataDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

    }
}
