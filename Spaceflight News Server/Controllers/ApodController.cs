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
    public class ApodController : ControllerBase
    {
        private readonly Spaceflight_News_MySQLContext _context;

        public ApodController(Spaceflight_News_MySQLContext context)
        {
            _context = context;
        }
        [Route("/Apodapi")]
        // GET: contentapi/apods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APOD>>> GetAPOD()
        {
            //Return only the latest 10 articles from the database
            var newestAPOD = (from a in _context.APOD orderby a.id descending select a).Take(1);

            return await newestAPOD.ToArrayAsync();
        }

        // GET: contentapi/apods/5
        [HttpGet("/Apodapi/{id}")]
        public async Task<ActionResult<APOD>> GetAPOD(int id)
        {
            var aPOD = await _context.APOD.FindAsync(id);

            if (aPOD == null)
            {
                return NotFound();
            }

            return aPOD;
        }
    }
}
