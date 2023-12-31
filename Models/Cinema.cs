﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage ="o campo de nome é obrigatório")]
    public string? Nome { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; }
    public virtual ICollection<Sessao>? Sessoes { get; set; }
}
