using AutoMapper;
using IntroductionToEFCoreENG.Controllers.DTOs;
using IntroductionToEFCoreENG.Entites;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCoreENG.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public ActorsController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
