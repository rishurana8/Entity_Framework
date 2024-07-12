using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEFCoreENG.Controllers
{
    public class ActorsController: ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public ActorsController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {

        }
    }
}
