using AutoMapper;
using IntroductionToEFCoreENG.DTOs;
using IntroductionToEFCoreENG.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await context.Movies
                .Include(x => x.Comments)
                .Include(x => x.Genres)
                .Include(x => x.MoviesActors.OrderBy(ma => ma.Order))
                    .ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpGet("select/{id:int}")]
        public async Task<ActionResult> GetSelect(int id)
        {
            var movie = await context.Movies
                .Select(mov => new
                {
                    Id = mov.Id,
                    Title = mov.Title,
                    Genres = mov.Genres.Select(g => g.Name).ToList(),
                    Actors = mov.MoviesActors.OrderBy(ma => ma.Order).Select(ma => new
                    {
                        Id = ma.ActorId,
                        Name = ma.Actor.Name,
                        Character = ma.Character
                    }),
                    CommentsQuantity = mov.Comments.Count()
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);

            if (movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    context.Entry(genre).State = EntityState.Unchanged;
                }
            }

            if (movie.MoviesActors is not null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/modern")]
        public async Task<ActionResult> Delete(int id)
        {
            var removedRows = await context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();

            if (removedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }

}