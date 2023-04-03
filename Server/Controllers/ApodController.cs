using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFlightWeb.Server.Services;
using SpaceFlightWeb.Shared;

namespace SpaceFlightWeb.Server.Controllers
{

    [ApiController]
    [Route("/SpaceFlightAPI/[controller]")]
    public class ApodController : Controller
    {
        JsonFileArticleService apodService = new JsonFileArticleService();

        private readonly ILogger<ApodController> _logger;

        public ApodController(ILogger<ApodController> logger)
        {
            _logger = logger;
        }


        // GET: ApodController
        [HttpGet(Name = "GetApod")]
        public IEnumerable<APOD> Get()
        {
            JsonFileFetchService.GetArticle();
            return apodService.getAPOD();
        }


        // GET: ApodController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApodController/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: ApodController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
