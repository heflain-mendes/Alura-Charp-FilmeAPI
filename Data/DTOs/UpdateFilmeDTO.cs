using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.DTOs
{
    public class UpdateFilmeDTO
    {
        [Required(ErrorMessage ="O Titulo é obrigatório")]
        public string? Titulo {get; set; }

        [Required(ErrorMessage ="O Genero é obrigatório")]
        [StringLength(50, ErrorMessage ="O tamano do Genero deve ser menor que 50 caracteres")]
        public string? Genero { get; set; }
        
        [Required(ErrorMessage ="A Duração é obrigatória")]
        [Range(70, 600, ErrorMessage ="A Duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}