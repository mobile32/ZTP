using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Query;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly ICategoriesRepository _categories;

        public CategoriesViewComponent(ICategoriesRepository categories)
        {
            _categories = categories;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categories.GetCategoriesWithPostCounts();
            return View(categories);
        }
    }
}
