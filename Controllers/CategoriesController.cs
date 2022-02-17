using HouseDesignsEcommerce.Data;
using HouseDesignsEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace HouseDesignsEcommerce.Controllers
{
    [Route("api/[Controller]")]
    //[ApiController]
    public class CategoriesController : Controller
    {
        private readonly IApplicationRepository _repository;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IApplicationRepository repository, ILogger<CategoriesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        //[ProducesResponseType(200)]
        public IActionResult/*<IEnumerable<Category>>*/ Get()
        {
            try
            {
                return Ok(_repository.GetAllCategories());
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
                    return Ok(category);
                else 
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get category by id: {ex}");
                return BadRequest("Failed to get category by id");
            }
        }

       /* [HttpPost]
        public IActionResult Post([FromBody]CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newHouseDesign = new HouseDesign()
                    {
                        
                    };

                    _repository.AddEntity(newHouseDesign);

                    if (_repository.SaveAll())
                    {
                        var vm = new HouseDesignViewModel()
                        {
                            
                        };

                        return Created($"/api/categories/{vm.HouseDesignId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to post category: {ex}");
                return BadRequest("Failed to post category");
            }
        }*/

    }
}
