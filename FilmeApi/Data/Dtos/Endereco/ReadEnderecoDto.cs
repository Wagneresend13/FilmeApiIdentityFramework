using System.ComponentModel.DataAnnotations;

namespace FilmeApi.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Lougradouro { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }
    }
}
