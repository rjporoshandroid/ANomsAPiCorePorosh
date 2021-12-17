using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANOMS.Repository
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }
      //  public DbSet<AdUsers> AdUsers { set; get; }
    }
}
