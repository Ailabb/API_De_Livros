using ApiLivros.Application.Models;
using ApiLivros.Infra.Entities;
using ApiLivros.Infra.Repositories;
using MinhaApiDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLivros.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        public Task AdicionarLivro(LivroRequest request)
        {
            var entity = ConvertModelToEntity(request);
            return _livroRepository.AdicionarLivro(entity);
        }

        
        public async Task<List<LivroResponse>> ListarLivros()
        {
            var entity =  await _livroRepository.ListarLivros();
            return ConvertEntityToModel(entity);
            
        }

        public async Task<List<LivroResponse>> PesquisaPorAutor(string autor)
        {
            var entity = await _livroRepository.PesquisaPorAutor(autor);
            return ConvertEntityToModel(entity);
        }

        
        public async Task<LivroResponse> PesquisaPorNome(string nome)
        {
            var entity =  await _livroRepository.PesquisaPorNome(nome);
            return ConvertEntitytoModelObject(entity);
            
        }

        public async Task DeletarLivro(int id)
        {
            await _livroRepository.DeletarLivro(id);
        }

        private Infra.Entities.Livro ConvertModelToEntity(LivroRequest livroModel)
        {
            return new Infra.Entities.Livro
            {
                AnoDeLançamento = livroModel.AnoDeLançamento,
                Autor = livroModel.Autor,
                NomeDoLivro = livroModel.NomeDoLivro,
                GeneroDoLivro = livroModel.GeneroDoLivro

            };

        }

        private LivroResponse ConvertEntitytoModelObject(Livro livroEntity)
        {
            return new LivroResponse
            {
                AnoDeLançamento = livroEntity.AnoDeLançamento,
                Autor = livroEntity.Autor,
                NomeDoLivro = livroEntity.NomeDoLivro,
                GeneroDoLivro = livroEntity.GeneroDoLivro              
               
            };

        }

        private List<LivroResponse> ConvertEntityToModel(List<Infra.Entities.Livro> livroEntity)
        {
            var modelList = new List<LivroResponse>();
            foreach (var livro in livroEntity)
            {
                var model = new LivroResponse();
                model.NomeDoLivro = livro.NomeDoLivro;
                model.AnoDeLançamento = livro.AnoDeLançamento;
                model.GeneroDoLivro = livro.GeneroDoLivro;
                model.Autor = livro.Autor; ;
                modelList.Add(model);
            }
            return modelList;
        }

    }
    
}
