using ApiLivros.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiLivros.Application.Services
{
    public interface ILivroService
    {
        Task AdicionarLivro(LivroRequest request);
        Task<List<LivroResponse>> ListarLivros();
        Task<LivroResponse> PesquisaPorNome(string nome);
        Task<List<LivroResponse>> PesquisaPorAutor(string autor);
        Task DeletarLivro(int id);
    }
}
