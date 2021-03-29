using AutoMapper;
using BLL.DTO;
using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : IService<CategoryDTO>
    {

        IRepository<Category> repository;
        IMapper mapper;
        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            });
            mapper = new Mapper(configuration);
        }
        public CategoryDTO Get(int id) => mapper.Map<CategoryDTO>(repository.Get(id));
        public IEnumerable<CategoryDTO> GetAll() => mapper.Map<IEnumerable<CategoryDTO>>(repository.GetAll());
        public void CreateOrUpdate(CategoryDTO entity)
        {
            repository.CreateOrUpdate(mapper.Map<Category>(entity));
            repository.Save();
        }

        public void Delete(CategoryDTO entity)
        {
            try
            {
                var category = repository.Get(entity.CategoryId);
                repository.Delete(category);
                repository.Save();

            }
            catch(Exception)
            {
                
            }
           
        }

    }
}
