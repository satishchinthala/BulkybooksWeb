using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkybooksWeb.Models;
using Microsoft.EntityFrameworkCore;



namespace BulkybooksWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories {get; set;}
    }
}