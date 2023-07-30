using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class CreateFilmeDto
{

    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero do filme é Obrigatório")]
    [StringLength(50, ErrorMessage = "O genero nã pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ter no mínimo 70 e no máximo 600 minutos")]
    public int Duracao { get; set; }
}
