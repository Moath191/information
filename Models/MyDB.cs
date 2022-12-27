using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace information.Models
{
    
    public class MyDB: DbContext
    {
public MyDB(DbContextOptions options) : base(options)
{}
public DbSet<Store> Stores{ set; get; }
public DbSet<Err> Erres{set;get;}


    }
}