using MinhaApiDeLivros.Enums;
using System;
using System.Collections.Generic;

namespace MinhaApiDeLivros.Models
{
    public class Usuario
    {
        
        public int Id { get; set; }

        public string NomeUsuario { get; set; }

        public DateTime DataNascimento { get; set; }

        public Generos GeneroFavorito { get; set; }

        public List<Livro> Biblioteca { get; set; }
    }
}
