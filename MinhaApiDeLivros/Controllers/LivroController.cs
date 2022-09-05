using Microsoft.AspNetCore.Mvc;
using MinhaApiDeLivros.Enums;
using MinhaApiDeLivros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApiDeLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private static List<Livro> livros = new List<Livro>
        {
           new Livro
           {
               Id =1,
               NomeDoLivro = "De Lukov, com amor",
               Autor = "Mariana Zapata",
               AnoDeLançamento = 2018,
               GeneroDoLivro = Generos.Romance,
               StatusDeLeitura = Status.Lido,
               ClassificacaoDeLeitura = Classificacao.Otimo,
           },

            new Livro
           {
               Id =2,
               NomeDoLivro = "A pequena livraria dos coracoes solitarios",
               Autor = "Annie Darling",
               AnoDeLançamento = 2017,
               GeneroDoLivro = Generos.Romance,
               StatusDeLeitura = Status.Lendo,
           },
             new Livro
           {
               Id =3,
               NomeDoLivro = "Um desejo para nos dois",
               Autor = "Tillie Cole",
               AnoDeLançamento = 2018,
               GeneroDoLivro = Generos.Romance,
               StatusDeLeitura = Status.NaoLido,
           }
        };

        //Endpoints GET
        [HttpGet]
        public async Task<ActionResult<List<Livro>>> Get()
        {
            return Ok(livros);
        }

        [HttpGet("Busca_por_Id")]
        public async Task<ActionResult<Livro>> GetId(int id)
        {
            var livro = livros.FirstOrDefault(x => x.Id == id);
            return Ok(livro);
        }

        [HttpGet("Busca_por_nome")]
        public async Task<ActionResult<Livro>> GetNome(string nomeDoLivro)
        {
            var livro = livros.FirstOrDefault(nome => nome.NomeDoLivro == nomeDoLivro);
            return Ok(livro);
        }
        [HttpGet("Busca_por_genero")]
        public async Task<ActionResult<Livro>> GetGenero(string genero)
        {
            var livrosPorGenero = new List<Livro>();
            //Generos resultadoGeneros;
            foreach (var livrosguardado in livros)
            {
                //if (Enum.TryParse(genero, out resultadoGeneros))
                if (Enum.TryParse(genero, out Generos ResultadoGeneros))
                {
                    livrosPorGenero.Add(livrosguardado);
                }
            }
            return Ok(livrosPorGenero);

        }

        //Endpoints Post
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro([FromBody] Livro request)
        {

            livros.Add(request);
            return Ok();
        }

        //Endpoint Put
        [HttpPut]
        public async Task<ActionResult<Livro>> PutLivro(Livro livroModificado)
        {
            var busca = livros.Find(livro => livro.Id == livroModificado.Id);

            if (busca != null)
            {
                busca.NomeDoLivro = livroModificado.NomeDoLivro;
                busca.Autor = livroModificado.Autor;
                busca.Autor = livroModificado.Autor;
                busca.AnoDeLançamento = livroModificado.AnoDeLançamento;
                busca.GeneroDoLivro = livroModificado.GeneroDoLivro;
                busca.StatusDeLeitura = livroModificado.StatusDeLeitura;
                busca.ClassificacaoDeLeitura = livroModificado.ClassificacaoDeLeitura;
            }
            return Ok(livros);
        }

        //Endpoint Delete 

        [HttpDelete]
        public async Task<ActionResult<Livro>> DeleteLivro(Livro livroDeletado)
        {
            var busca = livros.Find(livro => livro.Id == livroDeletado.Id);
            if (busca != null)
            {
                livros.Remove(busca);
            }

            return Ok();
        }
    }
}
