using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWWTBM.Models
{
    public class ApplicationDbcontext: DbContext
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Answers> Answers { get; set; }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options) 
        {
            Database.EnsureCreated();

        }

        public ApplicationDbcontext() : base() { }

    }
}
