using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class FeedView
    {
        public Feed Feed { get; set; }
        public List<Tag> AllTags { get; set; }
        public List<Category> AllCategories { get; set; }
        public List<SelectListItem> TagsView
        {
            get
            {
                List<Tag> selected = Feed?.FeedTags?.Select(f=>f.Tag)?.ToList() ?? new List<Tag>();
                List<Tag> noSelected = AllTags?.Where(t => !selected.Contains(t))?.ToList() ?? new List<Tag>();
                var result = selected.Select(f => new SelectListItem() { 
                    Text = f.Name, 
                    Value = f.ID.ToString(), 
                    Selected = true 
                })?.ToList();
                result.AddRange(noSelected.Select(f => new SelectListItem() { 
                    Text = f.Name, 
                    Value = f.ID.ToString(), 
                    Selected = false 
                })?.ToList());
                return result;
            }
        }
        public List<SelectListItem> CategoriesView
        {
            get
            {
                List<Category> selected = Feed?.FeedCategories?.Select(f => f.Category)?.ToList() ?? new List<Category>();
                List<Category> noSelected = AllCategories?.Where(c => !selected.Contains(c))?.ToList() ?? new List<Category>();
                var result = selected.Select(f => new SelectListItem()
                {
                    Text = f.Name,
                    Value = f.ID.ToString(),
                    Selected = true
                })?.ToList();
                result.AddRange(noSelected.Select(f => new SelectListItem()
                {
                    Text = f.Name,
                    Value = f.ID.ToString(),
                    Selected = false
                })?.ToList());
                return result;
            }
        }
    }
}
