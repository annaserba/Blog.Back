using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Cors;

namespace Blog.Api.Controllers
{
    [Route("[controller]")]
    [EnableCors("Feeds")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicFeed>>> GetFeeds(Blog.Enums.Language lang = Enums.Language.RU)
        {
            return await _context.Feeds.Where(f => f.Published && f.Language == lang ).ToListAsync<BasicFeed>();
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<Feed>> GetFeed(string url, Blog.Enums.Language lang = Enums.Language.RU)
        {
            var feed = await _context.Feeds.Where(f=>f.Url == url && f.Language == lang ).FirstAsync();

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }

    }
}
