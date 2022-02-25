using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RiyasMold.Models;

namespace RiyasMold.Data
{
    public class RiyasMoldContext : DbContext
    {
        public RiyasMoldContext (DbContextOptions<RiyasMoldContext> options)
            : base(options)
        {
        }

        public DbSet<RiyasMold.Models.Ice> Ice { get; set; }
    }
}
