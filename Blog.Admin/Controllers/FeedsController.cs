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
            var feed = new Feed() { PostedOn = DateTime.UtcNow, Modified = DateTime.UtcNow };
            return View(feed);
        }

        // POST: Feeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Url,Language,Title,Excerpt,Content,Published,PostedOn,Modified,UrlTileImage,CommentStatus,Type,MetaDescription")] Feed feed)
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

            var feed = await _context.Feeds.FindAsync(id);
            if (feed == null)
            {
                return NotFound();
            }
            else
            {
                feed.Modified = DateTime.UtcNow;
            }
            return View(feed);
        }

        // POST: Feeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Url,Language,Title,Excerpt,Content,Published,PostedOn,Modified,UrlTileImage,CommentStatus,Type,MetaDescription")] Feed feed)
        {
            if (id != feed.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedExists(feed.ID))
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
            return View(feed);
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
