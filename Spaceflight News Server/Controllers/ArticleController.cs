using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spaceflight_News_Server.Data;
using Spaceflight_News_Server.Models;

namespace Spaceflight_News_Server.Controllers
{
    [Route("[controller]api/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly Spaceflight_News_MySQLContext _context;

        public ArticleController(Spaceflight_News_MySQLContext context)
        {
            _context = context;
        }
        [Route("/Articleapi")]
        // GET: contentapi/Article
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticle()
        {
            //Return only the latest 10 articles from the database
            var newestTenArticles = (from a in _context.Article orderby a.articleNum descending select a).Take(10);

            return await newestTenArticles.ToArrayAsync();
        }

        // GET: contentapi/Article/5
        [HttpGet("/Articleapi/{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Article.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // GET: contentapi/APODs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APOD>>> GetAPOD()
        {
            //Return only the latest 10 articles from the database
            var newestAPOD = (from a in _context.APOD orderby a.id descending select a).Take(1);

            return await newestAPOD.ToArrayAsync();
        }

        // GET: contentapi/APODs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APOD>> GetAPOD(int id)
        {
            var aPOD = await _context.APOD.FindAsync(id);

            if (aPOD == null)
            {
                return NotFound();
            }

            return aPOD;
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.articleNum == id);
        }
    }
}
