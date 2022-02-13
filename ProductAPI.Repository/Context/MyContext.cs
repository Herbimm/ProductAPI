using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Repository.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Product> Produtos { get; set; }
        //public dbset<cliente> clientes { get; set; }

       
    }
}
