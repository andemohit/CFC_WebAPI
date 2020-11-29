using System.Collections.Generic;
using AutoMapper;
using Categories.Data;
using Categories.Dtos;
using Categories.Models;
using Microsoft.AspNetCore.Mvc;

namespace Categories.Controllers
{
    // api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepo _repository;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> GetAllCategories()
        {
            var categoryItems = _repository.GetAllCategories();
            return Ok(_mapper.Map<IEnumerable<CategoryReadDto>>(categoryItems));
        }

        // GET api/categories/{id}
        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var categoryItem = _repository.GetCategoryById(id);
            if (categoryItem != null)
            {
                return Ok(_mapper.Map<CategoryReadDto>(categoryItem));
            }
            return NotFound();
        }

        // POST api/categories
        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var categoryModel = _mapper.Map<Category>(categoryCreateDto);
            _repository.CreateCategory(categoryModel);
            _repository.SaveChanges();
            var categoryReadDto = _mapper.Map<CategoryReadDto>(categoryModel);
            return CreatedAtRoute(nameof(GetCategoryById), new { id = categoryReadDto.id }, categoryReadDto);
        }

        // PUT api/categories/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var categoryModelFromRepo = _repository.GetCategoryById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(categoryUpdateDto, categoryModelFromRepo);
            _repository.UpdateCategory(categoryModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // DELETE api/categories/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoryModelFromRepo = _repository.GetCategoryById(id);
            if (categoryModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(categoryModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}