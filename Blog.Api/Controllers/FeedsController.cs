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
        public IEnumerable<BasicFeedApi> GetFeeds(Blog.Enums.Language lang = Enums.Language.RU)
        {
            var feeds = _context.Feeds.Where(f => f.Published && f.Language == lang)
                .ToList().Select(f => {
                    SortedList<string, string> categories = new SortedList<string, string>();
                    _context.FeedCategories.Where(ft => ft.Feed.ID == f.ID).Select(c=>c.Category).ToList().ForEach(fc => {
                        categories.Add(fc.Url, fc.Name);
                    });
                    SortedList<string, string> tags = new SortedList<string, string>();
                    _context.FeedTags.Where(ft => ft.Feed.ID == f.ID).Select(t=>t.Tag).ToList().ForEach(ft => {
                        tags.Add(ft.Url, ft.Name);
                    });
                    var result = new BasicFeedApi()
                    {
                        Feed = f,
                        Tags = tags,
                        Categories= categories
                    };
            return result; 
                });
            return feeds.ToList();
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
