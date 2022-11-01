using FilmeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi.Data
{
    public class FilmeContext : DbContext
    {

        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
                
        }

        public DbSet<Filme> Filmes { get; set; }

    }
}
