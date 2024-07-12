using AutoMapper;
using IntroductionToEFCoreENG.Controllers.DTOs;
using IntroductionToEFCoreENG.Entites;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCoreENG.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        // we will require a instance of applicationDBContext Class because it is through this class we will be able to do CRUD 
        // we will use dependency injection to access instance of application DB context 
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<ActionResult> Post(Genre genreCreationDTO)
        {
            var genre = mapper.Map<Genre>(genreCreationDTO);
            context.Add(genre);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("several")]

        public async Task<ActionResult> Post(GenreCreationDTO[] genreCreationDTO)
        {
            var genres = mapper.Map<Genre[]>(genreCreationDTO);
            context.AddRange(genres);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
