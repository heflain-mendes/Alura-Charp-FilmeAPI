using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        public int? FilmeId { get; set; }// teve que pode ser nullable, para manter uma equivalencia com CinemaId
        public virtual Filme? Filme { get; set; }
        public int? CinemaId { get; set; }// teve que pode ser nullable, pois, já existia linha inseridas quando a relação foi estabelecida
        public virtual Cinema? Cinema { get; set; }
    }
}
