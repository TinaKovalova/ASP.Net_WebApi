using ASP2.Models;
using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP2.Controllers
{
    public class CategoryController : Controller
    {
        const int CATEGORY_PER_PAGE = 7;

        IService<CategoryDTO> categoryService;
        public CategoryController(IService<CategoryDTO> categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            ViewBag.PagesCount =(int)Math.Ceiling(categoryService.GetAll().Count() /(decimal) CATEGORY_PER_PAGE);
            return View();
        }
        public ActionResult CategoryTable(int id = 1)
        {
            var categories = categoryService.GetAll().Skip((id - 1) * CATEGORY_PER_PAGE).Take(CATEGORY_PER_PAGE).ToList();

            return PartialView(categories);
        }
        [HttpGet]
        public ActionResult CreateCategory(int  id=0)
        {
            CategoryDTO category = id != 0 ? categoryService.Get(id) : new CategoryDTO();
         
            return View(category);
        }
        [HttpPost]
        public ActionResult CreateCategory(CategoryDTO categoryViewModel)
        {
            if(ModelState.IsValid)
            {
                categoryService.CreateOrUpdate(categoryViewModel);
                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }
        public ActionResult CategoryManufacturer(int id)
        {
            categoryService.Delete(categoryService.Get(id));
            return RedirectToAction("Index");
        }
    }
}