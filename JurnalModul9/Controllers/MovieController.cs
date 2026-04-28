using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private static List<Movie> _movies = new List<Movie>
    {
        new Movie {
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Stars = new List<string>{"Tim Robbins", "Morgan Freeman"},
            Description = "Two imprisoned men bond over a number of years..."
        },
        new Movie {
            Title = "The Godfather",
            Director = "Francis Ford Coppola",
            Stars = new List<string>{"Marlon Brando", "Al Pacino"},
            Description = "The aging patriarch of an organized crime dynasty..."
        },
        new Movie {
            Title = "The Dark Knight",
            Director = "Christopher Nolan",
            Stars = new List<string>{"Christian Bale", "Heath Ledger"},
            Description = "When the menace known as the Joker wreaks havoc..."
        }
    };

    [HttpGet]
    public IEnumerable<Movie> Get()
    {
        return _movies;
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        if (id < 0 || id >= _movies.Count) return NotFound();
        return _movies[id];
    }

    [HttpPost]
    public void Post([FromBody] Movie movie)
    {
        _movies.Add(movie);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        if (id >= 0 && id < _movies.Count)
        {
            _movies.RemoveAt(id);
        }
    }
}