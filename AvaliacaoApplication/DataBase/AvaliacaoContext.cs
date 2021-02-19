using AvaliacaoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoApi.DataBase
{
    public class AvaliacaoContext : DbContext
    {
        public AvaliacaoContext(DbContextOptions<AvaliacaoContext> options) : base(options)
        {

        }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}
