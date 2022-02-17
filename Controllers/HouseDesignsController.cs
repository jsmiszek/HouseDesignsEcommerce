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
    [ApiController]
    /*[Produces("application.json")]*/
    public class HouseDesignsController : Controller
    {
        private readonly IApplicationRepository _repository;
        private readonly ILogger<HouseDesignsController> _logger;
        private readonly IMapper _mapper;

        public HouseDesignsController(IApplicationRepository repository, ILogger<HouseDesignsController> logger, IMapper mapper)
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
                var result = _repository.GetAllHouseDesigns();
                return Ok(_mapper.Map<IEnumerable<HouseDesign>, IEnumerable<HouseDesignViewModel>>(result));
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
                    return Ok(_mapper.Map<HouseDesign, HouseDesignViewModel>(houseDesign));
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
                    var newHouseDesign = _mapper.Map<HouseDesignViewModel, HouseDesign>(model);

                    _repository.AddEntity(newHouseDesign);

                    if (_repository.SaveAll())
                    {

                        return Created($"/api/housedesigns/{newHouseDesign.HouseDesignId}", _mapper.Map<HouseDesign, HouseDesignViewModel>(newHouseDesign));
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
            return BadRequest("Failed to save new house design");
        }
    }
}
