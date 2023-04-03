using SpaceFlightWeb.Server.Services;
using SpaceFlightWeb.Shared;
using Microsoft.AspNetCore.Mvc;

namespace SpaceFlightWeb.Server.Controllers
{
    [ApiController]
    [Route("/SpaceFlightAPI/[controller]")]
    public class ArticlesController : ControllerBase
    {
        JsonFileArticleService articleService = new JsonFileArticleService();

        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(ILogger<ArticlesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetArticles")]
        public IEnumerable<Article> Get()
        {
            getRandAPOD.newRandArticle();
            JsonFileFetchService.GetArticle();
            return articleService.getArticles();
        }
    }
}