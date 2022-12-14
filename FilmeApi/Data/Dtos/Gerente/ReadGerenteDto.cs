using FilmeApi.Model;

namespace FilmeApi.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Cinema> Cinemas { get; set; }
    }
}
