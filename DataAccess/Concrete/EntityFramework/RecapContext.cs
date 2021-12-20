﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;  
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework 
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class RecapContext : DbContext
    {
        //proje hangi veritabanıyla ilişkili  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=RecapProject;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; } 

    }

}
