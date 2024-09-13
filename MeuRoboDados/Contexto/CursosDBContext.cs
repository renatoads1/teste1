using MeuRoboDados.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuRoboDados.Contexto
{
    public class CursosDBContext: DbContext
    {
        public CursosDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<CursosModel> curso { get; set; }
    }
}
