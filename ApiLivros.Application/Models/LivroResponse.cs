using ApiLivros.Infra.Enums;

namespace ApiLivros.Application.Models
{
    public class LivroResponse
    {
        public int Id { get; set; }

        public string NomeDoLivro { get; set; }

        public string Autor { get; set; }

        public int AnoDeLançamento { get; set; }

        public GenerosEnum GeneroDoLivro { get; set; }

    }
}
