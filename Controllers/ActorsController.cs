using AutoMapper;
using IntroductionToEFCoreENG.DTOs;
using IntroductionToEFCoreENG.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCoreENG.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actors.ToListAsync();
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        {
            // version 1
            return await context.Actors.Where(x => x.Name == name).ToListAsync();
        }

        [HttpGet("name/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> Getv2(string name)
        {
            // version 2
            return await context.Actors
                .Where(x => x.Name.Contains(name))
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.DateOfBirth)
                .ToListAsync();
        }

        [HttpGet("idandname")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdAndName()
        {
            var actors = await context.Actors
                .Select(x => new ActorDTO { Id = x.Id, Name = x.Name }).ToListAsync();

            return actors;
        }

        [HttpGet("dateOfBirth/range")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetDOB(DateTime start, DateTime end)
        {
            return await context.Actors.Where(x => x.DateOfBirth >= start && x.DateOfBirth <= end)
                .ToListAsync();
        }

        // api for finding a particular actor is present or not 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var trial = await context.Actors.FirstOrDefaultAsync(x => x.Id == id);

            if (trial is null)
            {
                return NotFound();
            }

            return trial;
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