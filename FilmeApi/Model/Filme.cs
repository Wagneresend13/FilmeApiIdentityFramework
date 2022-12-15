using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmeApi.Model
{
    public class Filme
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "O Campo Título é Obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo Diretor é Obrigatório")]
        public string Diretor { get; set; }

        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(1,600, ErrorMessage = " A duração deve ter no mínimo 1 no máximo 600 minutos")]
        public int Duracao { get; set; }

        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
