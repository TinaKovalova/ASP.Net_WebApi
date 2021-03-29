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
    public class ManufacturerController : Controller
    {
        const int MANUFACTURERS_PER_PAGE = 7;
        IService<ManufacturerDTO> manufacturerService;
        public ManufacturerController(IService<ManufacturerDTO> manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }
        public ActionResult Index()
        {
            ViewBag.PagesCount=(int)Math.Ceiling(manufacturerService.GetAll().Count()/(decimal)MANUFACTURERS_PER_PAGE);
            return View();
        }
        public ActionResult ManufacturersTable(int id=1)
        {
            var manufacturers = manufacturerService.GetAll().Skip((id - 1) * MANUFACTURERS_PER_PAGE).Take(MANUFACTURERS_PER_PAGE).ToList();
            return PartialView(manufacturers);
        }
        [HttpGet]
        public ActionResult CreateManufacturer(int id = 0)
        {
            ManufacturerDTO manufacturerViewModel = id != 0 ? manufacturerService.Get(id) : new ManufacturerDTO();
            return View(manufacturerViewModel);
        }
        [HttpPost]
        public ActionResult CreateManufacturer(ManufacturerDTO manufacturerViewModel)
        {
            if(ModelState.IsValid)
            {
                manufacturerService.CreateOrUpdate(manufacturerViewModel);
                return RedirectToAction("Index");
            }
            return View(manufacturerViewModel);
        }
        public ActionResult DeleteManufacturer(int id)
        {
            manufacturerService.Delete(manufacturerService.Get(id));
            return RedirectToAction("Index");
        }
    }
}