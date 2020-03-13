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
        public async Task<ActionResult<IEnumerable<BasicFeed>>> GetFeeds(Blog.Enums.Language lang = Enums.Language.RU, Blog.Enums.FeedType type= Enums.FeedType.None)
        {
            return await _context.Feeds.Where(f => f.Published && f.Language == lang && (f.Type == type|| type== Enums.FeedType.None)).ToListAsync<BasicFeed>();
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<Feed>> GetFeed(string url, Blog.Enums.Language lang = Enums.Language.RU, Blog.Enums.FeedType type = Enums.FeedType.None)
        {
            var feed = await _context.Feeds.Where(f=>f.Published&& f.Url == url && f.Language == lang && (f.Type == type || type == Enums.FeedType.None)).FirstAsync();

            if (feed == null)
            {
                return NotFound();
            }

            return feed;
        }

    }
}
