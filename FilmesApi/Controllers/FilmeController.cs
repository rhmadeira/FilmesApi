using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 1;

    [HttpPost]
    public void AddFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Duracao);
        Console.WriteLine(filme.Titulo);
        
    }

    [HttpGet]
    public IEnumerable<Filme> GetAllFilmes()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? GetFilmeById(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
        
    }
}
