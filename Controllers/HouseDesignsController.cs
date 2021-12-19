using HouseDesignsEcommerce.Data;
using HouseDesignsEcommerce.Data.Entities;
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
    }
}
