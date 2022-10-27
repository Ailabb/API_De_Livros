using ApiLivros.Infra.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiLivros.Infra.Entities
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        public string NomeDoLivro { get; set; }

        public string Autor { get; set; }

        public int AnoDeLançamento { get; set; }

        public GenerosEnum GeneroDoLivro { get; set; }

       
    }   
        
}
