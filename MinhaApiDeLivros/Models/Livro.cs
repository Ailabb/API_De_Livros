using MinhaApiDeLivros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApiDeLivros.Models
{
    public class Livro
    {
        public int Id { get; set; }

        public string NomeDoLivro { get; set; }

        public string Autor { get; set; }

        public int AnoDeLançamento { get; set; }

        public Generos GeneroDoLivro { get; set; }

        public Status StatusDeLeitura { get; set; }

        public Classificacao ClassificacaoDeLeitura { get; set; }

    }
}
