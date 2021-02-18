using AvaliacaoApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoApi.DataBase
{
    public class AvaliacaoContext : DbContext
    {
        public AvaliacaoContext(DbContextOptions<AvaliacaoContext> options) : base(options)
        {

        }
        public DbSet<Equipamento> Produto { get; set; }
    }
}
