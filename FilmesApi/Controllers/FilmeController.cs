﻿using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

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
    public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
    {

        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
      return  CreatedAtAction(nameof(GetFilmeById), new { id = filme.Id }, filme);
        
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetAllFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take)); 
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmeById(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null)
        {
            return NotFound();
        }
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);    
        return Ok(filmeDto);       
    }
    [HttpPut("{id}")]
    public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) { return NotFound(); }
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();

        return NoContent();

    }

    [HttpPatch("{id}")]

    public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) { return NotFound(); }

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
        
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) { return NotFound(); }

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
