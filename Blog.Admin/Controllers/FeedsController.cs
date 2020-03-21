using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeedsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Feeds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feeds.ToListAsync());
        }

        // GET: Feeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        // GET: Feeds/Create
        public IActionResult Create()
        {
            var model =new FeedView(){
                Feed = new Feed() { 
                    PostedOn = DateTime.UtcNow, 
                    Modified = DateTime.UtcNow, 
                    FeedTags = new List<FeedTag>(),
                    FeedCategories=new List<FeedCategory>(),
                    FeedSources=new List<FeedSource>()
                },
                AllTags = _context.Tags.ToList(),
                AllCategories = _context.Categories.ToList(),
                AllSources=_context.Sources.ToList()
            };
            return View(model);
        }

        // POST: Feeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feed feed, List<string> Tags)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feed);
        }

        // GET: Feeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feeds
                .Include("FeedTags")
                .Include("FeedCategories")
                .FirstAsync(f=>f.ID==id);
            if (feed == null)
            {
                return NotFound();
            }
            else
            {
                feed.Modified = DateTime.UtcNow;
                var model = new FeedView()
                {
                    Feed = feed,
                    AllTags = _context.Tags.ToList(),
                    AllCategories = _context.Categories.ToList(),
                    AllSources=_context.Sources.ToList()
                };
              
                return View(model);
            }
        }

        // POST: Feeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FeedView feedView, List<int> Tags, List<int> Categories,List<int> Sources)
        {
            if (id != feedView.Feed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedView.Feed);
                    if (Tags != null)
                    {
                        _context.FeedTags.RemoveRange(_context.FeedTags.Where(c => c.FeedID == feedView.Feed.ID).ToList());
                        Tags?.ForEach(t =>
                        {
                             _context.FeedTags.Add(new FeedTag() { 
                                 TagID = t, 
                                 FeedID = feedView.Feed.ID,
                                 Feed= feedView.Feed,
                                 Tag =_context.Tags.Find(t)
                            });
                        });
                    }
                    if (Categories != null)
                    {
                        _context.FeedCategories.RemoveRange(_context.FeedCategories.Where(c => c.FeedID == feedView.Feed.ID).ToList());
                        Categories?.ForEach(c =>
                        {
                            _context.FeedCategories.Add(new FeedCategory() { 
                                CategoryID = c, 
                                FeedID = feedView.Feed.ID ,
                                Feed = feedView.Feed,
                                Category = _context.Categories.Find(c)
                            });
                        });
                    }
                    if (Sources != null)
                    {
                        _context.FeedSources.RemoveRange(_context.FeedSources.Where(c => c.FeedID == feedView.Feed.ID).ToList());
                        Sources?.ForEach(c =>
                        {
                            _context.FeedSources.Add(new FeedSource()
                            {
                                SourceID = c,
                                FeedID = feedView.Feed.ID,
                                Feed = feedView.Feed,
                                Source = _context.Sources.Find(c)
                            });
                        });
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedExists(feedView.Feed.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feedView.Feed);
        }

        // GET: Feeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feed = await _context.Feeds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (feed == null)
            {
                return NotFound();
            }

            return View(feed);
        }

        // POST: Feeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feed = await _context.Feeds.FindAsync(id);
            _context.Feeds.Remove(feed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedExists(int id)
        {
            return _context.Feeds.Any(e => e.ID == id);
        }
    }
}
