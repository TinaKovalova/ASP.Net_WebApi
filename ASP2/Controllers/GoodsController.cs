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
    public class GoodsController : Controller
    {
        const int GOODS_PER_PAGE = 7;
        IService<GoodDTO> goodService;
        IService<CategoryDTO> categoryService;
        IService<ManufacturerDTO> manufacturerService;
        
        public GoodsController(IService<GoodDTO> goodService, IService<CategoryDTO> categoryService,IService<ManufacturerDTO> manufacturerService)
        {
            this.goodService = goodService;
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            ViewBag.Manufacturers = manufacturerService.GetAll();
            ViewBag.Categoryes = categoryService.GetAll();
        }
        public ActionResult Index()
        {
            ViewBag.PagesCount = (int)Math.Ceiling(goodService.GetAll().Count() / (decimal)GOODS_PER_PAGE);
            return View();
        }
        public ActionResult GoodsTable(int id = 1)
        {
            var goods = goodService.GetAll()
              .Skip((id - 1) * GOODS_PER_PAGE)
              .Take(GOODS_PER_PAGE)
              .ToList();
            return PartialView(goods);
        }
        [HttpGet]
        public ActionResult CreateGoods(int id=0)
        {
           GoodDTO good = id != 0? goodService.Get(id):new GoodDTO();
           return View(good);
        }
        [HttpPost]
        public ActionResult CreateGoods(GoodDTO goodViewModel)
        {
            if (ModelState.IsValid)
            {
                goodService.CreateOrUpdate(goodViewModel);
                return RedirectToAction("Index");
            }
            return View(goodViewModel);
        }
        [HttpGet]
        public ActionResult DeleteGoods(int id)
        {
            var good = goodService.Get(id);
            goodService.Delete(good);
            return RedirectToAction("Index");
        }


    }
}