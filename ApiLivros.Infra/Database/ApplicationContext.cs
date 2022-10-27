using ApiLivros.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Infra.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Livro> Livro => Set<Livro>();      

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
