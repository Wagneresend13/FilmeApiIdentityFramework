using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmeApi.Model
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Lougradouro { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
