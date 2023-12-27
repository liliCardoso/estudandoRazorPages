using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using teste.Models;

namespace teste.Data
{
    public class MomentoDbContext : DbContext
    {
        public MomentoDbContext (DbContextOptions<MomentoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Momento> Momento { get; set; }
        public DbSet<Foto> Fotos { get; set; }
    }
}
