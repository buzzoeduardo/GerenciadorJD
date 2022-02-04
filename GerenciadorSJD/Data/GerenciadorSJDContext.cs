using GerenciadorSJD.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorSJD.Data
{
    public class GerenciadorSJDContext : DbContext
    {
        public GerenciadorSJDContext(DbContextOptions<GerenciadorSJDContext> options) : base(options)
        {
        }

        public DbSet<Policia> Policia { get; set; }
        public DbSet<Processo> Processo { get; set; }
        public DbSet<Numerador> Numerador { get; set; }       

        public GerenciadorSJDContext() { }
    }
}


      