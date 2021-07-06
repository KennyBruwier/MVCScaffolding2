using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCScaffolding2.Models.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVCScaffolding2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Boek> Boeken { get; set; }
    }
}
