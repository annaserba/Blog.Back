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
using Blog.Api.Models;

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
        public async Task<ActionResult<FeedApi>> GetFeed(string url, Blog.Enums.Language lang = Enums.Language.RU)
        {
            FeedApi feedApi = new FeedApi()
            {
                Feed = await _context.Feeds
                .Where(f => f.Url == url && f.Language == lang).FirstAsync()
            };
            if (feedApi.Feed == null)
            {
                return NotFound();
            }
            SortedList<string, string> categories = new SortedList<string, string>();
            _context.FeedCategories.Where(ft => ft.Feed.ID == feedApi.Feed.ID).Select(c => c.Category).ToList().ForEach(fc => {
                categories.Add(fc.Url, fc.Name);
            });
            SortedList<string, string> tags = new SortedList<string, string>();
            _context.FeedTags.Where(ft => ft.Feed.ID == feedApi.Feed.ID).Select(t => t.Tag).ToList().ForEach(ft => {
                tags.Add(ft.Url, ft.Name);
            });
            SortedList<string, string> sources = new SortedList<string, string>();
            _context.FeedSources.Where(ft => ft.Feed.ID == feedApi.Feed.ID).Select(t => t.Source).ToList().ForEach(ft => {
                sources.Add(ft.URL, ft.Name);
            });
            feedApi.Categories = categories;
            feedApi.Tags = tags;
            feedApi.Sources = sources;
            return feedApi;
        }

    }
}
