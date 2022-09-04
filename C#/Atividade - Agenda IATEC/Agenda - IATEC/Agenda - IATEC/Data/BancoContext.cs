using Agenda___IATEC.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda___IATEC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<EventosModel> Eventos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
