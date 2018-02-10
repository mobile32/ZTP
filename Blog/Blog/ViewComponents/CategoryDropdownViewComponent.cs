using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Query;
using Microsoft.AspNetCore.Mvc;

namespace Blog.ViewComponents
{
    public class CategoryDropdownViewComponent: ViewComponent
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryDropdownViewComponent(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }
        public IViewComponentResult Invoke(int? selectedValue, string name)
        {
            ViewBag.Name = name;
            ViewBag.Value = selectedValue;
            var categories = _categoriesRepository.GetCategories(); 
            return View(categories);
        }
    }
}
