using ApiLivros.Infra.Database;
using ApiLivros.Infra.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLivros.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationContext _context;

        public LivroRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task AdicionarLivro(Livro livro)
        {
            _context.Livro.Add(livro);
            _context.SaveChanges();
            return Task.FromResult(livro);
        }

        public async Task<List<Livro>> ListarLivros()
        {
            return await _context.Livro.ToListAsync();
        }

        public async Task<Livro> PesquisaPorNome(string nome)
        {
            return await _context.Livro.FirstOrDefaultAsync(livro => livro.NomeDoLivro == nome);
        }

        public async Task<List<Livro>> PesquisaPorAutor(string autor)
        {
            return  await _context.Livro.Where(nomeautor => nomeautor.Autor == autor).ToListAsync();
        }
        
        public async Task DeletarLivro(int id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<Livro> ModiicarLivro(Livro livro )
        {
            _context.Update(livro);
            await _context.SaveChangesAsync();
            return livro;
            //return await Task.FromResult(livro);
        }

    }
}
