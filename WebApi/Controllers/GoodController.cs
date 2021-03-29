using BLL.DTO;
using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GoodController : ApiController
    {
        IService<GoodDTO> goodService;
        IService<ManufacturerDTO> manufacturerService;
        IService<CategoryDTO> categoryService;
        DbContext context;

        public GoodController()
        {
            context = new ShopContext();
            goodService = new GoodService(new GoodRepository(context));
            manufacturerService = new ManufacturerService(new ManufacturerRepository(context));
            categoryService = new CategoryService(new CategoryRepository(context));
        }

        [HttpGet]
        public GoodDTO Get(int id)
        {
            return goodService.Get(id);
        }
        [HttpGet]
        public IEnumerable<GoodDTO> Get()
        {
            return goodService.GetAll();
        }
        [HttpPost]
        public void Post([FromBody]GoodDTO goodDTO)
        {
            GoodDTO newGood = new GoodDTO
            {

                GoodCount = goodDTO.GoodCount,
                GoodName = goodDTO.GoodName,
                Price = goodDTO.Price,
                ManufacturerName = goodDTO.ManufacturerName,
                ManufacturerId = goodDTO.ManufacturerId,
                CategoryName = goodDTO.CategoryName,
                CategoryId = goodDTO.CategoryId
            };
            goodService.CreateOrUpdate(newGood);
        }

        [HttpPut]
        public void Put(int id, [FromBody]GoodDTO goodDTO)
        {
            GoodDTO editgood = goodService.Get(id);
            editgood.GoodCount = goodDTO.GoodCount;
            editgood.GoodName = goodDTO.GoodName;
            editgood.Price = goodDTO.Price;
            editgood.ManufacturerId = goodDTO.ManufacturerId;
            editgood.ManufacturerName = goodDTO.ManufacturerId.HasValue ? manufacturerService.Get(goodDTO.ManufacturerId.Value).ManufacturerName:"";
            editgood.CategoryId = goodDTO.CategoryId;
            editgood.CategoryName = goodDTO.CategoryId.HasValue?categoryService.Get(goodDTO.CategoryId.Value).CategoryName:"";
            goodService.CreateOrUpdate(editgood);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var deleteGood = goodService.Get(id);
            goodService.Delete(deleteGood);
        }
    }
}
