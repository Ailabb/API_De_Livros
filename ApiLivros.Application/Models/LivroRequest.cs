using ApiLivros.Infra.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLivros.Application.Models
{
   public class LivroRequest
    {
        public string NomeDoLivro { get; set; }

        public string Autor { get; set; }

        public int AnoDeLançamento { get; set; }

        public GenerosEnum GeneroDoLivro { get; set; }
    }
}
