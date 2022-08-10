using System;
using Microsoft.EntityFrameworkCore;
using DogAPI.Models;

namespace DogAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

     public DbSet<Dogs> Dogs_API { get; set; }
     
    }
}

