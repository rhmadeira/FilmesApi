using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatorio")]
        public string Nome { get; set; }    
        public int EnderecoId { get; set; }
    }
}
