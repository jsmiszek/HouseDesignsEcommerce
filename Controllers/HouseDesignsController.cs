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
    [ApiController]
    /*[Produces("application.json")]*/
    public class HouseDesignsController : Controller
    {
        private readonly IApplicationRepository _repository;
        private readonly ILogger<HouseDesignsController> _logger;

        public HouseDesignsController(IApplicationRepository repository, ILogger<HouseDesignsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<HouseDesign>> Get()
        {
            try
            {
                return Ok(_repository.GetAllHouseDesigns());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get house designs: {ex}");
                return BadRequest("Failed to get house designs");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var houseDesign = _repository.GetHouseDesignById(id);

                if (houseDesign != null)
                    return Ok(houseDesign);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get house design by id: {ex}");
                return BadRequest("Failed to get house design by id");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]HouseDesignViewModel model)
        {
            //add it to the db
            try
            {
                if (ModelState.IsValid)
                {
                    var newHouseDesign = new HouseDesign()
                    {
                        HouseDesignId = model.HouseDesignId,
                        ProjectName = model.ProjectName,
                        UseableArea = model.UseableArea,
                        MinPlotDimensionLength = model.MinPlotDimensionLength,
                        MinPlotDimensionWidth = model.MinPlotDimensionWidth,
                        RoofAngle = model.RoofAngle,
                        Price = model.Price,
                        NumberOfRooms = model.NumberOfRooms,
                        NumberOfBathrooms = model.NumberOfBathrooms,
                        NumberOfGaragePositions = model.NumberOfGaragePositions,
                        ImagePath = model.ImagePath
                    };

                    _repository.AddEntity(newHouseDesign);

                    if (_repository.SaveAll())
                    {
                        var vm = new HouseDesignViewModel()
                        {
                            HouseDesignId = newHouseDesign.HouseDesignId,
                            ProjectName = newHouseDesign.ProjectName,
                            UseableArea = newHouseDesign.UseableArea,
                            MinPlotDimensionLength = newHouseDesign.MinPlotDimensionLength,
                            MinPlotDimensionWidth = newHouseDesign.MinPlotDimensionWidth,
                            RoofAngle = newHouseDesign.RoofAngle,
                            Price = newHouseDesign.Price,
                            NumberOfRooms = newHouseDesign.NumberOfRooms,
                            NumberOfBathrooms = newHouseDesign.NumberOfBathrooms,
                            NumberOfGaragePositions = newHouseDesign.NumberOfGaragePositions,
                            ImagePath = model.ImagePath
                        };

                        return Created($"/api/housedesigns/{vm.HouseDesignId}", vm);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to save new house design: {ex}");
            }
            return BadRequest("Failed to sane new house design");
        }
    }
}
