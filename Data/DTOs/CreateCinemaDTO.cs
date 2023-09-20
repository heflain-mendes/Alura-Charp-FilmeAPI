using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "o campo de nome é obrigatório")]
        public string? Nome { get; set; }

        [Required]
        public int EnderecoId { get; set; }
    }
}
