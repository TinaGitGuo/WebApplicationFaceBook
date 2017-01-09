using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationwithidenty.Models;

namespace WebApplicationwithidenty.Data
{
    public class ApplicationDbContext  
    {
        public ApplicationDbContext(DbContextOptions  options)
             
        {
        }

       

        public DbSet<Students> Students { get; set; }
    }
}
