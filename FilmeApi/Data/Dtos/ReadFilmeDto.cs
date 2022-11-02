using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "O Campo Título é Obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O Campo Diretor é Obrigatório")]
        public string Diretor { get; set; }

        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = " A duração deve ter no mínimo 1 no máximo 600 minutos")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
