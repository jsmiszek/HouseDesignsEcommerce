using HouseDesignsEcommerce.Data;
using HouseDesignsEcommerce.Data.Entities;
using HouseDesignsEcommerce.Models;
using HouseDesignsEcommerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace HouseDesignsEcommerce.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMailService _mailService;
        private readonly IApplicationRepository _repository;

        public HomeController(IMailService mailService, IApplicationRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send the email
                _mailService.SendMessage("justynasmiszek1@gmail.com", model.Subject,
                    $"From: {model.Name} - {model.Email} Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //Show the errors
            }
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllHouseDesigns();

            return View(results);
        }

        [HttpGet("productdetails")]
        public IActionResult ProductDetails(HouseDesignViewModel houseDesign)
        {
            return View(houseDesign);
        }
    }
}
