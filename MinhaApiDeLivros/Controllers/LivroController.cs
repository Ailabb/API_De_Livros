using ApiLivros.Application.Models;
using ApiLivros.Application.Services;
using ApiLivros.Infra.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaApiDeLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get()
        {
            var response = await _livroService.ListarLivros();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("Busca_por_Nome")]
        public async Task<ActionResult<Livro>> GetId(string nome)
        {
            var livro = await _livroService.PesquisaPorNome(nome);
            return Ok(livro);
        }

        [HttpGet("Busca_por_Autor")]
        public async Task<ActionResult<Livro>> GetByAutor(string autor)
        {
            var livro = await _livroService.PesquisaPorAutor(autor);
            return Ok(livro);
        }
        [HttpPost]
        public async Task<ActionResult<LivroRequest>> PostLivro(LivroRequest request)
        {
            await _livroService.AdicionarLivro(request);
            return NoContent();
        }

        //    [HttpGet("Busca_por_genero")]
        //    public async Task<ActionResult<Livro>> GetGenero(string genero)
        //    {
        //        var livrosPorGenero = new List<Livro>();
        //        //Generos resultadoGeneros;
        //        foreach (var livrosguardado in livros)
        //        {
        //            //if (Enum.TryParse(genero, out resultadoGeneros))
        //            if (Enum.TryParse(genero, out GenerosEnum ResultadoGeneros))
        //            {
        //                livrosPorGenero.Add(livrosguardado);
        //            }
        //        }
        //        return Ok(livrosPorGenero);

        //    }

        //   

        //    //Endpoint Put
        //    [HttpPut]
        //    public async Task<ActionResult<Livro>> PutLivro(Livro livroModificado)
        //    {
        //        var busca = livros.Find(livro => livro.Id == livroModificado.Id);

        //        if (busca != null)
        //        {
        //            busca.NomeDoLivro = livroModificado.NomeDoLivro;
        //            busca.Autor = livroModificado.Autor;
        //            busca.Autor = livroModificado.Autor;
        //            busca.AnoDeLançamento = livroModificado.AnoDeLançamento;
        //            busca.GeneroDoLivro = livroModificado.GeneroDoLivro;
        //            busca.StatusDeLeitura = livroModificado.StatusDeLeitura;
        //            busca.ClassificacaoDeLeitura = livroModificado.ClassificacaoDeLeitura;
        //        }
        //        return Ok(livros);
        //    }

        //    //Endpoint Delete 

        //    [HttpDelete]
        //    public async Task<ActionResult<Livro>> DeleteLivro(Livro livroDeletado)
        //    {
        //        var busca = livros.Find(livro => livro.Id == livroDeletado.Id);
        //        if (busca != null)
        //        {
        //            livros.Remove(busca);
        //        }

        //        return Ok();
        //    }
        //}
    }
}
