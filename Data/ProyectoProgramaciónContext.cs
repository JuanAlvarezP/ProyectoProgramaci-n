using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramación.Models;

namespace ProyectoProgramación.Data
{
    public class ProyectoProgramaciónContext : DbContext
    {
        public ProyectoProgramaciónContext (DbContextOptions<ProyectoProgramaciónContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoProgramación.Models.Citas> Citas { get; set; } = default!;
    }
}
