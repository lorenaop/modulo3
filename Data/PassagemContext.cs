using Microsoft.EntityFrameworkCore;
using Home.Models;

namespace Home.Data
{
    public class PassagemContext : DbContext

    {
    public PassagemContext(DbContextOptions<PassagemContext> opt ) : base(opt)
    {
    }
        public DbSet<Passagem> Passagens {get; set;}

        public DbSet<Cadastro> Cadastros {get; set;}

        public DbSet<Destino> Destinos {get; set;}

    
        }
    }

