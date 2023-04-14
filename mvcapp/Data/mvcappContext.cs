using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcapp.Models;

namespace mvcapp.Data
{
    public class mvcappContext : DbContext
    {
        public mvcappContext (DbContextOptions<mvcappContext> options)
            : base(options)
        {
        }

        public DbSet<mvcapp.Models.TextAdded> TextAdded { get; set; } = default!;
    }
}
