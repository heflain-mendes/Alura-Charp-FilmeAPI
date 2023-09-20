using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class UpdateCinemaDTO
    {
        [Required(ErrorMessage = "o campo de nome é obrigatório")]
        public string? Nome { get; set; }
    }
}
