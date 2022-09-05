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
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Id = 1,
                NomeUsuario = "Maria Souza",
                DataNascimento = DateTime.Today,
                GeneroFavorito = Generos.Thriller,
            },
            new Usuario
            {
                 Id = 2,
                NomeUsuario = "Fernanda Souza",
                DataNascimento = DateTime.Today,
                GeneroFavorito = Generos.Romance,
            },
        };

        //Endpoints GET
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return Ok(usuarios);
        }

        [HttpGet("Busca_por_Id")]
        public async Task<ActionResult<Usuario>> GetId(int id)
        {
            var usuario = usuarios.FirstOrDefault(x => x.Id == id);
            //var usuario = usuarios.Where(x => x.Id == id).FirstOrDefault();
            return Ok(usuario);
        }

        [HttpGet("Busca_por_nome")]
        public async Task<ActionResult<Usuario>> GetNome(string nomeDoUsuario)
        {
            var usuario = usuarios.FirstOrDefault(nome => nome.NomeUsuario == nomeDoUsuario);
            return Ok(usuario);
        }

        //Endpoint Post
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario request)
        {

            usuarios.Add(request);
            return Ok();
        }

        //Endpoint Put
        [HttpPut]
        public async Task<ActionResult<Usuario>> PutUsuario(Usuario usuarioModificado)
        {
            var busca = usuarios.Find(usuario => usuario.Id == usuarioModificado.Id);

            if (busca != null)
            {
                busca.NomeUsuario = usuarioModificado.NomeUsuario;
                busca.DataNascimento = usuarioModificado.DataNascimento;
                busca.GeneroFavorito = usuarioModificado.GeneroFavorito;

            }
            return Ok();

        }

        //Endpoint Delete
        [HttpDelete]
        public async Task<ActionResult<Usuario>> DeleteUsuario(Usuario usuarioDeletado)
        {
            var busca = usuarios.Find(usuario => usuario.Id == usuarioDeletado.Id);

            if (busca != null)
            {
                usuarios.Remove(busca);
            }

            return Ok();
        }
    }
}
