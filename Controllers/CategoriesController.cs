using AutoMapper;
using HouseDesignsEcommerce.Data;
using HouseDesignsEcommerce.Data.Entities;
using HouseDesignsEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HouseDesignsEcommerce.Controllers
{
    [Route("api/[Controller]")]
    //[ApiController]
    public class CategoriesController : Controller
    {
        private readonly IApplicationRepository _repository;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(IApplicationRepository repository, ILogger<CategoriesController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult Get()
        {
            try
            {
                var result = _repository.GetAllCategories();
                return Ok(_mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all categories: {ex}");
                return BadRequest("Failed to get all categories");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _repository.GetCategoryById(id);

                if (category != null)
                    return Ok(_mapper.Map<Category, CategoryViewModel>(category));
                else 
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get category by id: {ex}");
                return BadRequest("Failed to get category by id");
            }
        }

        [HttpGet("{name:string}")]
        public IActionResult Get(string name)
        {
            try
            {
                var category = _repository.GetCategoryByName(name);

                if (category != null)
                    return Ok(_mapper.Map<Category, CategoryViewModel>(category));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get category by name: {ex}");
                return BadRequest("Failed to get category by name");
            }
        }



        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCategory = _mapper.Map<CategoryViewModel, Category>(model);

                    _repository.AddEntity(newCategory);

                    if (_repository.SaveAll())
                    {

                        return Created($"/api/categories/{newCategory.CategoryId}", _mapper.Map<Category, CategoryViewModel>(newCategory));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new category: {ex}");
            }
            return BadRequest("Failed to save new category");
        }

    }
}
