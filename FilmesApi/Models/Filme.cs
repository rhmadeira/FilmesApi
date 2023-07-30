using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{ 
    [Key]
    [Required]

    public int Id { get; set; }


    [Required(ErrorMessage = "O titulo do filme é obrigatório")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O genero do filme é Obrigatório")]
    [MaxLength(50, ErrorMessage = "O genero nã pode exceder 50 caracteres")]
    public string Genero { get; set; }

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ter no mínimo 70 e no máximo 600 minutos")]
    public int Duracao { get; set; }
}
