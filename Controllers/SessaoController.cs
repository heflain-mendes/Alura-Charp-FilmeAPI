﻿using AutoMapper;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO DTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(DTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { FilmeId = sessao.FilmeId, CinemaId = sessao.CinemaId }, sessao);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDTO> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDTO>>(_context.Sessoes.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        public IActionResult RecuperaSessoesPorId([FromHeader]int filmeId, [FromHeader]int cinemaId)
        {
            Sessao? sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.FilmeId == filmeId && sessao.CinemaId == cinemaId);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDTO = _mapper.Map<ReadSessaoDTO>(sessao);

                return Ok(sessaoDTO);
            }
            return NotFound();
        }
    }
}
