using ApiLivros.Infra.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLivros.Infra.Repositories
{
    public interface ILivroRepository
    {
        Task AdicionarLivro(Livro livro);
        Task<List<Livro>> ListarLivros();
        Task<Livro> PesquisaPorNome(string nome);
        Task<List<Livro>> PesquisaPorAutor(string autor);
        Task DeletarLivro(int id);

    }
}
