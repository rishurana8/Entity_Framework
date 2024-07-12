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
        public GenresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]

        public async Task<ActionResult> Post(Genre genre)
        {
            context.Add(genre);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
