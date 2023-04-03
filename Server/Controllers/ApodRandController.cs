using Microsoft.AspNetCore.Mvc;
using SpaceFlightWeb.Server.Services;
using SpaceFlightWeb.Shared;

namespace SpaceFlightWeb.Server.Controllers
{
    [ApiController]
    [Route("/SpaceFlightAPI/[controller]")]
    public class ApodRandController : Controller
    {
        JsonFileArticleService apodRandService = new JsonFileArticleService();

        private readonly ILogger<ApodController> _logger;

        public ApodRandController(ILogger<ApodController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetApodRand")]
        public IEnumerable<APOD> Get()
        {
            getRandAPOD.newRandArticle();
            return apodRandService.getRandomAPOD();
        }
    }
}
