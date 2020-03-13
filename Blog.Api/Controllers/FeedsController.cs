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
    [EnableCors]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicFeed>>> GetFeeds(Blog.Enums.Language lang = Enums.Language.EN)
        {
            return await _context.Feeds.Where(f => f.Language == lang).ToListAsync();
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<Feed>> GetFeed(string url, Blog.Enums.Language lang = Enums.Language.EN)
        {
            var feed = await _context.Feeds.FirstAsync(f => f.Url == url && f.Language == lang);

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }



        private bool FeedExists(string url, Blog.Enums.Language lang = Enums.Language.EN)
        {
            return _context.Feeds.Any(e => e.Url == url&&e.Language== lang);
        }
    }
}
