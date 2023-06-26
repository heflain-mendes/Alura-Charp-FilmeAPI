using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesAPI.Contollers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;
    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO? filmeDTO)
    {
        if (filmeDTO != null && _context != null && _context.Filmes != null)
        {
            Filme filme = this._mapper.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaFilmeById), new { id = filme.FilmeId }, filme);
        }

        return NotFound();//não sei se é isso que tenho que retorna
    }

    [HttpGet("{id}")]
    public IActionResult RetornaFilmeById(int id)
    {
        Filme? filme = filme = ObterFilme(id);
        return filme == null ? NotFound() : Ok(_mapper.Map<ReadFilmeDTO>(filme));
    }

    [HttpGet]
    public IQueryable<ReadFilmeDTO>? RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        IQueryable<Filme>? filmes = null;
        if (_context != null && _context.Filmes != null)
        {
            filmes =  _context.Filmes.Skip<Filme>(skip).Take<Filme>(take);
        }

        return _mapper.Map<IQueryable<ReadFilmeDTO>>(filmes);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO){
        Filme? filme = ObterFilme(id);

        if(filme == null) return NotFound();

        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
        
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, [FromBody] JsonPatchDocument<UpdateFilmeDTO> patch){
        Filme? filme = ObterFilme(id);
        if(filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);
        if(!TryValidateModel(filmeParaAtualizar)){
            return ValidationProblem(ModelState);
        }


        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id){
        Filme? filme = null;
        if(_context.Filmes != null){
            filme = _context.Filmes.FirstOrDefault(
            filme => filme.FilmeId == id);
        }
        if(filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }

    private Filme? ObterFilme(int id){
        Filme? filme = null;
        if(_context.Filmes != null){
            filme = _context.Filmes.FirstOrDefault(
            filme => filme.FilmeId == id);
        }

        return filme;
    }
}