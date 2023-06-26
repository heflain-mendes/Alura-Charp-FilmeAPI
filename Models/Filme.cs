using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme{
    [Key]
    [Required]
    public int FilmeId { get; set; }
    
    [Required(ErrorMessage ="O Titulo é obrigatório")]
    public string? Titulo {get; set; }

    [Required(ErrorMessage ="O Genero é obrigatório")]
    [MaxLength(50, ErrorMessage ="O tamano do Genero deve ser menor que 50 caracteres")]
    public string? Genero { get; set; }
    
    [Required(ErrorMessage ="A Duração é obrigatória")]
    [Range(70, 600, ErrorMessage ="A Duração deve ter entre 70 e 600 minutos")]
    public int Duracao { get; set; }
}