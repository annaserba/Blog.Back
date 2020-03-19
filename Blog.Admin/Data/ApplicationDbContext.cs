using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog.Models.Feed> Feeds { get; set; }
        public DbSet<Blog.Models.Tag> Tags { get; set; }
        public DbSet<Blog.Models.Category> Categories { get; set; }
        public DbSet<Blog.Models.FeedTag> FeedTags { get; set; }
        public DbSet<Blog.Models.FeedCategory> FeedCategories { get; set; }
    }
}
